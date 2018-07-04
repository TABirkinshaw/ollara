using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Weapon
    {
        public Weapon(String name, WeaponType type, float damage, float accuracy, float criticalChance)
        {
            this.name = name;
            this.type = type;
            this.damage = damage;
            this.accuracy = accuracy;
            this.criticalChance = criticalChance;
        }

        private String name;
        private float damage;
        private float accuracy;
        private float criticalChance;
        private WeaponType type;

        public String Name { get { return name; } }
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
