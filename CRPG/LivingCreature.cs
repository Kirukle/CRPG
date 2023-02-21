using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public class LivingCreature
    {
        public int CurrentHitPoints;
        public int maximumHitPoints;

        public LivingCreature(int currentHitPoints, int maximumHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            this.maximumHitPoints = maximumHitPoints;
        }

        public LivingCreature()
        {

        }
    }
}
