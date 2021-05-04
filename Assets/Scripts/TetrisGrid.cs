using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    // step in worldCoords
    private float grid_Step = 0.3755f;

    private int width = 10, height = 20;

    // Position matrix
    public GameObject[,] grid;

    [SerializeField]
    private Transform gridStartPosition; // Left Upper cell of the Grid

    //Parent for cell matrix
    [SerializeField]
    private Transform parentForGridCell;

    [SerializeField]
    private GameObject cellPrefab;




    public enum cellState{
        empty,
        filled
    }

    private float timer;
    private float previous_Step_Timer;

    // Setup board properties
    public void SetupGrid(int _width, int _height)
    {
        width = _width;
        height = _height;

        grid = new GameObject[width, height];
     
    }

    // Render board
    public void InitGrid()
    {
        Vector3 currentPosition;

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                // Count position of each cell
                currentPosition = gridStartPosition.localPosition + new Vector3(grid_Step * x, -grid_Step * y, 0f);
                transform.position = currentPosition;


                grid[x, y] = cellPrefab;

                grid[x, y].transform.position = currentPosition; //set cell position


                GameObject obj = Instantiate(grid[x, y], grid[x, y].transform.position, Quaternion.identity);
                grid[x, y] = obj;

                obj.GetComponent<SpriteRenderer>().enabled = false;

                //Set parent transform for convinience in inspector
                obj.transform.SetParent(parentForGridCell);


            }
            // Reset transform after each iteration
            currentPosition = gridStartPosition.localPosition;
        }
    }

    public void CreateTetramino(Vector2Int[] tetraminos)
    {
        foreach(Vector2Int tetramino in tetraminos) {
            EnableSpriteOnPosition(tetramino);
        }
    }

    public void EnableSpriteOnPosition(Vector2Int spritePos)
    {
        grid[spritePos.x, spritePos.y].GetComponent<SpriteRenderer>().enabled = true;
    }

    public void DisableSpriteOnPosition(Vector2Int spritePos)
    {
        grid[spritePos.x, spritePos.y].GetComponent<SpriteRenderer>().enabled = false;
    }

    public Vector2Int GetBoardSize()
    {
        return new Vector2Int(width, height);
    }






}
