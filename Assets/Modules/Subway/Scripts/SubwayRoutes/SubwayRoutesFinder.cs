using System.Collections.Generic;

namespace Subway
{
    public class SubwayRoutesFinder
    {
        private readonly SubwayRoutes _routes;
        private readonly SubwayScheme _scheme;
        private readonly Pathfinding<SubwayStation> _pathfinding;
        public IEnumerable<SubwayStation> Stations => _scheme.Stations;

        public SubwayRoutesFinder()
        {
            var input = new InputData();
            _scheme = new SubwayScheme(input.GetSubwayGraph());
            _routes = new SubwayRoutes(_scheme);
            _pathfinding = new Pathfinding<SubwayStation>(_routes);
        }

        public IReadOnlyList<SubwayStation> GetPath(SubwayStation stationA, SubwayStation stationB, 
            out int transfersCount)
        {
            var path = _pathfinding.GetPath(stationA, stationB);
            transfersCount = _routes.GetTransfersCount(path);
            return path;
        }
    }
}