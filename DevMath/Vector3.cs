﻿using System;
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
            get { return(float)Math.Sqrt(x * x + y * y + z * z); }
        }

        public Vector3 Normalized
        {
			get
			{
				if (Magnitude > 0)
				{
					return new Vector3(x / (float)Math.Sqrt(Magnitude), y / (float)Math.Sqrt(Magnitude), z / (float)Math.Sqrt(Magnitude));
				}
				else
				{
					return new Vector3(0, 0, 0);
				}
			}
		}

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator Vector3(Vector2 v)
        {
			return new Vector3(v.x, v.y, 0);
        }

        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
			return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
		}

        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
		{ //https://www.mathsisfun.com/algebra/vectors-cross-product.html
			return new Vector3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
		}

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
			DevMath.Clamp(t, 0, 1);
			return a * (1 - t) + b * t;
		}

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
			return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
			return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
		}

        public static Vector3 operator -(Vector3 v)
        {
			return new Vector3(-v.x, -v.y, -v.z);
		}

        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
			return new Vector3(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar);
		}

        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
			return new Vector3(lhs.x / scalar, lhs.y / scalar, lhs.z / scalar);
		}
    }
}
