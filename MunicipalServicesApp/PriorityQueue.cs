using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<(T Item, int Priority)> heap;

    public PriorityQueue()
    {
        heap = new List<(T, int)>();
    }

    public void Enqueue(T item, int priority)
    {
        heap.Add((item, priority));
        int currentIndex = heap.Count - 1;

        // Bubble up to maintain heap property
        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            if (heap[currentIndex].Priority >= heap[parentIndex].Priority)
            {
                break;
            }

            (heap[currentIndex], heap[parentIndex]) = (heap[parentIndex], heap[currentIndex]);
            currentIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("The priority queue is empty.");
        }

        T result = heap[0].Item;

        // Move the last item to the root and bubble down
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        int currentIndex = 0;
        while (true)
        {
            int leftChild = 2 * currentIndex + 1;
            int rightChild = 2 * currentIndex + 2;
            int smallestIndex = currentIndex;

            if (leftChild < heap.Count && heap[leftChild].Priority < heap[smallestIndex].Priority)
            {
                smallestIndex = leftChild;
            }

            if (rightChild < heap.Count && heap[rightChild].Priority < heap[smallestIndex].Priority)
            {
                smallestIndex = rightChild;
            }

            if (smallestIndex == currentIndex)
            {
                break;
            }

            (heap[currentIndex], heap[smallestIndex]) = (heap[smallestIndex], heap[currentIndex]);
            currentIndex = smallestIndex;
        }

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var (Item, _) in heap)
        {
            yield return Item;
        }
    }

    public int Count => heap.Count;
}
