using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class DevMath
    {
        public static float Lerp(float a, float b, float t)
        {
			Clamp(t, 0, 1);
			return a * (1 - t) + b * t;
		}

        public static float DistanceTraveled(float startVelocity, float acceleration, float time)
        {
			//s = ut + 1/2at^2
			return startVelocity * time + (acceleration * time * time) / 2;
        }

        public static float Clamp(float value, float min, float max)
        {
			if (max < min)
			{
				throw new Exception("Min cannot be larger than max");
			}

			/*if (value < min)
			{
				return min;
			}
			if (max < value)
			{
				return max;
			}
			return value;*/

			return Math.Max(Math.Min(value, max), min);
        }

        public static float RadToDeg(float angle)
        {
			return angle * 180 / (float)Math.PI;
		}

        public static float DegToRad(float angle)
        {
			return angle * (float)Math.PI / 180;
		}
    }
}
