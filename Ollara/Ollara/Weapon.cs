using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Weapon
    {
        public Weapon()
        {
            
        }

        private float damage;
        private float accuracy;
        private float criticalChance;
        private WeaponType type;

        public float Damage
        {
            get { return damage; }
        }

        public float Accuracy
        {
            get { return accuracy; }
        }

        public float CriticalChance
        {
            get { return criticalChance; }
        }

        public WeaponType WeaponType
        {
            get { return type; }
        }
    }
}
