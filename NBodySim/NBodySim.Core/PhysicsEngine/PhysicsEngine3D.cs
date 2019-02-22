using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBodySim.Core
{
    /// <summary>
    /// Represents a 3-dimensional physics engine.
    /// </summary>
    public class PhysicsEngine3D : IPhysicsEngine<Particle3, Vector3>
    {
        /// <summary>
        /// Gets the particles used in the simulation.
        /// </summary>
        public Particle3[] Particles { get; private set; }

        /// <summary>
        /// Gets the value of the gravitational constant.
        /// </summary>
        public double G { get; }

        private readonly Random Random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsEngine3D"/> class.
        /// </summary>
        /// <param name="g">The value of the gravitational constant.</param>
        /// <param name="particleCount">The number of particles.</param>
        public PhysicsEngine3D(double g, int particleCount)
        {
            G = g;
            Particles = new Particle3[particleCount];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsEngine3D"/> class.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="particles"></param>
        public PhysicsEngine3D(double g, params Particle3[] particles)
        {
            G = g;
            Particles = particles;
        }

        /// <summary>
        /// Randomizes the particles.
        /// </summary>
        /// <param name="minMass">The minimum mass of the particles.</param>
        /// <param name="maxMass">The maximum mass of the particles.</param>
        /// <param name="boundingRectangleSideLength">The side length of the bounding cube used for determining positions.</param>
        public void Randomize(double minMass, double maxMass, double boundingRectangleSideLength)
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                Particles[i] = new Particle3(Random.NextDouble(minMass, maxMass), new Vector3(Random.NextDouble(-boundingRectangleSideLength, boundingRectangleSideLength), Random.NextDouble(-boundingRectangleSideLength, boundingRectangleSideLength), Random.NextDouble(-boundingRectangleSideLength, boundingRectangleSideLength)), Vector3.Zero);
            }
        }

        /// <summary>
        /// Calculates one instant of movement synchronously.
        /// </summary>
        public void Next() { }

        /// <summary>
        /// Calculates one instant of movement asynchronously.
        /// </summary>
        public Task NextAsync()
        {
            return Task.CompletedTask;
        }
    }
}
