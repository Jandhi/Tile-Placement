using System.Linq;
using Pixelplacement;
using UnityEngine;

public abstract class TileAnimation : ScriptableObject
{
    public abstract void Animate(Tile tile, float addedDelay = 0);
}