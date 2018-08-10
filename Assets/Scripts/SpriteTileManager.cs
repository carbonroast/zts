using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTileManager : MonoBehaviour {

    private static Dictionary<string,SpriteTile> spriteTiles = new Dictionary<string, SpriteTile>();

    public static void RegisterTile (string name, SpriteTile spritetile)
    {
        spriteTiles.Add(name, spritetile);
    }

    //name is location + networkID
    public static SpriteTile GetTile(string name)
    {
        return spriteTiles[name];
    }


}
