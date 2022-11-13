using System.Collections.Generic;

namespace Subway
{
    public class SubwayRoutes : ILinedNodesInfoSource<SubwayStation>
    {
        private readonly SubwayScheme _scheme;

        public SubwayRoutes(SubwayScheme scheme)
        {
            _scheme = scheme;
        }

        public int GetTransfersCount(IReadOnlyList<SubwayStation> route)
        {
            if (route.Count <= 2)
            {
                return 0;
            }
            int count = 0;
            var pair = new UnorderedValuePair<SubwayStation>(route[0], route[1]);
            SubwayLine currLine = _scheme.Edges[pair];
            for (int i = 1; i < route.Count - 1; i++)
            {
                pair = new UnorderedValuePair<SubwayStation>(route[i], route[i + 1]);
                var line = _scheme.Edges[pair];
                if (!line.Equals(currLine))
                {
                    count++;
                    currLine = line;
                }
            }
            return count;
        }

        public IReadOnlyCollection<SubwayStation> GetConnected(SubwayStation station)
        {
            return _scheme.NodeEdges[station];
        }

        public bool IsOnOneLine(SubwayStation prevStation, SubwayStation currStation, SubwayStation nextStation)
        {
            var toCurr = new UnorderedValuePair<SubwayStation>(prevStation, currStation);
            var toNext = new UnorderedValuePair<SubwayStation>(currStation, nextStation);
            return _scheme.Edges[toCurr].Equals(_scheme.Edges[toNext]);
        }
    }
}