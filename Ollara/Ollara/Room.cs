using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Room
    {
        public Room(Portal leftPortal, Portal middlePortal, Portal rightPortal)
        {
            this.leftPortal = leftPortal;
            this.middlePortal = middlePortal;
            this.rightPortal = rightPortal;
        }

        private Portal leftPortal;
        private Portal middlePortal;
        private Portal rightPortal;

        public Portal LeftPortal
        {
            get { return leftPortal; }
            set { leftPortal = value; }
        }

        public Portal MiddlePortal
        {
            get { return middlePortal; ; }
            set { middlePortal = value; }
        }

        public Portal RightPortal
        {
            get { return rightPortal; }
            set { rightPortal = value; }
        }
    }
}
