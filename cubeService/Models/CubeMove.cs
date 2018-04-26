using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cubeService.Models
{
    public class CubeMove
    {
        public CubePlane Plane { get; set; }
        public int Level { get; set; }
        public CubeMoveDirection Direction { get; set; }

        public string Symbol { get; set; }

    }

    public enum CubePlane
    {
        X,
        Y,
        Z
    }

    public enum CubeMoveDirection
    {
        Left,
        Right
    }

}