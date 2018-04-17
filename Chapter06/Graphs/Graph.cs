/* Exemplary file for Chapter 6 - Exploring Graphs. */

using Priority_Queue;
using System;
using System.Collections.Generic;

namespace Graphs
{
    public class Graph<T>
    {
        #region Implementation
        private bool _isDirected = false;
        private bool _isWeighted = false;
        public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

        public Edge<T> this[int from, int to]
        {
            get
            {
                Node<T> nodeFrom = Nodes[from];
                Node<T> nodeTo = Nodes[to];
                int i = nodeFrom.Neighbors.IndexOf(nodeTo);
                if (i >= 0)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From = nodeFrom,
                        To = nodeTo,
                        Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
                    };
                    return edge;
                }

                return null;
            }
        }

        public Graph(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }

        public Node<T> AddNode(T value)
        {
            Node<T> node = new Node<T>() { Data = value };
            Nodes.Add(node);
            UpdateIndices();
            return node;
        }

        public void AddEdge(Node<T> from, Node<T> to, int weight = 0)
        {
            from.Neighbors.Add(to);
            if (_isWeighted)
            {
                from.Weights.Add(weight);
            }

            if (!_isDirected)
            {
                to.Neighbors.Add(from);
                if (_isWeighted)
                {
                    to.Weights.Add(weight);
                }
            }
        }

        public void RemoveNode(Node<T> nodeToRemove)
        {
            Nodes.Remove(nodeToRemove);
            UpdateIndices();
            foreach (Node<T> node in Nodes)
            {
                RemoveEdge(node, nodeToRemove);
            }
        }

        public void RemoveEdge(Node<T> from, Node<T> to)
        {
            int index = from.Neighbors.FindIndex(n => n == to);
            if (index >= 0)
            {
                from.Neighbors.RemoveAt(index);
                from.Weights.RemoveAt(index);
            }
        }

        public List<Edge<T>> GetEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            foreach (Node<T> from in Nodes)
            {
                for (int i = 0; i < from.Neighbors.Count; i++)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From = from,
                        To = from.Neighbors[i],
                        Weight = i < from.Weights.Count ? from.Weights[i] : 0
                    };
                    edges.Add(edge);
                }
            }
            return edges;
        }

        private void UpdateIndices()
        {
            int i = 0;
            Nodes.ForEach(n => n.Index = i++);
        }
        #endregion

        #region Minimum Spanning Tree (Kruskal)
        // The presented code is based on the implementation shown at:
        // https://www.geeksforgeeks.org/greedy-algorithms-set-2-kruskals-minimum-spanning-tree-mst/
        public List<Edge<T>> MinimumSpanningTreeKruskal()
        {
            List<Edge<T>> edges = GetEdges();
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
            Queue<Edge<T>> queue = new Queue<Edge<T>>(edges);

            Subset<T>[] subsets = new Subset<T>[Nodes.Count];
            for (int i = 0; i < Nodes.Count; i++)
            {
                subsets[i] = new Subset<T>() { Parent = Nodes[i] };
            }

            List<Edge<T>> result = new List<Edge<T>>();
            while (result.Count < Nodes.Count - 1)
            {
                Edge<T> edge = queue.Dequeue();
                Node<T> from = GetRoot(subsets, edge.From);
                Node<T> to = GetRoot(subsets, edge.To);
                if (from != to)
                {
                    result.Add(edge);
                    Union(subsets, from, to);
                }
            }

            return result;
        }

        private Node<T> GetRoot(Subset<T>[] subsets, Node<T> node)
        {
            if (subsets[node.Index].Parent != node)
            {
                subsets[node.Index].Parent = GetRoot(
                    subsets,
                    subsets[node.Index].Parent);
            }

            return subsets[node.Index].Parent;
        }

        private void Union(Subset<T>[] subsets, Node<T> a, Node<T> b)
        {
            if (subsets[a.Index].Rank > subsets[b.Index].Rank)
            {
                subsets[b.Index].Parent = a;
            }
            else if (subsets[a.Index].Rank < subsets[b.Index].Rank)
            {
                subsets[a.Index].Parent = b;
            }
            else
            {
                subsets[b.Index].Parent = a;
                subsets[a.Index].Rank++;
            }
        }
        #endregion

        #region Minimum Spanning Tree (Prim)
        // The presented code is based on the implementation shown at:
        // https://www.geeksforgeeks.org/greedy-algorithms-set-5-prims-minimum-spanning-tree-mst-2/
        public List<Edge<T>> MinimumSpanningTreePrim()
        {
            int[] previous = new int[Nodes.Count];
            previous[0] = -1;

            int[] minWeight = new int[Nodes.Count];
            Fill(minWeight, int.MaxValue);
            minWeight[0] = 0;

            bool[] isInMST = new bool[Nodes.Count];
            Fill(isInMST, false);

            for (int i = 0; i < Nodes.Count - 1; i++)
            {
                int minWeightIndex = GetMinimumWeightIndex(minWeight, isInMST);
                isInMST[minWeightIndex] = true;

                for (int j = 0; j < Nodes.Count; j++)
                {
                    Edge<T> edge = this[minWeightIndex, j];
                    int weight = edge != null ? edge.Weight : -1;
                    if (!isInMST[j]
                        && weight > 0
                        && weight < minWeight[j])
                    {
                        previous[j] = minWeightIndex;
                        minWeight[j] = weight;
                        Console.WriteLine(" --> " + edge.ToString());
                    }
                }
            }

            List<Edge<T>> result = new List<Edge<T>>();
            for (int i = 1; i < Nodes.Count; i++)
            {
                Edge<T> edge = this[previous[i], i];
                result.Add(edge);
            }
            return result;
        }

        private int GetMinimumWeightIndex(int[] weights, bool[] isInMST)
        {
            int minValue = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (!isInMST[i] && weights[i] < minValue)
                {
                    minValue = weights[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
        #endregion

        #region Shortest Path
        public List<Edge<T>> GetShortestPathDijkstra(Node<T> source, Node<T> target)
        {
            int[] previous = new int[Nodes.Count];
            Fill(previous, -1);

            int[] distances = new int[Nodes.Count];
            Fill(distances, int.MaxValue);
            distances[source.Index] = 0;

            SimplePriorityQueue<Node<T>> nodes = new SimplePriorityQueue<Node<T>>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                nodes.Enqueue(Nodes[i], distances[i]);
            }

            while (nodes.Count != 0)
            {
                Node<T> node = nodes.Dequeue();
                for (int i = 0; i < node.Neighbors.Count; i++)
                {
                    Node<T> neighbor = node.Neighbors[i];
                    int weight = i < node.Weights.Count ? node.Weights[i] : 0;
                    int weightTotal = distances[node.Index] + weight;

                    if (distances[neighbor.Index] > weightTotal)
                    {
                        distances[neighbor.Index] = weightTotal;
                        previous[neighbor.Index] = node.Index;
                        nodes.UpdatePriority(neighbor, distances[neighbor.Index]);
                    }
                }
            }

            List<int> indices = new List<int>();
            int index = target.Index;
            while (index >= 0)
            {
                indices.Add(index);
                index = previous[index];
            }

            indices.Reverse();
            List<Edge<T>> result = new List<Edge<T>>();
            for (int i = 0; i < indices.Count - 1; i++)
            {
                Edge<T> edge = this[indices[i], indices[i + 1]];
                result.Add(edge);
            }
            return result;
        }
        #endregion

        #region Coloring
        // The presented code is based on the implementation shown at:
        // https://www.geeksforgeeks.org/graph-coloring-set-2-greedy-algorithm/
        public int[] Color()
        {
            int[] colors = new int[Nodes.Count];
            Fill(colors, -1);
            colors[0] = 0;

            bool[] availability = new bool[Nodes.Count];
            for (int i = 1; i < Nodes.Count; i++)
            {
                Fill(availability, true);

                int colorIndex = 0;
                foreach (Node<T> neighbor in Nodes[i].Neighbors)
                {
                    colorIndex = colors[neighbor.Index];
                    if (colorIndex >= 0)
                    {
                        availability[colorIndex] = false;
                    }
                }

                colorIndex = 0;
                for (int j = 0; j < availability.Length; j++)
                {
                    if (availability[j])
                    {
                        colorIndex = j;
                        break;
                    }
                }

                colors[i] = colorIndex;
            }

            return colors;
        }
        #endregion

        #region Auxiliary
        private void Fill<Q>(Q[] array, Q value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
        #endregion

        #region Traversal
        public List<Node<T>> DFS()
        {
            bool[] isExplored = new bool[Nodes.Count];
            List<Node<T>> result = new List<Node<T>>();
            DFS(isExplored, Nodes[0], result);
            return result;
        }

        private void DFS(bool[] isExplored, Node<T> node, List<Node<T>> result)
        {
            result.Add(node);
            isExplored[node.Index] = true;

            foreach (Node<T> neighbor in node.Neighbors)
            {
                if (!isExplored[neighbor.Index])
                {
                    DFS(isExplored, neighbor, result);
                }
            }
        }

        public List<Node<T>> BFS()
        {
            return BFS(Nodes[0]);
        }

        // The presented code is based on the implementation shown at:
        // https://www.geeksforgeeks.org/breadth-first-traversal-for-a-graph/.
        private List<Node<T>> BFS(Node<T> node)
        {
            bool[] isExplored = new bool[Nodes.Count];
            List<Node<T>> result = new List<Node<T>>();
            isExplored[node.Index] = true;

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                Node<T> next = queue.Dequeue();
                result.Add(next);

                foreach (Node<T> neighbor in next.Neighbors)
                {
                    if (!isExplored[neighbor.Index])
                    {
                        isExplored[neighbor.Index] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
