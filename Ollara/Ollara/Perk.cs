using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    abstract class Perk
    {
        protected String name;
        protected String description;

        public abstract String Name { get; }
        public abstract String Description { get; }
    }
}
