using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Pixelplacement;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Animations/Placement")]
public class PlacementAnimation : TileAnimation
{
    [SerializeField] private float distance_above;
    [SerializeField] private float distance_below;
    [SerializeField] private float duration1;
    [SerializeField] private float duration2;
    
    public override void Animate(Tile tile, float addedDelay = 0)
    {
        var transform = tile.transform;
        transform.position += Vector3.up * distance_above;
        
        Tween.Position(transform, transform.position + Vector3.down * (distance_above + distance_below), duration1, addedDelay,
            Tween.EaseInOut);
        Tween.Position(transform, tile.RootPosition(), duration2, duration1 + addedDelay,
            Tween.EaseOut);
    }
}
