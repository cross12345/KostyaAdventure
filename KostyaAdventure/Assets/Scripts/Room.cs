using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    [SerializeField] Vector2Int floorX;
    [SerializeField] Vector2Int floorY;
    public List<TileBase> floorSprites = new List<TileBase>();
    [SerializeField] Tilemap RoomTiles;

    public GameObject DoorU;
    public GameObject DoorR;
    public GameObject DoorD;
    public GameObject DoorL;

    public GameObject HallU;
    public GameObject HallR;
    public GameObject HallD;
    public GameObject HallL;

    private void Start()
    {
        for(int x = floorX.x ; x < floorX.y+1; x++)
        {
            for (int y = floorY.x; y > floorY.y-1; y--)
            {
                if (Random.Range(0, 3) == 0)
                {
                    RoomTiles.SetTile(new Vector3Int(x, y, 0), floorSprites[Random.Range(0, floorSprites.Count)]);
                }
            }
        }
    }
}
