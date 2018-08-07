﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridCreation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Tilemap tilemap = GetComponent<Tilemap>();
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for(int x=0; x < bounds.size.x; x++)
        {
            for(int y=0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if(tile != null)
                {
                    Debug.Log("x: " + x + " y: " + y + " tile: " + tile.name);

                }
                else
                {
                    Debug.Log("x:" + x + " y: " + y + " tile : (null)");
                }
            }
        }

	}
	

}
