using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cubeService.Models
{
    public enum CubeValue
    {
        None,
        Up,
        Front,
        Left,
        Right,
        Back,
        Down
    }

    public class CubeFace
    {
        private CubeValue[,] _face;

        public CubeFace()
        {
            _face = new CubeValue[2, 2];
        }

        public CubeFace(int cubeSize)
        {
            _face = new CubeValue[cubeSize - 1, cubeSize - 1];
        }

        public bool SetFaceValue(int row, int column, CubeValue cubeValue)
        {
            var result = false;
            
            _face[row, column] = cubeValue;
            result = true;

            return result;
        }

        public CubeValue GetFaceValue(int row, int column)
        {
            var result = CubeValue.None;

            result = _face[row, column];

            return result;
        }

        public void Init(CubeValue cubeValue)
        {
            //initialize with defaults
            for (int y = 0; y < _face.GetLength(1); y++)
            {
                for(int x = 0; x < _face.GetLength(0); x++)
                {
                    _face[x, y] = cubeValue;
                }
            }
        }
    }
}