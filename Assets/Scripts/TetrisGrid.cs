using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid
{

    public float grid_Step = 0.3755f;

    private static int width;
    private static int height;

    // default spawnPosition on TetrisGrid
    public Vector2Int spawnStartPosition =  new Vector2Int(4, 0); 

    public enum cell{
        EMPTY,
        FILLED,
        FILLED_NOT_MOVING // block stopped to move
    }

    public cell[,] fillMatrix = new cell[width, height];

    // Position matrix
    public GameObject[,] tetrisGrid = new GameObject[width, height];

    // true if need to spawn next block
    public static bool neetToSpeawn = true;


    public TetrisGrid(int _width, int _height, Vector2Int _spawnStartPosition)
    {
        width = _width;
        height = _height;
        spawnStartPosition = _spawnStartPosition;
    }

    public Vector2Int GetMatrixSize()
    {
        return new Vector2Int(width, height);
    }







}
