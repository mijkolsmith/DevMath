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
            return a + (b - a) * t;
        }

        public static float RadToDeg(float angle)
        {
            return angle * (float)(180.0 / Math.PI);
        }

        public static float DegToRad(float angle)
        {
            return angle * (float)(Math.PI / 180.0);
        }
    }
}
