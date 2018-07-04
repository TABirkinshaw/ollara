using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class StatBoost : Perk
    {
        public StatBoost(String name, Stat stat, float amount, String description)
        {
            this.name = name;
            this.stat = stat;
            this.amount = amount;
            this.description = description;
        }

        private Stat stat;
        private float amount;

        public override String Name { get { return name; } }
        public Stat Stat { get { return stat; } }
        public float Amount { get { return amount; } }
        public override String Description { get { return description; } }
    }

    enum Stat
    {
        Health,
        Energy,
        Luck,
        Might,
        Finesse,
        Astra,
        Agility,
        Toughness,
        Acuity,
        Empathy,
        Contempt,
    }
}
