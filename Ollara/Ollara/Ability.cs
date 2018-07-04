using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Ability : Perk
    {
        public Ability(String name, float power, float accuracy, float cost, String description)
        {
            this.name = name;
            this.power = power;
            this.accuracy = accuracy;
            this.cost = cost;
            this.description = description;
        }

        private float power;
        private float accuracy;
        private float cost;

        public override String Name { get { return name; } }
        public float Power { get { return power; } }
        public float Accuracy { get { return accuracy; } }
        public float Cost { get { return cost; } }
        public override String Description { get { return description; } }
    }
}
