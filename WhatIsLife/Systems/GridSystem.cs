using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatIsLife.Helpers;
using WhatIsLife.Objects;
using WhatIsLife.Objects.Interfaces;

namespace WhatIsLife.Systems
{
    public class GridSystem<T> where T : BaseObject
    {
        // World length/width must be divisible by these values. There will be santity checks
        public int CellLength = 100;
        public int CellHeight = 100;

        public Dictionary<Point, List<T>> Cells = new Dictionary<Point, List<T>>();

        private int _totalColumns;
        private int _totalRows;

        public GridSystem()
        {
            if (GameConfig.WorldHeight % CellHeight != 0 || GameConfig.WorldLength % CellLength != 0)
            {
                throw new Exception("World Height/Width is not divisible by Cell Length/Width");
            }

            _totalColumns = GameConfig.WorldLength / CellLength;
            _totalRows = GameConfig.WorldHeight / CellHeight;
            PopulateEmptyGrid();
        }

        public void PopulateEmptyGrid()
        {
            Cells = new Dictionary<Point, List<T>>();

            for (int i = 0; i < _totalColumns; i++)
            {
                for (int j = 0; j < _totalRows; j++)
                {
                    Cells[new Point(i, j)] = new List<T>();
                }
            }
        }


        public Point GetCellKey(Vector2 position)
        {

            int nthColumn = (int)Math.Floor(position.X / CellLength);
            int nthRow = (int)Math.Floor(position.Y / CellHeight);

            return new Point(nthColumn, nthRow);
        }

        public void Add(T obj)
        {
            Point cellKey = GetCellKey(obj.Position);
            List<T> cell = Cells[cellKey];
            cell.Add(obj);
        }

        public void AddRange(List<T> objects)
        {
            foreach (T obj in objects)
            {
                Add(obj);
            }
        }

        public void Remove(T obj)
        {
            Point cellKey = GetCellKey(obj.Position);
            Cells[cellKey].Remove(obj);
        }

        // This method assumes the raidus is a square, not a circle and therefore will return more objects
        // Although it does not affect accuracy, performance might be impacted
        public List<T> GetNearbyObjects(Vector2 position, float radius)
        {
            List<T> objects = new List<T>();
            List<Point> nearbyCells = new List<Point>();

            Vector2 topLeftPosition = new Vector2
            {
                X = Math.Max(position.X - radius, 0),
                Y = Math.Max(position.Y - radius, 0)
            };

            Vector2 bottomRightPosition = new Vector2
            {
                X = Math.Min(position.X + radius, GameConfig.WorldLength - 1),
                Y = Math.Min(position.Y + radius, GameConfig.WorldHeight - 1)
            };

            Point topLeftCellNum = GetCellKey(topLeftPosition);
            Point bottomRightCellNum = GetCellKey(bottomRightPosition);

            for (int i = topLeftCellNum.X; i <= bottomRightCellNum.X; i++)
            {
                for (int j = topLeftCellNum.Y; j <= bottomRightCellNum.Y; j++)
                {
                    nearbyCells.Add(new Point(i, j));
                }
            }

            foreach (Point cell in nearbyCells)
            {
                objects.AddRange(Cells[cell]);
            }



            return objects;
        }

        public List<T> AllObjects()
        {
            List<T> objects = new List<T>();
            foreach (KeyValuePair<Point, List<T>> cell in Cells)
            {
                objects.AddRange(cell.Value);
            }

            if (GameConfig.Debug)
            {
                if (objects.Any(x => !(x as IReusable).IsActive))
                {
                    throw new Exception("Error");
                }
            }

            return objects;
        }

        public void Draw(SpriteBatch spriteBatch, float cameraZoom)
        {
            for (int column = 1; column < _totalColumns; column++)
            {
                spriteBatch.DrawLine(column * CellLength, 0, column * CellLength, GameConfig.WorldHeight, GameConfig.Colors.GridColor, 1 / cameraZoom);
            }

            for (int row = 1; row < _totalRows; row++)
            {
                spriteBatch.DrawLine(0, row * CellHeight, GameConfig.WorldLength, row * CellHeight, GameConfig.Colors.GridColor, 1 / cameraZoom);
            }
        }
    }
}
