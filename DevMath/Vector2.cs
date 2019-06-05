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
            get { return (float)Math.Sqrt(x * x + y * y); }
        }

        public Vector2 Normalized
        {
            get { return Magnitude < float.Epsilon ? new Vector2(.0f, .0f) : new Vector2(x / Magnitude, y / Magnitude); }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            return a + (b - a) * t;
        }

        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
            float dx = rhs.x - lhs.x;
            float dy = rhs.y - lhs.y;

            return (float)Math.Atan2(dy, dx);
        }

        public static Vector2 DirectionFromAngle(float angle)
        {
            return new Vector2((float)Math.Cos(DevMath.DegToRad(angle)), (float)Math.Sin(DevMath.DegToRad(angle)));
        }

        public static Vector2 DirectionFromAngle(float angle)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x * scalar, lhs.y * scalar);
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x / scalar, lhs.y / scalar);
        }
    }
}
