using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Circle
    {
        public Vector2 Position
        {
            get; set;
        }

        public float Radius
        {
            get; set;
        }

        public bool CollidesWith(Circle circle)
        {
			float collision = (circle.Position - Position).Magnitude - Radius - circle.Radius;
			return collision <= 0;
        }

		public bool CollidesWith(Line line)
		{ //https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes/ray-sphere-intersection
			Vector2 O = line.Position;
			Vector2 D = line.Direction;
			Vector2 C = Position;

			Vector2 L = C - O;
			float tcaLength = Vector2.Dot(L, D);
			if (tcaLength < 0)
			{
				return false;
			}

			Vector2 tca = O + D * tcaLength;
			float dLength = (float)Math.Sqrt(L.Magnitude * L.Magnitude - tca.Magnitude * tca.Magnitude);
			if (dLength < 0 || dLength > Radius)
			{
				return false;
			}
			return true;
		}
	}
}
