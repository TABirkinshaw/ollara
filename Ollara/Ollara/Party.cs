using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Party
    {
        public Party()
        {
            partySize = 0;
            members = new List<Character>();
            panicSpreadMitigation = 0;
        }

        private int partySize;
        private List<Character> members;
        private float panicSpreadMitigation;

        public int PartySize
        {
            get { return partySize; }
        }

        public List<Character> PartyMembers
        {
            get { return members; }
        }

        public void AddMember(Character member)
        {
            members.Add(member);
            partySize++;
        }

        public float PanicSpreadMitigation
        {
            get
            {
                float spreadMitigation = 0;
                for (int i = 0; i < partySize-1; i++)
                {
                    spreadMitigation += members[i].Empathy;
                }
                return spreadMitigation;
            }
        }
    }
}
