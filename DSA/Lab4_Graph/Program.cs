using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Graph
{



    class Program
    {
        static void Main(string[] args)
        {
            Graph G = CreateGraph();
            G.Show();
            Console.WriteLine();

            // DFS
            DepthFirstSearch dfs = new DepthFirstSearch(G);
            List<int> path = dfs.VisitAll(0);

            Dictionary<int, char> vertexValueDictionary = CreateDictionaty();
            PrintResults(path, vertexValueDictionary);

            Console.WriteLine("\n");
            Console.WriteLine("After modification... \n");
            ModifyDictionary(vertexValueDictionary, path);
            PrintResults(path, vertexValueDictionary);


            Console.ReadLine();
        }

        private static void ModifyDictionary(Dictionary<int, char> vertexValueDictionary, List<int> path)
        {
            vertexValueDictionary.Clear();
            String name = "VladislavYak";
            for (int i = 0; i < name.Length; i++) vertexValueDictionary.Add(path[i], name[i]);
        }

        private static void PrintResults(List<int> path, Dictionary<int, char> vertexValueDictionary)
        {
            Console.WriteLine("Path: ");
            foreach (var vertex in path) Console.Write(vertex + " ");
            Console.WriteLine();
            Console.WriteLine("Path in letters: ");
            foreach (var vertex in path) Console.Write(vertexValueDictionary[vertex] + " ");
        }

        private static Dictionary<int, char> CreateDictionaty()
        {
            Dictionary<int, char> vertexValues = new Dictionary<int, char>();
            AddVertexValues(vertexValues);
            return vertexValues;
        }

        private static Graph CreateGraph()
        {
            Graph G = new Graph(14, 12);
            ConnectNodes(G);
            return G;
        }

        private static void AddVertexValues(Dictionary<int, char> vertexValues)
        {
            String name = "VladislavYak";
            for (int i = 0; i < name.Length; i++) vertexValues.Add(i, name[i]);
        }


        private static void ConnectNodes(Graph G)
        {
            G.Connect(0, 1);
            G.Connect(0, 5);
            G.Connect(1, 4);
            G.Connect(4, 8);

            G.Connect(5, 8);
            G.Connect(6, 9);
            G.Connect(5, 10);
            G.Connect(1, 2);
            G.Connect(6,3);

            G.Connect(7, 6);
            G.Connect(2, 3);
            G.Connect(7, 3);
            G.Connect(6, 11);
            G.Connect(7, 11);
        }
    }
}
