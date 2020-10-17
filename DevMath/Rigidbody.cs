using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Rigidbody
    {
        public Vector2 Velocity
        {
            get; private set;
        }

        public float mass = 1.0f;
        public float force = 150.0f;
		public float frictionCoefficient = .47f;
		public float gravityAcceleration = 9.81f;

        public void AddForce(Vector2 forceDirection, float deltaTime)
        {
			//Fnet = F - Ffriction = F - frictionCoefficient * Fn = F - frictionCoefficient * mass * 9.81;
			//Velocity = a * t = Fnet / m * t;
			float netForce = force - frictionCoefficient * mass * gravityAcceleration;
			Velocity = (forceDirection * (netForce / mass)) * deltaTime;
        }
    }
}
