using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{

    public float grid_Step = 0.3755f;

    // default spawnPosition for blocks (Count from left upper cell)
    private Vector3 startGridPosition;

    private int width, height;

    // Position matrix
    public GameObject[,] grid;

    private GameObject cellPrefab;

    public enum cellState{
        empty,
        filled
    }


    public TetrisGrid(int _width, int _height, Vector3 _startGridPosition)
    {
        width = _width;
        height = _height;
        startGridPosition = _startGridPosition;

        grid = new GameObject[width, height];
    }


    public Vector2Int GetMatrixSize()
    {
        return new Vector2Int(width, height);
    }

}
