using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Pixelplacement;

public class TileManager : Singleton<TileManager>
{
    public Grid Grid;
    [SerializeField]
    private Dictionary<Vector3Int, Tile> _tiles = new Dictionary<Vector3Int, Tile>();

    public TileAnimation PlacementAnimation;
    public TileAnimation NeighbourPlacedAnimation;

    public void AddTile(Tile tile, Vector3Int pos)
    {
        _tiles[pos] = tile;
        tile.SetPosition(pos);
    }

    [CanBeNull]
    public Tile GetTileAt(Vector3Int position)
    {
        return _tiles.ContainsKey(position) ? _tiles[position] : null;
    }

    
}
