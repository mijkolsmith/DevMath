using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public float Magnitude
        {
            get { throw new NotImplementedException(); }
        }

        public Vector3 Normalized
        {
            get { throw new NotImplementedException(); }
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator Vector3(Vector2 v)
        {
            throw new NotImplementedException();
        }

        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            throw new NotImplementedException();
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector3 operator -(Vector3 v)
        {
            throw new NotImplementedException();
        }

        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            throw new NotImplementedException();
        }

        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            throw new NotImplementedException();
        }
    }
}
