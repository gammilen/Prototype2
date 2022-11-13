using System.Collections.Generic;

namespace Subway
{
    public class PathNode<T>
    {
        public readonly T Station;
        public readonly PathNode<T> Parent;
        public int G;
        public int H;
        public int F;

        public PathNode(T station, PathNode<T> parent = null)
        {
            Station = station;
            Parent = parent;
        }

        public bool SourceEquals(T station)
        {
            return Station.Equals(station);
        }
    }

    



    public class Pathfinding<T>
    {
        private const int ConnectionStepValue = 2;
        private const int OneLineConnectionValue = 1;

        private readonly ILinedNodesInfoSource<T> _nodesInfo;
        private readonly List<PathNode<T>> _openNodes = new();
        private readonly List<PathNode<T>> _closedNodes = new();
        private readonly List<T> _currentPath = new();
        private PathNode<T> _currNode;

        public Pathfinding(ILinedNodesInfoSource<T> nodesInfo)
        {
            _nodesInfo = nodesInfo;
        }

        public IReadOnlyList<T> GetPath(T startStation, T endStation)
        {
            _currentPath.Clear();
            _closedNodes.Clear();
            _openNodes.Clear();
            _openNodes.Add(new PathNode<T>(startStation, null));
            
            while (_openNodes.Count > 0)
            {
                PrepareCurrentNode();
                if (_currNode.SourceEquals(endStation))
                {
                    FormPath();
                    break;
                }
                ProcessConnectedNodes();
            }
            return _currentPath;
        }

        private void ProcessConnectedNodes()
        {
            foreach (var connectedStation in _nodesInfo.GetConnected(_currNode.Station))
            {
                foreach (PathNode<T> n in _closedNodes)
                {
                    if (n.SourceEquals(connectedStation))
                    {
                        continue;
                    }
                }
                int nextG = _currNode.G + ConnectionStepValue;
                foreach (PathNode<T> n in _openNodes)
                {
                    if (n.SourceEquals(connectedStation) && nextG > n.G)
                    {
                        continue;
                    }
                }
                AddChildNode(connectedStation);
            }
        }

        private void AddChildNode(T station)
        {
            var child = new PathNode<T>(station, _currNode);
            child.G = _currNode.G + ConnectionStepValue;
            if (_currNode.Parent != null && _nodesInfo.IsOnOneLine(
                _currNode.Parent.Station, _currNode.Station, child.Station))
            {
                child.H = OneLineConnectionValue;
            }
            child.F = child.H + child.G;
            _openNodes.Add(child);
        }

        private void PrepareCurrentNode()
        {
            _currNode = _openNodes[0];
            foreach (PathNode<T> n in _openNodes)
            {
                if (n.F < _currNode.F)
                {
                    _currNode = n;
                }
            }
            _openNodes.Remove(_currNode);
            _closedNodes.Add(_currNode);
        }

        private void FormPath()
        {
            PathNode<T> current = _currNode;
            while (current != null)
            {
                _currentPath.Add(current.Station);
                current = current.Parent;
            }
            _currentPath.Reverse();
        }
    }
}