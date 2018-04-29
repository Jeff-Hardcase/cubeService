using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cubeService.Models
{
    public class Cube
    {
        private int cubeSize;

        public CubeFace FrontFace { get; set; }
        public CubeFace BackFace { get; set; }
        public CubeFace UpFace { get; set; }
        public CubeFace DownFace { get; set; }
        public CubeFace LeftFace { get; set; }
        public CubeFace RightFace { get; set; }

        public Cube()
        {
            cubeSize = 3;

            FrontFace = new CubeFace(cubeSize);
            BackFace = new CubeFace(cubeSize);
            UpFace = new CubeFace(cubeSize);
            DownFace = new CubeFace(cubeSize);
            LeftFace = new CubeFace(cubeSize);
            RightFace = new CubeFace(cubeSize);
        }

        public void Init()
        {
            //initial values, no state given
            FrontFace.Init(CubeValue.Front);
            BackFace.Init(CubeValue.Back);
            UpFace.Init(CubeValue.Up);
            DownFace.Init(CubeValue.Down);
            LeftFace.Init(CubeValue.Left);
            RightFace.Init(CubeValue.Right);

            return;
        }

        public void DoMove(CubeMove move)
        {
            var SaveFace = new CubeFace(cubeSize);

            switch (move.Plane)
            {

                case CubePlane.X:
                    //save before move
                    
                    if (move.Level == 0 || move.Level == (cubeSize - 1))
                    {

                    }
                    break;
                case CubePlane.Y:
                    break;
                case CubePlane.Z:
                    break;
            }
        }
    }
}