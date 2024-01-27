using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Vector3Int position;

    public Vector3Int Position => position;
    
    public void SetPosition(Vector3Int position)
    {
        this.position = position;
        UpdatePosition();
    }

    public Vector3 RootPosition()
    {
        return TileManager.Instance.Grid.GetCellCenterWorld(position).WithZ(transform.position.z);
    }

    [Button("Update Position")]
    private void UpdatePosition()
    {
        transform.position = RootPosition();
    }

    private static List<Vector3Int> EvenNeighbours = new List<Vector3Int>
    {
        new Vector3Int(1, 0, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, -1, 0),
        new Vector3Int(-1, 1, 0),
        new Vector3Int(-1, -1, 0),
    };
    private static List<Vector3Int> OddNeighbours = new List<Vector3Int>
    {
        new Vector3Int(1, 0, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, -1, 0),
        new Vector3Int(1, 1, 0),
        new Vector3Int(1, -1, 0),
    };
    public List<Vector3Int> NeighbourPositions => (position.y % 2 == 0 ? EvenNeighbours : OddNeighbours)
        .Select(diff => diff + position)
        .ToList();
}
