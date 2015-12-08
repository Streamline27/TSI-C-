using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Graph
{
    class Graph
    {
        public int MaxEdges { get; private set; }
        public int MaxVertexes { get; private set; }

        private bool[,] Matrix { get; set; }
        private int EdgesAdded { get; set; }


        /* Constructor */
        public Graph(int maxEdges, int maxVertexes)
        {
            MaxEdges = maxEdges;
            MaxVertexes = maxVertexes;

            Matrix = new bool[MaxVertexes, MaxEdges];
        }

        /* Methods for geting Adjusted vertexes */
        public List<int> Adj(int vertex)
        {
            List<int> adjVertexes = new List<int>();
            for (int indexEdge = 0; indexEdge < MaxEdges; indexEdge++)
            {
                if (IsMarkedInMatrix(vertex, indexEdge)) AddAdjustedVertex(adjVertexes, vertex, indexEdge);
            }
            return adjVertexes;
        }

        private void AddAdjustedVertex(List<int> adjVertexes, int currentVertex, int checkedEdge)
        {
            for (int checkedVertex = 0; checkedVertex < MaxVertexes; checkedVertex++)
            {
                if (IsConnectedTo(currentVertex,  checkedVertex, checkedEdge)) adjVertexes.Add(checkedVertex);
            }
        }

        private bool IsConnectedTo(int currentVertex, int checkedVertex, int checkedEdge)
        {
            return (checkedVertex != currentVertex) && (IsMarkedInMatrix(checkedVertex, checkedEdge));
        }

        /* Misc methods */
        public void Connect(int vertex1, int vertex2)
        {
            if (EdgesAdded < MaxEdges)
            {
                Matrix[vertex1, EdgesAdded] = true;
                Matrix[vertex2, EdgesAdded] = true;
                EdgesAdded++;
            }
        }


        public void Show()
        {
            for (int edgeIndex = 0; edgeIndex < MaxEdges; edgeIndex++)
			{
                for (int vertexIndex = 0; vertexIndex < MaxVertexes; vertexIndex++)
                {
                    if (IsMarkedInMatrix(vertexIndex, edgeIndex)) Console.Write(" 1 ");
                    else Console.Write(" 0 ");
                }
                Console.WriteLine();
			}
        }

        /* Private helper methods */
        private bool IsMarkedInMatrix(int vertexIndex, int edgeIndex)
        {
            return Matrix[vertexIndex, edgeIndex];
        }




    }
}
