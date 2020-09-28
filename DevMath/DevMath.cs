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
			return startVelocity * time + (acceleration * time * time) / 2;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (min <= value && value <= max)
			{
				return value;
			}
			if (value < min)
			{
				return min;
			}
			if (max < value)
			{
				return max;
			}
			if (max < min)
			{
				throw new Exception("Min is higher than max");
			}
			throw new Exception("Could not clamp value");
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
