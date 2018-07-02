using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Character : BaseUnit
    {
        public Character(String name, Race race, Background background)
        {

        }

        private Background background;
        private float might;
        private float finesse;
        private float astra;
        private float agility;
        private float toughness;
        private float acuity;
        private float empathy;
        private float contempt;

        public override String Name
        {
            get { return Name; }
        }

        public override Race Race
        {
            get { return Race; }
        }

        public override float Health
        {
            get { return Health; }
            set { Health = value; }
        }

        public override float Energy
        {
            get { return Energy; }
            set { Energy = value; }
        }

        public override float Luck
        {
            get { return Luck; }
        }

        public override float Panic
        {
            get { return Panic; }
            set { Panic = value; }
        }
    }
}
