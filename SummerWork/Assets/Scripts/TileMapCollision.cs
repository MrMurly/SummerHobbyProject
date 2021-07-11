using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapCollision : MonoBehaviour
{
    public BoundsInt area;

    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        TileBase[] tileArray = tilemap.GetTilesBlock(area);
        for (int index = 0; index < tileArray.Length; index++)
        {
            print(tileArray[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
