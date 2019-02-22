using System;
using System.Collections.Generic;
using System.Text;

namespace NBodySim.Core
{

    interface IParticle<T> where T: IVector
    {
        /// <summary>
        /// Gets or sets the mass.
        /// </summary>
        double Mass { get; set; }

        /// <summary>
        /// Gets or sets the position vector.
        /// </summary>
        T Position { get; set; }

        /// <summary>
        /// Gets or sets the speed vector.
        /// </summary>
        T Speed { get; set; }
    }
}
