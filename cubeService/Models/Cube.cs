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
            int i, j;

            CubeFace endFace = null;
            CubeValue faceValue = CubeValue.None;
            CubeValue planeValue = CubeValue.None;
            int faceMax = cubeSize - 1;
            int z = Math.Abs(move.Level - faceMax);
            
            switch (move.Plane)
            {
                case CubePlane.X:
                    //save before move
                    if (move.Level == 0)
                        endFace = LeftFace;
                    else if (move.Level == faceMax)
                        endFace = RightFace;

                    for (i = 0; i < cubeSize; i++){
                        j = Math.Abs(i - faceMax);
                        
                        planeValue = FrontFace.GetFaceValue(move.Level, i);

                        //do plane move
                        if (move.Direction == CubeMoveDirection.Right)
                        {
                            FrontFace.SetFaceValue(move.Level, i, UpFace.GetFaceValue(move.Level, i));
                            UpFace.SetFaceValue(move.Level, i, BackFace.GetFaceValue(move.Level, j));
                            BackFace.SetFaceValue(move.Level, j, DownFace.GetFaceValue(move.Level, j));
                            DownFace.SetFaceValue(move.Level, j, planeValue);
                        }
                        else
                        {
                            FrontFace.SetFaceValue(move.Level, i, DownFace.GetFaceValue(move.Level, j));
                            DownFace.SetFaceValue(move.Level, j, BackFace.GetFaceValue(move.Level, j));
                            BackFace.SetFaceValue(move.Level, j, UpFace.GetFaceValue(move.Level, i));
                            UpFace.SetFaceValue(move.Level, i, planeValue);
                        }

                        if (endFace != null && i < faceMax)
                        {
                            faceValue = endFace.GetFaceValue(0, i);

                            //do face move
                            if (move.Direction == CubeMoveDirection.Right)
                            {
                                endFace.SetFaceValue(0, i, endFace.GetFaceValue(j, i));
                                endFace.SetFaceValue(j, i, endFace.GetFaceValue(j, j));
                                endFace.SetFaceValue(j, j, endFace.GetFaceValue(0, j));
                                endFace.SetFaceValue(0, j, faceValue);
                            }
                            else
                            {
                                endFace.SetFaceValue(0, 1, endFace.GetFaceValue(0, j));
                                endFace.SetFaceValue(0, j, endFace.GetFaceValue(j, j));
                                endFace.SetFaceValue(j, j, endFace.GetFaceValue(j, i));
                                endFace.SetFaceValue(j, i, faceValue);
                            }
                        }
                    }
                   
                    break;
                case CubePlane.Y:
                    //save before move
                    if (move.Level == 0)
                        endFace = FrontFace;
                    else if (move.Level == faceMax)
                        endFace = BackFace;

                    for (i = 0; i < cubeSize; i++)
                    {
                        j = Math.Abs(i - faceMax);

                        planeValue = LeftFace.GetFaceValue(z, i);

                        //do plane move
                        if (move.Direction == CubeMoveDirection.Right)
                        {
                            LeftFace.SetFaceValue(z, i, DownFace.GetFaceValue(i,move.Level));
                            DownFace.SetFaceValue(i, move.Level, RightFace.GetFaceValue(z, i));
                            RightFace.SetFaceValue(z, i, UpFace.GetFaceValue(i, move.Level));
                            UpFace.SetFaceValue(i, move.Level, planeValue);
                        }
                        else
                        {
                            LeftFace.SetFaceValue(z, i, UpFace.GetFaceValue(i, move.Level));
                            UpFace.SetFaceValue(i, move.Level, RightFace.GetFaceValue(z, j));
                            RightFace.SetFaceValue(z, j, DownFace.GetFaceValue(j, move.Level));
                            DownFace.SetFaceValue(j, move.Level, planeValue);
                        }

                        //do face move maybe
                        if (endFace != null && i < faceMax)
                        {
                            faceValue = endFace.GetFaceValue(i, 0);

                            if (move.Direction == CubeMoveDirection.Right)
                            {
                                endFace.SetFaceValue(i, 0, endFace.GetFaceValue(faceMax, i));
                                endFace.SetFaceValue(faceMax, i, endFace.GetFaceValue(j, faceMax));
                                endFace.SetFaceValue(j, faceMax, endFace.GetFaceValue(0, j));
                                endFace.SetFaceValue(0, j, faceValue);
                            }
                            else
                            {
                                endFace.SetFaceValue(i, 0, endFace.GetFaceValue(0, j));
                                endFace.SetFaceValue(0, j, endFace.GetFaceValue(j, faceMax));
                                endFace.SetFaceValue(j, faceMax, endFace.GetFaceValue(faceMax, i));
                                endFace.SetFaceValue(faceMax, i, faceValue);
                            }
                        }
                    }

                    break;
                case CubePlane.Z:
                    break;
            }
        }
    }
}