using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector2
    {
        public float x;
        public float y;

        public float Magnitude
        {
            get { throw new NotImplementedException(); }
        }

        public Vector2 Normalized
        {
            get { throw new NotImplementedException(); }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            throw new NotImplementedException();
        }

        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            throw new NotImplementedException();
        }
    }
}
