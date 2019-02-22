using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBodySim.Core
{
    /// <summary>
    /// Represents an inteface for building a physics engine.
    /// </summary>
    /// <typeparam name="T">The type of particles.</typeparam>
    /// <typeparam name="U">The type of vectors.</typeparam>
    internal interface IPhysicsEngine<T, U> where T : IParticle<U> where U : IVector
    {
        /// <summary>
        /// Gets the particles used in the simulation.
        /// </summary>
        T[] Particles { get; }

        /// <summary>
        /// Gets the value of the gravitational constant.
        /// </summary>
        double G { get; }

        /// <summary>
        /// Randomizes the particles.
        /// </summary>
        /// <param name="minMass">The minimum mass of the particles.</param>
        /// <param name="maxMass">The maximum mass of the particles.</param>
        /// <param name="boundingRectangleSideLength">The side length of the bounding n-cube used for determining positions.</param>
        void Randomize(double minMass, double maxMass, double boundingRectangleSideLength);

        /// <summary>
        /// Calculates one instant of movement synchronously.
        /// </summary>
        void Next();

        /// <summary>
        /// Calculates one instant of movement asynchronously.
        /// </summary>
        Task NextAsync();
    }
}
