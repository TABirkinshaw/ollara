using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Weapon : Treasure
    {
        public Weapon(String name, WeaponType type, float damage, float accuracy, float criticalChance)
        {
            this.name = name;
            this.type = type;
            this.damage = damage;
            this.accuracy = accuracy;
            this.criticalChance = criticalChance;
        }

        private float damage;
        private float accuracy;
        private float criticalChance;
        private WeaponType type;

        public override String Name { get { return name; } }
        public float Damage { get { return damage; } }
        public float Accuracy { get { return accuracy; } }
        public float CriticalChance { get { return criticalChance; } }
        public WeaponType Type { get { return type; } }
    }

    enum WeaponType
    {
        Sword,
        Axe,
        Bow,
    }
}
