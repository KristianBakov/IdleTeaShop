using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Tilemap floorTilemap;
    public TileBase floorTile;
    public Camera mainCamera;

    private BoundsInt cameraBounds;
    
    void Start()
    {
        // Get the bounds of the camera's view in world space
        cameraBounds = GetCameraBounds();
        
        // Populate the floor tilemap within the camera's view
        PopulateFloorTilemap();
    }
    
    void PopulateFloorTilemap()
    {
        foreach (var position in cameraBounds.allPositionsWithin)
        {
            // Check if the position is within the floor tilemap bounds
            if (floorTilemap.HasTile(position))
            {
                // Populate the floor tile at this position
                floorTilemap.SetTile(position, floorTile);
            }
        }
    }

    BoundsInt GetCameraBounds()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        float cameraHalfHeight = mainCamera.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;

        Vector3Int minCell = floorTilemap.WorldToCell(cameraPosition - new Vector3(cameraHalfWidth, cameraHalfHeight, 0));
        Vector3Int maxCell = floorTilemap.WorldToCell(cameraPosition + new Vector3(cameraHalfWidth, cameraHalfHeight, 0));

        BoundsInt bounds = new BoundsInt();
        bounds.SetMinMax(minCell, maxCell);

        return bounds;
    }
}
