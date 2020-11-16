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
            get
			{
				//float.Epsilon
				if (Magnitude > 0)
				{
					return new Vector2(x / Magnitude, y / Magnitude);
				}
				else return new Vector2(0, 0);
			}
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
			DevMath.Clamp(t, 0, 1);
			return a * (1 - t) + b * t;
		}

        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
			//https://stackoverflow.com/questions/21483999/using-atan2-to-find-angle-between-two-vectors
			Vector2 v = rhs- lhs;
			//- is needed because it turns the wrong way otherwise, and the .5 * pi 
			//is because otherwise it will have a difference in position compared to the mouse
			return (float)Math.Atan2(v.y, v.x);
		}

        public static Vector2 DirectionFromAngle(float angle)
        {
			return new Vector2((float)Math.Cos(DevMath.DegToRad(angle)), (float)Math.Sin(DevMath.DegToRad(angle)));
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
