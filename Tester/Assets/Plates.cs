using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class Plates : Open
{
    public Tile tile;
    public Tilemap tileMap;

    public override void Interact(){
        if(!isOpen)
            sr.sprite = open;
        isOpen = true;

        tileMap.SetTile(new Vector3Int(6,9,0), tile);
    }
}
