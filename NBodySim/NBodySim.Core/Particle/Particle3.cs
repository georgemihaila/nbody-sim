using System;
using System.Collections.Generic;
using System.Text;

namespace NBodySim.Core
{
    public class Particle3 : IParticle<Vector3>
    {
        /// <summary>
        /// Gets or sets the mass.
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Gets or sets the position vector.
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Gets or sets the speed vector.
        /// </summary>
        public Vector3 Speed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Particle3"/> class.
        /// </summary>
        public Particle3()
        {
            Mass = 0;
            Position = new Vector3();
            Speed = new Vector3();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Particle3"/> class.
        /// </summary>
        /// <param name="mass">The mass of the particle.</param>
        /// <param name="position">The position vector of the particle.</param>
        /// <param name="speed">The speed vector of the particle.</param>
        public Particle3(double mass, Vector3 position, Vector3 speed)
        {
            Mass = mass;
            Position = position;
            Speed = speed;
        }
    }
}
