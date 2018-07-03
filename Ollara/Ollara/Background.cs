using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Background
    {
        public Background(String name, float[] attributes, String description)
        {
            this.name = name;
            this.health = attributes[0];
            this.energy = attributes[1];
            this.might = attributes[2];
            this.finesse = attributes[3];
            this.astra = attributes[4];
            this.agility = attributes[5];
            this.toughness = attributes[6];
            this.acuity = attributes[7];
            this.empathy = attributes[8];
            this.contempt = attributes[9];
            this.description = description;
        }

        private String name;
        private float health;
        private float energy;
        private float might;
        private float finesse;
        private float astra;
        private float agility;
        private float toughness;
        private float acuity;
        private float empathy;
        private float contempt;
        private String description;

        public String Name { get { return name; } }
        public float Health { get { return health; } }
        public float Energy { get { return energy; } }
        public float Might { get { return might; } }
        public float Finesse { get { return finesse; } }
        public float Astra { get { return astra; } }
        public float Agility { get { return agility; } }
        public float Toughness { get { return toughness; } }
        public float Acuity { get { return acuity; } }
        public float Empathy { get { return empathy; } }
        public float Contempt { get { return contempt; } }
        public String Description { get { return description; } }
    }
}
