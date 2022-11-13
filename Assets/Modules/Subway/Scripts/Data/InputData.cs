using System.Collections.Generic;

namespace Subway
{
    public class InputData
    {
        public Dictionary<SubwayLine, HashSet<UnorderedValuePair<SubwayStation>>> GetSubwayGraph()
        {
            var a = new SubwayStation("A");
            var b = new SubwayStation("B");
            var c = new SubwayStation("C");
            var d = new SubwayStation("D");
            var e = new SubwayStation("E");
            var f = new SubwayStation("F");
            var g = new SubwayStation("G");
            var h = new SubwayStation("H");
            var j = new SubwayStation("J");
            var k = new SubwayStation("K");
            var l = new SubwayStation("L");
            var m = new SubwayStation("M");
            var n = new SubwayStation("N");
            var o = new SubwayStation("O");

            var graph = new Dictionary<SubwayLine, HashSet<UnorderedValuePair<SubwayStation>>>();
            graph.Add(new SubwayLine("Red"), CreateEdges(new[] { a, b, c, d, e, f }));
            graph.Add(new SubwayLine("Blue"), CreateEdges(new[] { o, j, d, l, n }));
            graph.Add(new SubwayLine("Green"), CreateEdges(new[] { c, k, l, m, e, j, c }));
            graph.Add(new SubwayLine("Black"), CreateEdges(new[] { b, h, j, f, g }));
            
            return graph;

            HashSet<UnorderedValuePair<SubwayStation>> CreateEdges(params SubwayStation[] stations)
            {
                if (stations.Length <= 0)
                {
                    throw new System.ArgumentException("Need at least two stations to create edges");
                }
                var res = new HashSet<UnorderedValuePair<SubwayStation>>();
                for (int i = 0; i < stations.Length - 1; i++)
                {
                    res.Add(new UnorderedValuePair<SubwayStation>(stations[i], stations[i + 1]));
                }
                return res;
            }
        }
    }
}