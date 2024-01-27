using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

[CreateAssetMenu(menuName = "Tiles/Animations/NeighbourPlaced")]
public class NeighbourPlaced : TileAnimation
{
    [SerializeField] private float distance_below;
    [SerializeField] private float delay;
    [SerializeField] private float duration_down;
    [SerializeField] private float duration_up;
    
    public override void Animate(Tile tile, float addedDelay = 0)
    {
        var transform = tile.transform;
        var position = transform.position;
        Tween.Position(transform, position + Vector3.down * distance_below, duration_down, delay + addedDelay,
            Tween.EaseInOut);
        Tween.Position(transform, tile.RootPosition(), duration_up, duration_down + delay + addedDelay,
            Tween.EaseOut);
    }
}