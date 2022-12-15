using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatIsLife.Helpers;
using WhatIsLife.Objects.Interfaces;

namespace WhatIsLife.Objects
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Entity : BaseObject, IReusable, IDisposable
    {

        public Vector2 Velocity;

        public bool IsActive { get; set; }

        public BaseObject Target { get; set; }

        public Gender Gender { get; set; }

        public float Speed { get; set; }

        public float Radius { get; set; }

        /// <summary>
        /// Chance of turning every update
        /// </summary>
        public int NoiseRandomness { get; } = 20;

        /// <summary>
        /// The Entity can turn x degrees to the left or right
        /// </summary>
        public float RotationAngle { get; } = 45;
        public float RotationAngleRadian { get; }

        public int ReproductionCooldown { get; set; }

        public List<Tuple<Vector2, BaseObject>> History = new List<Tuple<Vector2, BaseObject>>();

        // Private constructor because we are driving the creation of objects through recycling disposed objects
        public Entity()
        {
            RotationAngleRadian = (float)Math.PI / 180 * RotationAngle;
        }

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
            var currentTarget = Target as Entity;

            if (currentTarget != null)
            {
                currentTarget.Target = null;
            }

            Target = null;
        }

        public void Dispose()
        {
            UnlinkPartner();
            IsActive = false;
            GameObjects.Entities.Remove(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color genderColor = Gender == Gender.Male ? GlobalObjects.GameConfig.Colors.MaleEntity : GlobalObjects.GameConfig.Colors.FemaleEntity;
            spriteBatch.DrawPoint(Position, genderColor, 10);

            if (GlobalObjects.GameConfig.Debug)
            {
                spriteBatch.DrawCircle(Position, Radius, 20, genderColor, 1);
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
            Gender = (Gender)GameObjects.Random.Next(2);
            Target = null;
            Speed = GlobalObjects.GameConfig.BaseEntitySpeed;
            Radius = GlobalObjects.GameConfig.BaseEntityRadius;
            IsActive = true;
            _startDay = GlobalObjects.GameStats.CurrentDay;
            ReproductionCooldown = 1;
            if (position == null)
            {
                Position = new Vector2
                {
                    X = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldWidth),
                    Y = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldHeight)
                };
            }
            else
            {
                Position = (Vector2)position;
            }

            GameObjects.Random.NextUnitVector(out Velocity);
            Velocity *= Speed;
        }

        // Find and move to Food, or consume it
        public void FindFood()
        {
            if (Target != null)
            {
                if (Target.GetType() == typeof(Food))
                {
                    // Consume the food
                    if (Target.Position == Position)
                    {
                        (Target as Food).Dispose();
                    }
                }
            }

            if (Target == null)
            {
                Food food = GameObjects.FoodList.GetNearbyObjects(Position, Radius).FirstOrDefault(x => VectorHelper.WithinDistance(x.Position, Position, Radius));

                if (food != null)
                {
                    Target = food;
                    food.Entities.Add(this);
                }
            }
        }

        public void FindPartner()
        {
            if (Target == null)
            {
                Entity partner = GameObjects.Entities.GetNearbyObjects(Position, Radius).FirstOrDefault(entity =>
                {  
                    if (entity.Target != null)
                    {
                        return false;
                    }

                    if (!VectorHelper.WithinDistance(Position, entity.Position, Radius + entity.Radius))
                    {
                        return false;
                    }

                    if (Gender == entity.Gender)
                    {
                        return false;
                    }

                    if (Age < ReproductionCooldown || entity.Age < entity.ReproductionCooldown)
                    {
                        return false;
                    }

                    return true;
                });

                if (partner != null)
                {
                    Target = partner;
                    partner.Target = this;
                }
            }
            else if (Target is Entity && Position == Target.Position)
            {
                GameObjects.Entities.CreateNewObject(Position);
                ResetReproductionSystem();
            }
            
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

        // {Age - 60}% chance to die every day after turning 60
        public bool RandomDeathChance()
        {
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

        public void Update()
        {
            if (GlobalObjects.GameConfig.Debug)
            {
                if (Target != null)
                {
                    if (Target is Entity && !VectorHelper.WithinDistance(Target.Position, Position, Radius + (Target as Entity).Radius))
                    {
                        throw new Exception("Entity not within distance");
                    }

                    if (Target is Food && !VectorHelper.WithinDistance(Target.Position, Position, Radius))
                    {
                        throw new Exception("Food not within distance");
                    }
                }
            }

            if (RandomDeathChance())
            {
                Dispose();
            }

            if (!IsActive)
            {
                return;
            }

            FindFood();
            FindPartner();
            Wander();
        }

        public void Move()
        {
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

                if (Velocity.Length() > Speed)
                {
                    Velocity.Normalize();
                    Velocity *= Speed;
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
                Position.X = GlobalObjects.GameConfig.WorldWidth - 1;
                Velocity.X *= -1;
            }

            if (Position.Y <= 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;
            }

            if (Position.Y >= GlobalObjects.GameConfig.WorldHeight)
            {
                Position.Y = GlobalObjects.GameConfig.WorldHeight - 1;
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

            Velocity *= Speed;
        }
    }
}
