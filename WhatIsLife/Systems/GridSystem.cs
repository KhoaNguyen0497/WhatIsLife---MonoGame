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
    public class GridSystem<T> where T : BaseObject, IDisposable, IReusable, new()
    {
        // World length/width must be divisible by these values. There will be santity checks
        public int CellWidth = 250;
        public int CellHeight = 250;

        public List<List<T>> Cells = new List<List<T>>();

        private int _totalColumns;
        private int _totalRows;

        private Stack<T> _recycledObjects { get; set; } = new Stack<T>();
        private List<T> _allObjects { get; set; } = new List<T>();

        public GridSystem()
        {
            
        }

        public void Initiate()
        {
            if (GlobalObjects.GameConfig.WorldHeight % CellHeight != 0 || GlobalObjects.GameConfig.WorldWidth % CellWidth != 0)
            {
                throw new Exception("World Height/Width is not divisible by Cell Height/Width");
            }

            _totalColumns = GlobalObjects.GameConfig.WorldWidth / CellWidth;
            _totalRows = GlobalObjects.GameConfig.WorldHeight / CellHeight;

            // Flush everything to be recycled.
            AllObjects().ForEach(x => x.Dispose());
            PopulateEmptyGrid();
        }

        public void RepopulateGrid()
        {
            PopulateEmptyGrid();
            AddRange(AllObjects());
        }

        public void PopulateEmptyGrid()
        {
            Cells = new List<List<T>>(_totalRows * _totalColumns);

            for (int index = 0; index < _totalColumns * _totalRows; index++)
            {
                Cells.Add(new List<T>());
            }
        }


        public int GetCellKey(Vector2 position)
        {

            int nthColumn = (int)Math.Floor(position.X / CellWidth);
            int nthRow = (int)Math.Floor(position.Y / CellHeight);

            return nthRow * _totalColumns + nthColumn;
        }

        /// <summary>
        /// Find an object in the recycled list. If empty, create a new one
        /// </summary>
        public void CreateNewObject(Vector2? position = null)
        {
            T obj;
            if (_recycledObjects.Any())
            {
                obj = _recycledObjects.Pop();
            }
            else
            {
                obj = new T();
                _allObjects.Add(obj);
            }

            obj.Respawn(position);

            Add(obj);
        }


        public void AddRange(List<T> objects)
        {
            foreach (T obj in objects)
            {
                Add(obj);
            }
        }

        public void Add(T obj)
        {
            int cellKey = GetCellKey(obj.Position);
            List<T> cell = Cells[cellKey];
            cell.Add(obj);
        }

        public void Remove(T obj)
        {
            _recycledObjects.Push(obj);
            int cellKey = GetCellKey(obj.Position);
            Cells[cellKey].Remove(obj);
        }

        // This method assumes the radius is a square, not a circle and therefore will return more objects
        // Although it does not affect accuracy, performance might be impacted
        public IEnumerable<T> GetNearbyObjects(Vector2 position, float radius, Func<T, bool> condition = null)
        {
            List<T> objects = new List<T>();
            Vector2 topLeftPosition = new Vector2
            {
                X = Math.Max(position.X - radius, 0),
                Y = Math.Max(position.Y - radius, 0)
            };

            Vector2 bottomRightPosition = new Vector2
            {
                X = Math.Min(position.X + radius, GlobalObjects.GameConfig.WorldWidth - 1),
                Y = Math.Min(position.Y + radius, GlobalObjects.GameConfig.WorldHeight - 1)
            };

            int topLeftCellNum = GetCellKey(topLeftPosition);
            int bottomRightCellNum = GetCellKey(bottomRightPosition);

            int index = topLeftCellNum;
            while (index <= bottomRightCellNum)
            {
                objects.AddRange(Cells[index]);

                if ((bottomRightCellNum - index) % _totalColumns == 0)
                {
                    topLeftCellNum += _totalColumns;
                    index = topLeftCellNum;
                }
                else
                {
                    index++;
                }
            }
            
            //// Dont use this yet, it seems to have worse performance
            //if (condition != null)
            //{
            //    return objects.Where(x => condition(x));
            //}

            return objects;
        }

        public List<T> AllObjects(bool includingInactive = false)
        {
 
            if (includingInactive)
            {
                return _allObjects;
            }
            else
            {
                return _allObjects.Where(x => x.IsActive).ToList();
            }
        }

        public int ActiveCount()
        {
            return _allObjects.Count - _recycledObjects.Count;
        }

        public int RecycledCount()
        {
            return _recycledObjects.Count;
        }

        public int Count()
        {
            return _allObjects.Count;
        }

        public void Draw(SpriteBatch spriteBatch, float cameraZoom)
        {
            for (int column = 1; column < _totalColumns; column++)
            {
                spriteBatch.DrawLine(column * CellWidth, 0, column * CellWidth, GlobalObjects.GameConfig.WorldHeight, GlobalObjects.GameConfig.Colors.GridColor, 1 / cameraZoom);
            }

            for (int row = 1; row < _totalRows; row++)
            {
                spriteBatch.DrawLine(0, row * CellHeight, GlobalObjects.GameConfig.WorldWidth, row * CellHeight, GlobalObjects.GameConfig.Colors.GridColor, 1 / cameraZoom);
            }
        }
    }
}
