using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid
{

    public float grid_Step = 0.3755f;

    // default spawnPosition for blocks (Count from left upper cell)
    public Vector3 startGridPosition;

    private int width, height;



    // Position matrix
    public GameObject[,] grid;


    public TetrisGrid(int _width, int _height, Vector3 _startGridPosition)
    {
        width = _width;
        height = _height;
        startGridPosition = _startGridPosition;

        grid = new GameObject[width, height];
    }


    // Define cell state
    public enum cell
    {
        EMPTY,
        FILLED,
        FILLED_NOT_MOVING // block stopped to move
    }


    public Vector2Int GetMatrixSize()
    {
        return new Vector2Int(width, height);
    }

    }
