using System;
using System.Collections.Generic;
using System.Text;

namespace NBodySim.Core
{
    public class Particle2 : IParticle<Vector2>
    {
        /// <summary>
        /// Gets or sets the mass.
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Gets or sets the position vector.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the speed vector.
        /// </summary>
        public Vector2 Speed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Particle2"/> class.
        /// </summary>
        public Particle2()
        {
            Mass = 0;
            Position = new Vector2();
            Speed = new Vector2();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Particle2"/> class.
        /// </summary>
        /// <param name="mass">The mass of the particle.</param>
        /// <param name="position">The position vector of the particle.</param>
        /// <param name="speed">The speed vector of the particle.</param>
        public Particle2(double mass, Vector2 position, Vector2 speed)
        {
            Mass = mass;
            Position = position;
            Speed = speed;
        }
    }
}
