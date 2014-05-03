using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class AdvancedParticleOperationExtension : AdvancedParticleOperator
    {
        private List<RepellerParticle> currentTickRepellers = new List<RepellerParticle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialRepeller = p as RepellerParticle;
            if (potentialRepeller != null)
            {
                currentTickRepellers.Add(potentialRepeller);
            }
            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.currentTickRepellers)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    var currParticleToRepellerVector = particle.Position - repeller.Position;
                    var distance = Math.Sqrt(Math.Pow(currParticleToRepellerVector.Row, 2) +
                        Math.Pow(currParticleToRepellerVector.Col, 2));

                    if (distance <= repeller.RepellerRadius)
                    {

                        int pToAttrRow = currParticleToRepellerVector.Row;
                        pToAttrRow = DefineAcceleration(repeller, pToAttrRow);

                        int pToAttrCol = currParticleToRepellerVector.Col;
                        pToAttrCol = DefineAcceleration(repeller, pToAttrCol);

                        var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.currentTickRepellers.Clear();


            base.TickEnded();
        }

        private static int DefineAcceleration(RepellerParticle repeller, int pToAttrCoord)
        {
            if (pToAttrCoord == 0)
                return 0;
            pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * repeller.RepellPower;

            return pToAttrCoord;
        }
    }
}
