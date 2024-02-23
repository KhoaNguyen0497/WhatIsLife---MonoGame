using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatIsLife.Helpers;
using WhatIsLife.Objects.Attributes;
using WhatIsLife.Objects.Interfaces;
using WhatIsLife.Objects.Traits;

namespace WhatIsLife.Objects
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Entity : BaseObject, IReusable, IDisposable
    {
        private static int _currentId { get; set; } = 0;

        public Vector2 Velocity;

        public BaseObject Target { get; set; }

        public Gender Gender { get; set; }

        /// <summary>
        /// Chance of turning every update
        /// </summary>
        public int NoiseRandomness { get; } = 20;

        /// <summary>
        /// The Entity can turn x degrees to the left or right
        /// </summary>
        public float RotationAngle { get; } = 45;
        public float RotationAngleRadian { get; set; }

        public int ReproductionCooldown { get; set; }

        public bool IsTracked { get; set; } = false;

        public AttributeSystem Attributes { get; set; } = new AttributeSystem();
        public TraitSystem Traits { get; set; } = new TraitSystem();


        public List<Tuple<Vector2, BaseObject>> History = new List<Tuple<Vector2, BaseObject>>();

        public void ResetReproductionSystem()
        {
            ReproductionCooldown = Age + GameObjects.Random.Next(1, 7);
            var currentTarget = Target as Entity;

            if (currentTarget != null)
            {
                UnlinkPartner();
                currentTarget.ResetReproductionSystem();
            }
        }

        public void UnlinkPartner()
        {
            (Target as Entity).Target = null;
            Target = null;
        }

        public void Dispose()
        {
            if (Target != null)
            {
                if (Target is Food)
                {
                    (Target as Food).Entities.Remove(this);
                }
                else if (Target is Entity)
                {
                    UnlinkPartner();
                }
            }

            IsActive = false;
            GameObjects.Entities.Remove(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color genderColor = Gender == Gender.Male ? GlobalObjects.GameConfig.Colors.MaleEntity : GlobalObjects.GameConfig.Colors.FemaleEntity;
            spriteBatch.DrawPoint(Position, genderColor, 10);

            if (GlobalObjects.GameConfig.Debug)
            {
                spriteBatch.DrawCircle(Position, Attributes.Radius.Value, 10, genderColor, 1);
                if (Target != null)
                {
                    spriteBatch.DrawLine(Position, Target.Position, genderColor, 2);
                }
            }
        }

        // Spawn and Respawn
        public void Respawn(Vector2? position = null)
        {
            // Reset everything just in case since we are utilizing dispose()
            if (Id == 0)
            {
                _currentId++;
                Id = _currentId;
            }

            RotationAngleRadian = (float)Math.PI / 180 * RotationAngle;          
            Age = 0;
            Attributes.Reset();
            Traits.Reset(this);
            Gender = (Gender)GameObjects.Random.Next(2);
            Target = null;
            IsActive = true;
            ReproductionCooldown = 1;

            if (position == null)
            {
                Position.X = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldWidth);
                Position.Y = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldHeight);
            }
            else
            {
                Position.X = ((Vector2)position).X;
                Position.Y = ((Vector2)position).Y;
            }

            GameObjects.Random.NextUnitVector(out Velocity);
            Velocity *= Attributes.Speed.Value;
        }

        // Find and move to Food, or consume it
        public void FindFood()
        {
            if (Target != null)
            {
                if (Target.GetType() == typeof(Food))
                {
                    // Consume the food
                    // TODO maybe change BaseObject to have Dispose
                    if (Target.Position == Position)
                    {
                        Attributes.Hunger.Increment(30);
                        (Target as Food).Dispose();
                    }
                }
            }
            else if (Attributes.Hunger.FindFoodThreshold())
            {

                var allFood = GameObjects.FoodList.GetNearbyObjects(Position, Attributes.Radius.Value);
                Food food = allFood.FirstOrDefault(x => VectorHelper.WithinDistance(x.Position, Position, Attributes.Radius.Value));

                if (food != null)
                {
                    Target = food;
                    food.Entities.Add(this);
                }
            }
        }

        public void FindPartner()
        {
            // Check count as well.
            // There's a chance we can breed more than the max capacity but thats fine.
            // This can happen when count < max cap but lots of entities find a parter this frame.
            if (Target == null && Age >= ReproductionCooldown && GameObjects.Entities.ActiveCount() < GlobalObjects.GameConfig.MaxEntity)
            {
                Entity partner = GameObjects.Entities
                    .GetNearbyObjects(Position, Attributes.Radius.Value)
                    .FirstOrDefault(entity =>
                        !(entity.Target != null ||
                        Gender == entity.Gender ||
                        entity.Age < entity.ReproductionCooldown ||
                        !VectorHelper.WithinDistance(Position, entity.Position, Attributes.Radius.Value + entity.Attributes.Radius.Value)));

                if (partner != null)
                {
                    Target = partner;
                    partner.Target = this;
                }
            }
            else if (Target is Entity && Position == Target.Position)
            {
                Breed();
            }
        }

        public void Breed()
        {
            // New Entity
            GameObjects.Entities.CreateNewObject(Position);
            ResetReproductionSystem();
        }

        public void Wander()
        {
            if (Target != null)
            {
                return;
            }

            if (Velocity == Vector2.Zero || GameObjects.Random.Chance(NoiseRandomness))
            {
                Velocity = Velocity.Rotate(GameObjects.Random.NextSingle(-RotationAngleRadian, RotationAngleRadian));
            }
        }

        public bool RandomDeathChance()
        {
            if (!GlobalObjects.GameConfig.EnableDeath)
            {
                return false;
            }

            // If Hunger reaches 0, it dies
            if (Attributes.Hunger.DeathThreshold())
            {
                return true;
            }

            // {Age - 60}% chance to die every day after turning 60
            int dyingAge = 25;
            if (Age >= dyingAge)
            {
                if (GameObjects.Random.Chance(Age - dyingAge))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi ");

            sb.Append(@$"Position: {Position.X:#},{Position.Y:#}\line ");
            sb.Append(@$"Age: {Age}\line ");
            sb.Append(@$"Gender: {Gender}\line ");

            var targetString = Target == null ? ""
                : Target is Food ? "Food "
                : Target is Entity ? "Entity "
                : "";
            targetString += $"{Target?.Id}";


            sb.Append(@$"Speed: {Attributes.Speed.Value}\line ");
            sb.Append(@$"Target: {targetString}\line ");
            sb.Append(@$"Active: {IsActive}\line ");
            sb.Append(@"}");

            return sb.ToString();
        }

        public void Update()
        {
         
            if (GlobalObjects.GameConfig.Debug)
            {
                if (Target != null)
                {
                    if (Target is Entity && !VectorHelper.WithinDistance(Target.Position, Position, Attributes.Radius.Value + (Target as Entity).Attributes.Radius.Value))
                    {
                        throw new Exception("Entity not within distance");
                    }

                    if (Target is Food && !VectorHelper.WithinDistance(Target.Position, Position, Attributes.Radius.Value))
                    {
                        throw new Exception("Food not within distance");
                    }
                }
            }

            if (GlobalObjects.TempVariables.NewDay)
            {
                Age++;
                Attributes.Hunger.Decrement(20);
            }

            if (RandomDeathChance())
            {
                Dispose();
                return;
            }

            FindFood();
            FindPartner();
            Wander();
        }

        public void Move()
        {
            if (!IsActive)
            {
                return;
            }

            if (GlobalObjects.GameConfig.Debug)
            {
                History.Add(new Tuple<Vector2, BaseObject>(Position, Target));
                if (History.Count > 10)
                {
                    History.RemoveAt(0);
                }
            }

            if (Target != null)
            {
                Vector2 directionToTarget = new Vector2
                {
                    X = Target.Position.X - Position.X,
                    Y = Target.Position.Y - Position.Y
                };

                Velocity = directionToTarget;
              
                if (Velocity.Length() > Attributes.Speed.Value)
                {
                    Velocity.Normalize();
                    
                    Velocity *= Attributes.Speed.Value;
                }
            }

            Position += Velocity;

        
            if (Position.X <= 0f)
            {
                Position.X = 0;
                Velocity.X *= -1;
            }

            if (Position.X >= GlobalObjects.GameConfig.WorldWidth)
            {
                Position.X = GlobalObjects.GameConfig.WorldWidth - 1; // -1 because otherwise GetCellKey will return an error
                Velocity.X *= -1;
            }

            if (Position.Y <= 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;
            }

            if (Position.Y >= GlobalObjects.GameConfig.WorldHeight)
            {
                Position.Y = GlobalObjects.GameConfig.WorldHeight - 1; // -1 because otherwise GetCellKey will return an error
                Velocity.Y *= -1;
            }

            // Reset velocity because sometimes entities slow down to not go pass its Target
            // Sometimes Velocity can get to Zero. E.g. when a target spawns at the same position, causing the the path finding system to output velocity of Zero
            if (Velocity == Vector2.Zero)
            {
                GameObjects.Random.NextUnitVector(out Velocity);
            }
            else
            {
                Velocity.Normalize();
            }

            Velocity *= Attributes.Speed.Value;
        }
    }
}
