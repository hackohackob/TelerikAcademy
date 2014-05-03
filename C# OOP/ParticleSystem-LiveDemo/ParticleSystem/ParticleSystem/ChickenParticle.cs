using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChickenParticle: ChaoticParticle
    {
        public ChickenParticle(MatrixCoords position, MatrixCoords speed) :
            base(position, speed)
        {
        }

        private bool layingEggs;
        private byte counter = 5;
        protected override void Move()
        {
            if (this.layingEggs)
            {
                if (this.counter > 0)
                    this.counter--;
                else
                {
                    this.Update();
                }
            }
            else
            {
                base.Move();
            }
        }

        public override IEnumerable<Particle> Update()
        {
            if (layingEggs && counter == 0)
            {
                this.counter = 5;
                this.layingEggs = false;
                ChickenParticle littleChicken = new ChickenParticle( new MatrixCoords(this.Position.Row, this.Position.Col-1),
                    new MatrixCoords(this.Speed.Row,this.Speed.Col));
                return new List<Particle>(){littleChicken};
            }
            if (this.randomSpeed.Next(0, 10) < 2)
            {
                this.layingEggs = true;
                return base.Update();

            }
            else
            {
                return base.Update();
            }
           
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'c' } };
        }
    }
}
