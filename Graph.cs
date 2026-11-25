public class Graph
{
    private Dictionary<int, List<int>> graph { get; set; }

    public Graph()
    {
        graph = new();
    }

    public void AddVertex(int v)
    {
        if (!graph.ContainsKey(v))
            graph[v] = new List<int>();
    }

    public void AddEdge(int u, int v)
    {
        if (u == v)
            return;

        if (HasEdge(u, v))
            return;

        AddVertex(u);
        AddVertex(v);

        graph[u].Add(v);
        graph[v].Add(u);
    }

    public bool HasEdge(int u, int v)
    {
        if (!graph.ContainsKey(u))
            return false;
        if (!graph.ContainsKey(v))
            return false;
        if (graph[u].Contains(v) || graph[v].Contains(u))
            return true;
        return false;
    }

    public void RemoveEdge(int u, int v)
    {
        if (!HasEdge(u, v))
            return;

        graph[u].Remove(v);
        graph[v].Remove(u);
    }

    public void RemoveVertex(int v)
    {
        if (!graph.ContainsKey(v))
            return;

        foreach (int neighbor in graph[v])
        {
            if (!graph.ContainsKey(neighbor))
                continue;
            graph[neighbor].Remove(v);
        }

        graph.Remove(v);
    }

    public void Print()
    {
        Dictionary<int, List<int>> orderedGraph;
        orderedGraph = graph.OrderBy(x => x.Key).ToDictionary();
        foreach (KeyValuePair<int, List<int>> adjList in graph)
        {
            int vertex = adjList.Key;
            string edges = $"[{string.Join(',', adjList.Value)}]";
            Console.WriteLine($"{vertex}: {edges}");
        }
    }

    public List<int> BFS(int start)
    {
        if (!graph.ContainsKey(start))
            return new List<int>();

        List<int> order = new();
        HashSet<int> visited = new();
        Queue<int> queue = new();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            order.Add(current);

            foreach (int neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return order;
    }

    public List<int> DFS(int start)
    {
        if (!graph.ContainsKey(start))
            return new List<int>();

        List<int> order = new();
        HashSet<int> visited = new();
        RDFS(start, order, visited);
        return order;
    }

    private void RDFS(int current, List<int> order, HashSet<int> visited)
    {
        visited.Add(current);
        order.Add(current);

        foreach (int neighbor in graph[current])
        {
            if (!visited.Contains(neighbor))
                RDFS(neighbor, order, visited);
        }
    }

    public List<int> ShortestPath(int from, int to)
    {
        Dictionary<int, int> parent = new();
        HashSet<int> visited = new();
        Queue<int> queue = new();

        queue.Enqueue(from);
        visited.Add(from);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            if (current == to)
                break;

            foreach (int neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return BuildPath(parent, from, to);
    }

    private List<int> BuildPath(Dictionary<int, int> parent, int from, int to)
    {
        List<int> path = new();

        if (from == to)
            return path;
        if (!parent.ContainsKey(to))
            return path;

        int step = to;
        while (step != from)
        {
            path.Add(step);
            step = parent[step];
        }
        path.Add(from);
        path.Reverse();
        return path;
    }

    public int CountPieces()
    {
        List<int> vertices = graph.Keys.ToList();
        HashSet<int> visited = new();
        int components = 0;

        foreach (int vertex in vertices)
        {
            if (!visited.Contains(vertex))
            {
                visited.UnionWith(BFS(vertex).ToHashSet());
                components++;
            }
        }

        return components;
    }

    public bool HasCycle()
    {
        HashSet<int> visited = new();
        return RHasCycle(graph.Keys.ToList()[0], null, visited);
    }

    private bool RHasCycle(int current, int? previous, HashSet<int> visited)
    {
        visited.Add(current);

        foreach (int neighbor in graph[current])
        {
            if (neighbor == previous)
                continue;
            if (visited.Contains(neighbor))
                return true;

            RHasCycle(neighbor, current, visited);
        }

        return false;
    }
}