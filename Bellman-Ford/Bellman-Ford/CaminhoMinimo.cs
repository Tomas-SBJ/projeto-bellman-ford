using System;

class Graph
{
	class Edge
	{
		public int src, dest, weight;
		public Edge()
		{
			src = dest = weight = 0;
		}
	};

	int V, E;
	Edge[] edge;

	Graph(int v, int e)
	{
		V = v;
		E = e;
		edge = new Edge[e];
		for (int i = 0; i < e; ++i)
			edge[i] = new Edge();
	}

	void BellmanFord(Graph graph, int src)
	{
		int V = graph.V, E = graph.E;
		int[] dist = new int[V];

		for (int i = 0; i < V; ++i)
			dist[i] = int.MaxValue;
		dist[src] = 0;

		for (int i = 1; i < V; ++i)
		{
			for (int j = 0; j < E; ++j)
			{
				int u = graph.edge[j].src;
				int v = graph.edge[j].dest;
				int weight = graph.edge[j].weight;
				if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
					dist[v] = dist[u] + weight;
			}
		}

		for (int j = 0; j < E; ++j)
		{
			int u = graph.edge[j].src;
			int v = graph.edge[j].dest;
			int weight = graph.edge[j].weight;

			if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
			{
				Console.WriteLine("Gráfico contém ciclo de peso negativo");
				return;
			}
		}
		printArr(dist, V);
	}

	void printArr(int[] dist, int V)
	{
		Console.WriteLine("Distância do vértice da fonte");
		for (int i = 0; i < V; ++i)
			Console.WriteLine(i + "\t\t" + dist[i]);
	}

	public static void Main()
	{
		int V = 5;
		int E = 9;

		Graph graph = new Graph(V, E);

		// A - B
		graph.edge[0].src = 0;
		graph.edge[0].dest = 1;
		graph.edge[0].weight = 4;

		// A - C
		graph.edge[1].src = 0;
		graph.edge[1].dest = 2;
		graph.edge[1].weight = 2;

		// B - C
		graph.edge[2].src = 1;
		graph.edge[2].dest = 2;
		graph.edge[2].weight = 3;

		// B - D
		graph.edge[3].src = 1;
		graph.edge[3].dest = 3;
		graph.edge[3].weight = 2;

		// B - E
		graph.edge[4].src = 1;
		graph.edge[4].dest = 4;
		graph.edge[4].weight = 3;

		// C - B
		graph.edge[5].src = 2;
		graph.edge[5].dest = 1;
		graph.edge[5].weight = 1;

		// C - D
		graph.edge[6].src = 2;
		graph.edge[6].dest = 3;
		graph.edge[6].weight = 4;

		// C - E 
		graph.edge[7].src = 2;
		graph.edge[7].dest = 4;
		graph.edge[7].weight = 5;

		// E - D
		graph.edge[8].src = 4;
		graph.edge[8].dest = 3;
		graph.edge[8].weight = -5;

		graph.BellmanFord(graph, 0);
	}
}