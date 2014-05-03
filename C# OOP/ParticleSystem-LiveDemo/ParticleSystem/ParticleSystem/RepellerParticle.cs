using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class RepellerParticle : Particle
    {
        public int RepellPower { get; protected set; }
        public int RepellerRadius { get; protected set; }
        public RepellerParticle(MatrixCoords position, MatrixCoords speed, int repellPower, int radius) :
            base(position, speed)
        {
            this.RepellPower = repellPower;
            this.RepellerRadius = radius;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '@' } };
        }
    }
}
