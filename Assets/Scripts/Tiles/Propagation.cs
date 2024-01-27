using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public static class Propagation
    {
        public static Dictionary<int, List<Vector3Int>> GetDistances(Vector3Int origin)
        {
            var tileManager = TileManager.Instance;
            var visited = new HashSet<Vector3Int>{origin};
            var distances = new Dictionary<int, List<Vector3Int>>();
            var queue = new List<(Vector3Int, int)> { (origin, 0) };

            while (queue.Count > 0)
            {
                var (pos, dist) = queue[0];
                queue.RemoveAt(0);

                foreach (var neighbourPos in tileManager.GetTileAt(pos)!.NeighbourPositions)
                {
                    if (visited.Contains(neighbourPos) || tileManager.GetTileAt(neighbourPos) is null) continue;
                    
                    if (!distances.ContainsKey(dist + 1))
                    {
                        distances.Add(dist + 1, new List<Vector3Int>());
                    }

                    visited.Add(neighbourPos);
                    distances[dist + 1].Add(neighbourPos);
                    queue.Add((neighbourPos, dist + 1));
                }
            }

            return distances;
        }
    }
}