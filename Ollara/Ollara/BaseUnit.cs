using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    abstract class BaseUnit
    {
        protected String name;
        protected Race race;
        protected float health;
        protected float energy;
        protected float luck;
        protected float panic;

        public abstract String Name { get; }
        public abstract Race Race { get; }
        public abstract float Health { get; set; }
        public abstract float Energy { get; set; }
        public abstract float Luck { get; set; }
        public abstract float Panic { get; set; }
    }
}
