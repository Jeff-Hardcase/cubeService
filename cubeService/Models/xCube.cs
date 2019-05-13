using System;


namespace cubeService.Models
{
    public class xCube
    {
        private int cubeSize;
        private int faceMax;

        public CubeFace FrontFace { get; set; }
        public CubeFace BackFace { get; set; }
        public CubeFace UpFace { get; set; }
        public CubeFace DownFace { get; set; }
        public CubeFace LeftFace { get; set; }
        public CubeFace RightFace { get; set; }

        public xCube()
        {
            cubeSize = 3;
            faceMax = cubeSize - 1;

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
            int i, j;

            CubeFace endFace = null;
            CubeValue planeValue = CubeValue.None;
            
            int z = Math.Abs(move.Level - faceMax);
            
            switch (move.Plane)
            {
                case CubePlane.X:
                    //save before move
                    if (move.Level == 0)
                        endFace = LeftFace;
                    else if (move.Level == faceMax)
                        endFace = RightFace;

                    for (i = 0; i < cubeSize; i++)
                    {
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

                        //do face move maybe
                        DoFaceMove(endFace, move.Direction, i, j);
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
                            LeftFace.SetFaceValue(z, i, DownFace.GetFaceValue(j, move.Level));
                            DownFace.SetFaceValue(j, move.Level, RightFace.GetFaceValue(z, j));
                            RightFace.SetFaceValue(z, j, UpFace.GetFaceValue(i, move.Level));
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
                        DoFaceMove(endFace, move.Direction, i, j);
                    }

                    break;
                case CubePlane.Z:
                    //save before move
                    if (move.Level == 0)
                        endFace = DownFace;
                    else if (move.Level == faceMax)
                        endFace = UpFace;

                    for (i = 0; i < cubeSize; i++)
                    {
                        j = Math.Abs(i - faceMax);
                        planeValue = FrontFace.GetFaceValue(i, move.Level);

                        //do plane move
                        if (move.Direction == CubeMoveDirection.Right)
                        {
                            FrontFace.SetFaceValue(i, move.Level, RightFace.GetFaceValue(j, move.Level));
                            RightFace.SetFaceValue(j, move.Level, BackFace.GetFaceValue(j, move.Level));
                            BackFace.SetFaceValue(j, move.Level, LeftFace.GetFaceValue(i, move.Level));
                            LeftFace.SetFaceValue(i, move.Level, planeValue);
                        }
                        else
                        {
                            FrontFace.SetFaceValue(i, move.Level, LeftFace.GetFaceValue(i, move.Level));
                            LeftFace.SetFaceValue(i, move.Level, BackFace.GetFaceValue(j, move.Level));
                            BackFace.SetFaceValue(j, move.Level, RightFace.GetFaceValue(j, move.Level));
                            RightFace.SetFaceValue(j, move.Level, planeValue);
                        }

                        //do face move maybe
                        DoFaceMove(endFace, move.Direction, i, j);
                    }

                    break;
            }
        }

        private void DoFaceMove(CubeFace face, CubeMoveDirection direction, int i, int j)
        {
            if (face != null && i < faceMax)
            {
                var faceValue = face.GetFaceValue(i, 0);

                if (direction == CubeMoveDirection.Right)
                {
                    face.SetFaceValue(i, 0, face.GetFaceValue(faceMax, i));
                    face.SetFaceValue(faceMax, i, face.GetFaceValue(j, faceMax));
                    face.SetFaceValue(j, faceMax, face.GetFaceValue(0, j));
                    face.SetFaceValue(0, j, faceValue);
                }
                else
                {
                    face.SetFaceValue(i, 0, face.GetFaceValue(0, j));
                    face.SetFaceValue(0, j, face.GetFaceValue(j, faceMax));
                    face.SetFaceValue(j, faceMax, face.GetFaceValue(faceMax, i));
                    face.SetFaceValue(faceMax, i, faceValue);
                }
            }

            return;
        }
    }
}