using System.Collections.Generic;
using System.Linq;

namespace Subway
{
    public class SubwayScheme
    {
        public readonly IReadOnlyDictionary<SubwayStation, IReadOnlyCollection<SubwayStation>> NodeEdges;
        public readonly IReadOnlyDictionary<UnorderedValuePair<SubwayStation>, SubwayLine> Edges;
        public IEnumerable<SubwayStation> Stations => NodeEdges.Keys;

        public SubwayScheme(Dictionary<SubwayLine, HashSet<UnorderedValuePair<SubwayStation>>> graph)
        {
            var nodesEdges = new Dictionary<SubwayStation, HashSet<SubwayStation>>();
            var edges = new Dictionary<UnorderedValuePair<SubwayStation>, SubwayLine>();
            foreach (var line in graph)
            {
                foreach (var edge in line.Value)
                {
                    AddNodeEdge(edge.ItemA, edge.ItemB);
                    AddNodeEdge(edge.ItemB, edge.ItemA);
                    edges.Add(edge, line.Key);
                }
            }
            NodeEdges = nodesEdges.ToDictionary(x => x.Key, x => (IReadOnlyCollection<SubwayStation>)x.Value);
            Edges = edges;

            void AddNodeEdge(SubwayStation stationFrom, SubwayStation stationTo)
            {
                if (!nodesEdges.ContainsKey(stationFrom))
                {
                    nodesEdges[stationFrom] = new HashSet<SubwayStation>();
                }
                if (!nodesEdges[stationFrom].Add(stationTo))
                {
                    throw new System.ArgumentException($"Duplicate connection between stations ({stationFrom.Name}, {stationTo.Name})");
                }
            }
        }
    }
}