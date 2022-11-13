using System.Collections.Generic;

namespace Subway
{
    public interface ILinedNodesInfoSource<T>
    {
        IReadOnlyCollection<T> GetConnected(T node);
        bool IsOnOneLine(T prev, T curr, T next);
    }
}