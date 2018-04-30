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
            int i, j, k;
            CubeFace endFace = null;
            CubeValue end = CubeValue.None;

            switch (move.Plane)
            {
                case CubePlane.X:
                    //save before move
                    if (move.Level == 0)
                        endFace = LeftFace;
                    else if (move.Level == (cubeSize - 1))
                        endFace = RightFace;

                    for (i = 0; i < cubeSize; i++){
                        j = Math.Abs(i - cubeSize - 1);
                        
                        var front = FrontFace.GetFaceValue(move.Level, i);
                        SaveFace.SetFaceValue(move.Level, i, front);

                        //do plane move
                        if (move.Direction == CubeMoveDirection.Right)
                        {
                            FrontFace.SetFaceValue(move.Level, i, UpFace.GetFaceValue(move.Level, i));
                            UpFace.SetFaceValue(move.Level, i, BackFace.GetFaceValue(move.Level, j));
                            BackFace.SetFaceValue(move.Level, j, DownFace.GetFaceValue(move.Level, j));
                            DownFace.SetFaceValue(move.Level, j, SaveFace.GetFaceValue(move.Level, i));
                        }
                        else
                        {
                            FrontFace.SetFaceValue(move.Level, i, DownFace.GetFaceValue(move.Level, j));
                            DownFace.SetFaceValue(move.Level, j, BackFace.GetFaceValue(move.Level, j));
                            BackFace.SetFaceValue(move.Level, j, UpFace.GetFaceValue(move.Level, i));
                            UpFace.SetFaceValue(move.Level, i, SaveFace.GetFaceValue(move.Level, i));
                        }

                        if (endFace != null)
                        {
                            end = endFace.GetFaceValue(move.Level, i);
                            SaveFace.SetFaceValue(move.Level, i, end);

                            //do face move

                        }
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