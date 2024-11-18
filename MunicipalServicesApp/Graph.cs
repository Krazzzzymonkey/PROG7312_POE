using System;
using System.Collections.Generic;

// ST10067040
namespace MunicipalServicesApp
{
    public class Graph<T>
    {
        private readonly Dictionary<T, List<T>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<T, List<T>>();
        }

        public void AddNode(T node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList[node] = new List<T>();
            }
        }

        public void AddEdge(T from, T to)
        {
            if (!adjacencyList.ContainsKey(from))
            {
                AddNode(from);
            }

            if (!adjacencyList.ContainsKey(to))
            {
                AddNode(to);
            }

            adjacencyList[from].Add(to);
        }

        public List<T> GetDependencies(T node)
        {
            return adjacencyList.ContainsKey(node) ? adjacencyList[node] : new List<T>();
        }

        public void TraverseDFS(T startNode, Action<T> action)
        {
            var visited = new HashSet<T>();
            DFS(startNode, action, visited);
        }

        private void DFS(T current, Action<T> action, HashSet<T> visited)
        {
            if (visited.Contains(current))
            {
                return;
            }

            action(current);
            visited.Add(current);

            foreach (var neighbor in GetDependencies(current))
            {
                DFS(neighbor, action, visited);
            }
        }

        public List<T> TraverseBFS(T startNode)
        {
            var visited = new List<T>();
            var queue = new Queue<T>();

            if (adjacencyList.ContainsKey(startNode))
            {
                queue.Enqueue(startNode);
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    foreach (var neighbor in GetDependencies(current))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return visited;
        }

        public List<T> GetNodes()
        {
            return new List<T>(adjacencyList.Keys);
        }

        public List<T> GetEdges(T node)
        {
            return adjacencyList.ContainsKey(node) ? adjacencyList[node] : new List<T>();
        }
    }



}
