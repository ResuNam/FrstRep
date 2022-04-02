using System;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Entity> 
            {
                new Entity(1, 0, "Root entity"),
                new Entity(2, 1, "Child of 1 entity"),
                new Entity(3, 1, "Child of 1 entity"),
                new Entity(4, 2, "Child of 2 entity"),
                new Entity(5, 4, "Child of 4 entity"),
            };

            var d = CreateDictionary(list);
            foreach (var item in d)
            {
                Console.Write($"Key = {item.Key}, Value = [ ");
                foreach (var child in item.Value)
                    Console.Write(' ' + child.Id.ToString());
                Console.WriteLine(" ]");
            }
        }
        public static Dictionary<int, List<Entity>> CreateDictionary(List<Entity> entities)
        {
            var dictionary = new Dictionary<int, List<Entity>>();
            foreach (var e in entities)
            {
                dictionary.TryAdd(e.ParentId, new List<Entity>());
                dictionary[e.ParentId].Add(e);
            }
            return dictionary;
        }
    }
}
