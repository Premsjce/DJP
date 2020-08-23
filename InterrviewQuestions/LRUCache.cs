using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Least Recently Used Cache
    /// </summary>
    public class LRUCache
    {
        public const int LRU_SIZE = 10;
        public Dictionary<int, Entry> HashMap { get; set; }
        private Entry Start, End;
        public LRUCache()
        {
            HashMap = new Dictionary<int, Entry>();
        }


        public void Drvier()
        {
            PutEntry(1, 1);
            PutEntry(10, 15);
            PutEntry(15, 10);
            PutEntry(10, 16);
            PutEntry(12, 15);
            PutEntry(18, 10);
            PutEntry(13, 16);

            Console.WriteLine(GetEntry(1));
            Console.WriteLine(GetEntry(10));
            Console.WriteLine(GetEntry(15));
        }


        public int GetEntry(int key)
        {
            if (!HashMap.ContainsKey(key))
                return -1;

            //If the hashmap has the entry then take that entry and move it to top and also return the value
            var entry = HashMap[key];
            RemoveEntry(entry);
            AddToTop(entry);
            return entry.Value;
        }

        public void PutEntry(int key, int value)
        {
            //Key already exists in the hashmap, then just update the entry to move it to top of list
            if (HashMap.ContainsKey(key))
            {
                Entry entry = HashMap[key];
                entry.Value = value;
                RemoveEntry(entry);
                AddToTop(entry);
                return;
            }

            Entry newNode = new Entry();
            newNode.Left = null;
            newNode.Right = null;
            newNode.Value = value;
            newNode.Key = key;

            if (HashMap.Count > LRU_SIZE)
            {
                HashMap.Remove(End.Key);
                RemoveEntry(End);
                AddToTop(newNode);
            }
            else
                AddToTop(newNode);

            HashMap.Add(key, newNode);
        }


        private void AddToTop(Entry entry)
        {
            entry.Right = Start;
            entry.Left = null;

            if (Start != null)
                Start.Left = entry;
            Start = entry;

            if (End == null)
                End = Start;
        }

        private void RemoveEntry(Entry entry)
        {
            if (entry.Left != null)
                entry.Left.Right = entry.Right;
            else
                Start = entry.Right;


            if (entry.Right != null)
                entry.Right.Left = entry.Left;
            else
                End = entry.Left;

        }
    }

    /// <summary>
    /// Doubly Linked List to hold the entries for updating/inserting and deleting in O(1) time
    /// </summary>
    public class Entry
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public Entry Left { get; set; }
        public Entry Right { get; set; }
    }
}
