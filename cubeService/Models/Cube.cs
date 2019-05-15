using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cubeService.Models
{
    public class Cube
    {
        public Cubelet[,,] cubelets { get; set; }
        public int Size { get; set; }

        public Cube(int cubeSize = 3)
        {
            Size = cubeSize;
            cubelets = new Cubelet[cubeSize + 1, cubeSize + 1, cubeSize + 1];
        }

        public bool Init()
        {
            for (int z = 1; z <= Size; z++)
                for (int y = 1; y <= Size; y++)
                    for (int x = 1; x <= Size; x++)
                    {
                        cubelets[x, y, z] = new Cubelet
                        {
                            X = (y == Size ? CubeValue.Left : CubeValue.Right),
                            Y = (x == Size ? CubeValue.Back : CubeValue.Front),
                            Z = (z == Size ? CubeValue.Up : CubeValue.Down)
                        };
                    }

            return true;
        }
        
    }
      

    public class Cubelet
    {
        public CubeValue X { get; set; }
        public CubeValue Y { get; set; }
        public CubeValue Z { get; set; }
    }
}