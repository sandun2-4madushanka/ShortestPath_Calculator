using Amplifyn_Test_App.Models;

namespace Amplifyn_Test_App.Services
{
    public class PathFinder
    {
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graph)
        {

            if (string.IsNullOrEmpty(fromNodeName) || string.IsNullOrEmpty(toNodeName) || graph == null)
            {
                return new ShortestPathData(new List<string>(), int.MaxValue);
            }

            var invalidNodes = graph.Where(n => string.IsNullOrEmpty(n?.Name)).ToList();
            if (invalidNodes.Any())
            {
                return new ShortestPathData(new List<string>(), int.MaxValue);
            }

            var duplicates = graph
                .GroupBy(n => n.Name)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            if (duplicates.Any())
            {
                return new ShortestPathData(new List<string>(), int.MaxValue);
            }

            if (!graph.Any(n => n.Name == fromNodeName) || !graph.Any(n => n.Name == toNodeName))
            {
                return new ShortestPathData(new List<string>(), int.MaxValue);
            }

            var distances = graph.ToDictionary(n => n.Name, n => int.MaxValue);
            var previous = new Dictionary<string, string>();
            var visited = new HashSet<string>();

            distances[fromNodeName] = 0;

            while (visited.Count < graph.Count)
            {
                var current = distances
                    .Where(x => !visited.Contains(x.Key))
                    .OrderBy(x => x.Value)
                    .FirstOrDefault();

                if (current.Key == null || current.Value == int.MaxValue)
                    break;

                visited.Add(current.Key);
                if (current.Key == toNodeName)
                    break;

                var currentNode = graph.First(n => n.Name == current.Key);
                foreach (var edge in currentNode.Edges)
                {
                    int newDist = distances[current.Key] + edge.Distance;
                    if (newDist < distances[edge.ToNode.Name])
                    {
                        distances[edge.ToNode.Name] = newDist;
                        previous[edge.ToNode.Name] = current.Key;
                    }
                }
            }

            var path = new List<string>();
            var node = toNodeName;
            while (node != null && previous.ContainsKey(node))
            {
                path.Insert(0, node);
                node = previous[node];
            }
            if (node == fromNodeName)
                path.Insert(0, fromNodeName);

            var totalDistance = distances[toNodeName];
            return new ShortestPathData(path, totalDistance);
        }
    }
}
