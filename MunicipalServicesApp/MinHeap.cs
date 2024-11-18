using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> elements = new List<T>();

        public int Size => elements.Count;

        public bool IsEmpty => elements.Count == 0;

        public void Insert(T item)
        {
            elements.Add(item);
            HeapifyUp(elements.Count - 1);
        }

        public T ExtractMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Heap is empty");

            T min = elements[0];
            elements[0] = elements[Size - 1];
            elements.RemoveAt(Size - 1);
            HeapifyDown(0);
            return min;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Heap is empty");

            return elements[0];
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (elements[index].CompareTo(elements[parentIndex]) >= 0)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            while (index * 2 + 1 < Size)
            {
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;
                int smallestChildIndex = leftChildIndex;

                if (rightChildIndex < Size && elements[rightChildIndex].CompareTo(elements[leftChildIndex]) < 0)
                {
                    smallestChildIndex = rightChildIndex;
                }

                if (elements[index].CompareTo(elements[smallestChildIndex]) <= 0)
                    break;

                Swap(index, smallestChildIndex);
                index = smallestChildIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = temp;
        }
    }
}
