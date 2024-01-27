using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class FollowMouseHex : MonoBehaviour
{
    private Tile _tile;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _tile = GetComponent<Tile>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        var worldPosition = _camera.ScreenToWorldPoint(mousePos);
        var grid = TileManager.Instance.Grid;
        var gridPos = grid.WorldToCell(worldPosition);
        
        _tile.SetPosition(gridPos);
    }
}
