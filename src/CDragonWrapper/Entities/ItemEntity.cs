using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDragonWrapper.Entities
{
    public class ItemEntity
    {
        public ItemEntity(int id, string name, string icon)
        {
            Id = id;
            Name = name;
            Icon = icon;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        internal string Icon { get; private set; }
    }
}
