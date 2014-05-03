using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed) :
            base(position, speed)
        {
        }
        public Random randomSpeed = new Random();
        protected override void Move()
        {
            this.Speed = new MatrixCoords(randomSpeed.Next(-3, 3), randomSpeed.Next(-3, 3));
            base.Move();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '&' } };
        }

      
    }
}
