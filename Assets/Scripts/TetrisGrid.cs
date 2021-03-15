using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    // step distance in worldCoords
    public float grid_Step = 0.3755f;

    // first cell position
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

        
    }


    public void InitGrid()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
               
            }
        }
    }

    public Vector2Int GetBoardSize()
    {
        return new Vector2Int(width, height);
    }
}
