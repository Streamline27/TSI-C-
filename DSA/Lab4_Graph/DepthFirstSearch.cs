using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Graph
{
    class DepthFirstSearch
    {
        private int NumEdges { get; set; }
        private int NumVertexes { get; set; }

        Graph G;
        HashSet<int> Visited { get; set; }


        public DepthFirstSearch(Graph G)//
        {
            this.G = G;
            NumEdges = G.MaxEdges;
            NumVertexes = G.MaxVertexes;

            Visited = new HashSet<int>();
        }

        public List<int> VisitAll(int startPoint)
        {
            List<int> path = new List<int>();
            Stack<int> nodesToVisit = new Stack<int>();

            nodesToVisit.Push(startPoint);
            while (ContainsUnvisitedNodes(nodesToVisit))
            {
                int currentNode = nodesToVisit.Pop();
                if (IsNotVisited(currentNode)) path.Add(currentNode);
                MarkAsVisited(currentNode);
                PushUnvisitedAdjustedNodes(currentNode , nodesToVisit );
            }
            return path;
        }

        private void PushUnvisitedAdjustedNodes(int currentNode , Stack<int> nodesToVisit)
        {
            List<int> adjNodes = G.Adj(currentNode);
            SortAndReverseCequence(adjNodes);
            foreach (var node in adjNodes) if (IsNotVisited(node)) nodesToVisit.Push(node);
        }

        private static void SortAndReverseCequence(List<int> adjNodes)
        {
            adjNodes.Sort();
            adjNodes.Reverse();
        }

        private bool IsNotVisited(int node)
        {
            return !Visited.Contains(node);
        }

        private void MarkAsVisited(int currentNode)
        {
            Visited.Add(currentNode);
        }

        private static bool ContainsUnvisitedNodes(Stack<int> nodesToVisit)
        {
            return (nodesToVisit.Count != 0);
        }

    }
}
