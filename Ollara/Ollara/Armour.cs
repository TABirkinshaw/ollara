using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Armour
    {
        public Armour()
        {

        }

        private float physicalDefence;
        private float spellResistance;
        private float dodge;

        public float PhysicalDefence
        {
            get { return physicalDefence; }
        }

        public float SpellResistance
        {
            get { return spellResistance; }
        }

        public float Dodge
        {
            get { return dodge; }
        }
    }
}
