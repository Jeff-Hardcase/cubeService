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

        public string Symbol { get {
                var result = string.Format("{0}{1}{2}", Plane.ToString().Substring(0, 1),
                                                        Level.ToString().Substring(0, 1),
                                                        Direction.ToString().Substring(0, 1));
                return result; } }

        public CubeMove()
        {
            //return a default move if nothing given
            this.Plane = CubePlane.X;
            this.Level = 1;
            this.Direction = CubeMoveDirection.Right;
        }

        public CubeMove(CubePlane plane, int level, CubeMoveDirection direction)
        {
            this.Plane = plane;
            this.Level = level;
            this.Direction = direction;
        }
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