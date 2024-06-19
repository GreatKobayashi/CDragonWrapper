using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDragonWrapper.Entities
{
    public class SummonerSpellEntity
    {
        public SummonerSpellEntity(uint id, string name, string icon)
        {
            Id = id;
            Name = name;
            Icon = icon;
        }

        public uint Id { get; private set; }
        public string Name { get; private set; }
        internal string Icon { get; private set; }
    }
}
