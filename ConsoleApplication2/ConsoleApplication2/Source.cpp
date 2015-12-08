#include<iostream>
#include <list>
#include<vector>
using namespace std;


class Graph
{
	int V;
	list<int> *adj;
	vector<int> DFSUtil(int v, bool visited[]);
	vector<int> path;
public:
	Graph(int V);
	void addEdge(int v, int w);
	vector<int> DFS();
};

Graph::Graph(int V)
{
	vector<int> path(12);
	this->V = V;
	adj = new list<int>[V];
}

void Graph::addEdge(int v, int w)
{
	adj[v].push_back(w);
}

vector<int> Graph::DFSUtil(int v, bool visited[])
{
	
	visited[v] = true;
	cout << v << " ";
	path.push_back(v);

	list<int>::iterator i;
	for (i = adj[v].begin(); i != adj[v].end(); ++i) if (!visited[*i]) DFSUtil(*i, visited);
	return path;
}

vector<int> Graph::DFS()
{

	bool *visited = new bool[V];
	for (int i = 0; i < V; i++)
		visited[i] = false;

	for (int i = 0; i < V; i++)
	if (visited[i] == false)
	return DFSUtil(i, visited);
}

int main()
{

	Graph g(12);
	g.addEdge(0, 1);
	g.addEdge(0, 4);

	g.addEdge(1, 0);
	g.addEdge(1, 4);
	g.addEdge(1, 6);

	g.addEdge(2, 3);
	g.addEdge(2, 7);

	g.addEdge(3, 2);
	g.addEdge(3, 7);

	g.addEdge(4, 0);
	g.addEdge(4, 1);
	g.addEdge(4, 5);
	g.addEdge(4, 9);

	g.addEdge(5, 4);

	g.addEdge(6, 1);
	g.addEdge(6, 9);
	g.addEdge(6, 11);

	g.addEdge(7, 2);
	g.addEdge(7, 3);
	g.addEdge(7, 10);
	g.addEdge(7, 11);

	g.addEdge(8, 9);

	g.addEdge(9, 4);
	g.addEdge(9, 6);
	g.addEdge(9, 8);

	g.addEdge(10, 7);

	g.addEdge(11, 6);
	g.addEdge(11, 7);



	cout << "Following is Depth First Traversal \n";
	vector<int> path = g.DFS();

	char name[] = "ArtursStorhs";
	for (size_t i = 0; i < path.size(); i++)
	{
		cout << name[path[i]];
	}
	char reasignedName[12];
	for (size_t i = 0; i < path.size(); i++)
	{
		
		reasignedName[path[i]] = name[i];
	}
	for (size_t i = 0; i < path.size(); i++)
	{
		cout << reasignedName[path[i]];
	}


	cout << endl;
	system("PAUSE");
	return 0;
}

