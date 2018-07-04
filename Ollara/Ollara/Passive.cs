using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Passive : Perk
    {
        public Passive(String name, Effect effect, String description)
        {
            this.name = name;
            this.effect = effect;
            this.description = description;
        }

        private Effect effect;

        public override String Name { get { return name; } }
        public Effect Effect { get { return effect; } }
        public override String Description { get { return description; } }
    }

    enum Effect
    {
        HealBoost,
        DamageReflect,
    }
}
