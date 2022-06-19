using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TileLevel : LevelBase
{
    [HideInInspector] public List<Tile> tiles;

    public override LevelBase Initialize()
    {
        tiles = new List<Tile>();
        levelType = LevelType.Tiles;

        return base.Initialize();
    }

    // [Range(0, 10)] public int tileSpawnRadius = 1;

    // public float tileWidth;

    // public Tile tilePrefab;

    // public override LevelBase Initialize()
    // {


    //     return base.Initialize();
    // }

    // [ContextMenu("Generate Tiles")]
    // private void CreateTileGrid()
    // {
    //     var _tileCount = 0;

    //     for (int i = 0; i < tileSpawnRadius; i++)
    //     {
    //         var _nextRowCount = (int)Mathf.Pow(6, i);
    //         for (int j = 0; j < _nextRowCount; j++)
    //         {
    //             var _tile = Instantiate(tilePrefab, transform);
    //             _tile.name = "Tile_" + i + "_" + j;

    //             _tile.transform.localPosition = new Vector3(i, 0, j);

    //             _tileCount++;
    //         }
    //     }

    //     print(_tileCount);
    // }
}
