using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class PlaceTile : MonoBehaviour
{
    private Tile _tile;
    [SerializeField] private GameObject _tilePrefab;

    public void Start()
    {
        _tile = GetComponent<Tile>();
    }

    private void OnMouseDown()
    {
        var obj = Instantiate(_tilePrefab, TileManager.Instance.Grid.transform, true);
        var tile = obj.GetComponent<Tile>();
        TileManager.Instance.AddTile(tile, _tile.Position);
        TileManager.Instance.PlacementAnimation.Animate(tile);

        var distances = Propagation.GetDistances(tile.Position);

        foreach (var (distance, positions) in distances)
        {
            foreach(var pos in positions)
            {
                var neighbourTile = TileManager.Instance.GetTileAt(pos);
                TileManager.Instance.NeighbourPlacedAnimation.Animate(neighbourTile, 0.05f * distance);
            }
        }
    }
}
