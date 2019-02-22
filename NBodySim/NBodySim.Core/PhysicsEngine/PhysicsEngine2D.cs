using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBodySim.Core
{
    /// <summary>
    /// Represents a 2-dimensional physics engine.
    /// </summary>
    public class PhysicsEngine2D : IPhysicsEngine<Particle2, Vector2>
    {
        /// <summary>
        /// Gets the particles used in the simulation.
        /// </summary>
        public Particle2[] Particles { get; private set; }

        /// <summary>
        /// Gets the value of the gravitational constant.
        /// </summary>
        public double G { get; }

        public Vector2 Bound1 { get; set; }

        public Vector2 Bound2 { get; set; }

        private readonly Random Random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsEngine2D"/> class.
        /// </summary>
        /// <param name="g">The value of the gravitational constant.</param>
        /// <param name="particleCount">The number of particles.</param>
        public PhysicsEngine2D(double g, int particleCount)
        {
            G = g;
            Particles = new Particle2[particleCount];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsEngine2D"/> class.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="particles"></param>
        public PhysicsEngine2D(double g, params Particle2[] particles)
        {
            G = g;
            Particles = particles;
        }

        /// <summary>
        /// Randomizes the particles.
        /// </summary>
        /// <param name="minMass">The minimum mass of the particles.</param>
        /// <param name="maxMass">The maximum mass of the particles.</param>
        /// <param name="boundingRectangleSideLength">The side length of the bounding n-cube used for determining positions.</param>
        public void Randomize(double minMass, double maxMass, double boundingRectangleSideLength)
        {
            for(int i = 0; i < Particles.Length; i++)
            {
                Particles[i] = new Particle2(Random.NextDouble(minMass, maxMass), new Vector2(Random.NextDouble(-boundingRectangleSideLength, boundingRectangleSideLength), Random.NextDouble(-boundingRectangleSideLength, boundingRectangleSideLength)), Vector2.Zero);
            }
        }

        /// <summary>
        /// Calculates one instant of movement synchronously.
        /// </summary>
        public void Next()
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                for (int j = i + 1; j < Particles.Length; j++)
                {
                    //acceleration = - G * m1 *m2 / r^3
                    double distance = Particles[i].Position.DistanceTo(Particles[j].Position);
                    double acceleration = G * (Particles[j].Mass) / Math.Pow(distance, 2);
                    double k_ad = acceleration / distance;
                    Particles[i].Speed = new Vector2(k_ad * (Particles[j].Position.X - Particles[i].Position.X), 
                                                      k_ad * (Particles[j].Position.Y - Particles[i].Position.Y));

                    Particles[j].Speed = new Vector2(k_ad * (Particles[i].Position.Y - Particles[j].Position.Y), 
                                                      k_ad * (Particles[i].Position.X - Particles[j].Position.X));
                    Particles[i].Position += Particles[i].Speed;
                    Particles[j].Position += Particles[j].Speed;
                    /*
                    if (Bound1 != null)
                    {
                        if (Particles[i].Position.X <= Bound1.X)
                        {
                            Particles[i].Position.X = Bound1.X + 1;
                            Particles[i].Speed.X = -Particles[i].Speed.X;
                        }
                        if (Particles[i].Position.Y <= Bound1.Y)
                        {
                            Particles[i].Position.Y = Bound1.Y + 1;
                            Particles[i].Speed.Y = -Particles[i].Speed.Y;
                        }

                        if (Particles[j].Position.X <= Bound1.X)
                        {
                            Particles[j].Position.X = Bound1.X + 1;
                            Particles[j].Speed.X = -Particles[j].Speed.X;
                        }
                        if (Particles[j].Position.Y <= Bound1.Y)
                        {
                            Particles[j].Position.Y = Bound1.Y + 1;
                            Particles[j].Speed.Y = -Particles[j].Speed.Y;
                        }
                    }
                    if (Bound2 != null)
                    {
                        if (Particles[i].Position.X >= Bound2.X)
                        {
                            Particles[i].Position.X = Bound2.X - 1;
                            Particles[i].Speed.X = -Particles[i].Speed.X;
                        }
                        if (Particles[i].Position.Y >= Bound2.Y)
                        {
                            Particles[i].Position.Y = Bound2.Y - 1;
                            Particles[i].Speed.X = -Particles[i].Speed.X;
                        }

                        if (Particles[j].Position.X >= Bound2.X)
                        {
                            Particles[j].Position.X = Bound2.X - 1;
                            Particles[j].Speed.X = -Particles[j].Speed.X;
                        }
                        if (Particles[j].Position.Y >= Bound2.Y)
                        {
                            Particles[j].Position.Y = Bound2.Y - 1;
                            Particles[j].Speed.Y = -Particles[j].Speed.Y;
                        }
                    }
                    */
                }
            }
        }

        /// <summary>
        /// Calculates one instant of movement asynchronously.
        /// </summary>
        public Task NextAsync()
        {
            return Task.CompletedTask;
        }
    }
}
