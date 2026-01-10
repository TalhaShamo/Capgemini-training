using System;
using System.Collections.Generic;
namespace Module13_GenericClasses
{
    class StorageBox<T>
    {
        public T Item;
        public StorageBox(T item)
        {
            Item = item;
        }
        public void GetItem()
        {
            Console.WriteLine($"{Item}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Same class can be used to make a string item and int item. This is the power of a generic class. List<T> is also a type of generic
            StorageBox<string> sBox = new StorageBox<string>("Hello");
            StorageBox<int> iBox = new StorageBox<int>(100);
            sBox.GetItem();
            iBox.GetItem();
        }
    }
}