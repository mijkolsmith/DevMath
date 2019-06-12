using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public float Magnitude
        {
            get { throw new NotImplementedException(); }
        }

        public Vector4 Normalized
        {
            get { throw new NotImplementedException(); }
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static implicit operator Vector4(Vector3 v)
        {
            throw new NotImplementedException();
        }

        public static float Dot(Vector4 lhs, Vector4 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Lerp(Vector4 a, Vector4 b, float t)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator -(Vector4 v)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator *(Vector4 lhs, float scalar)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            throw new NotImplementedException();
        }
    }
}
