using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expressions_and_Generics
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

        public T Find(Func<T, bool> criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));
            for (int i = Count - 1; i >= 0; i--)
            {
                if (criteria(array[i])) return array[i];
            }
            return default(T);
        }

        public T[] FindAll(Func<T, bool> criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));
            List<T> result = new List<T>();
            for (int i = Count - 1; i >= 0; i--)
            {
                if (criteria(array[i])) result.Add(array[i]);
            }
            return result.ToArray();
        }

        public int RemoveAll(Func<T, bool> criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));
            int removedCount = 0;
            for (int i = Count - 1; i >= 0; i--)
            {
                if (criteria(array[i]))
                {
                    Array.Copy(array, i + 1, array, i, Count - i - 1);
                    Count--;
                    removedCount++;
                }
            }
            return removedCount;
        }

        public T Max()
        {
            if (Count == 0) return default(T);
            Comparer<T> comparer = Comparer<T>.Default;
            T max = array[0];
            for (int i = 1; i < Count; i++)
            {
                if (comparer.Compare(array[i], max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public T Min()
        {
            if (Count == 0) return default(T);
            Comparer<T> comparer = Comparer<T>.Default;
            T min = array[0];
            for (int i = 1; i < Count; i++)
            {
                if (comparer.Compare(array[i], min) < 0)
                {
                    min = array[i];
                }
            }
            return min;
        }
        }
}
