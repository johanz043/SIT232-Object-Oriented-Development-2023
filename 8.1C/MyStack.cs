using System;
using System.Collections.Generic;

namespace Practical_8_1
{

    public class MyStack<T>
    {
        private T[] array;
        public int Count { get; private set; }

        public MyStack(int capacity)
        {
            array = new T[capacity];
            this.Count = 0;
        }

        public void Push(T val)
        {
            if (Count < array.Length) array[Count++] = val;
            else throw new InvalidOperationException("The stack is out of capacity.");
        }

        public T Pop()
        {
            if (Count > 0) return array[--Count];
            else throw new InvalidOperationException("The stack is empty.");
        }
    }

}