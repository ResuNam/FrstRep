using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    class Entity
    {
        public int Id;
        public int ParentId;
        public string Name;

        public Entity( int id, int pId, string name)
        {
            Id = id;
            ParentId = pId;
            Name = name;
        }
    }
}
