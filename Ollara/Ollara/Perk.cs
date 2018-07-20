using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    abstract class Perk : Treasure
    {
        protected String description;

        public abstract String Description { get; }
    }
}
