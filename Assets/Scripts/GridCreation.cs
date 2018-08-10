using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Networking;

public class GridCreation : MonoBehaviour {

    //Creates tilemap grid and places tiles into an array
	void Start () {

        string netID = GetComponent<NetworkIdentity>().netId.ToString();


        Tilemap tilemap = GetComponent<Tilemap>();
        tilemap.CompressBounds();
        for(int x= tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++)
        {
            for(int y= tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, (int)tilemap.transform.position.z);

                if (tilemap.HasTile(cellPosition))
                {
                    Vector3 worldposition = tilemap.CellToWorld(cellPosition);

                    //Create Tile
                    SpriteTile spriteTile = new SpriteTile();
                    spriteTile.location = new Vector2Int((int)worldposition.x, (int)worldposition.y);
                    spriteTile.buildable = true;
                    //spriteTile.buildType = ??;
                    spriteTile.name = spriteTile.location.ToString() + " " + netID;

                    //Debug.Log(spriteTile.name);
                    //Debug.Log("x: " + x + " y: " + y +"coord - " + place);

                    //Add tile to network manager
                    SpriteTileManager.RegisterTile(spriteTile.name, spriteTile);
                }
            }
        }

	}
	

}
