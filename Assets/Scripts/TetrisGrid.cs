using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    // step distance in worldCoords
    private float grid_Step = 0.3755f;

    // first cell position
    private Vector3 startGridPosition;

    private int width, height;

    // Position matrix
    public GameObject[,] grid;

    [SerializeField]
    private Transform gridStartPosition; // Left Upper cell of the Grid

    //Parent for cell matrix
    [SerializeField]
    private Transform parentForGridCell;

    [SerializeField]
    private GameObject cellPrefab;

    public static bool leftButtonPressed = false;
    public static bool rightButtonPressed = false;
    public static bool rotateButtonPressed = false;
    public static bool accelerationButtonPressed = false;

    public enum cellState{
        empty,
        filled
    }

    private float timer;
    private float previous_Step_Timer;


    public TetrisGrid(int _width, int _height, Vector3 _startGridPosition)
    {
        width = _width;
        height = _height;
        startGridPosition = _startGridPosition;

        
    }


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

                obj.GetComponent<SpriteRenderer>().enabled = false;

                //Set parent transform for convinience in inspector
                obj.transform.SetParent(parentForGridCell);


            }
            // Reset transform after each iteration
            currentPosition = gridStartPosition.localPosition;
        }
    }

    public Vector2Int GetBoardSize()
    {
        return new Vector2Int(width, height);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        MovementInput();

        MoveDown();
    }

    private void MoveDown()
    {
        if (timer - previous_Step_Timer > GameController.instance.fall_Speed /*&& CanMove() == true*/) {


            previous_Step_Timer = timer;
        }
    }

    private void MovementInput()
    {
        timer += Time.deltaTime;

        if (rotateButtonPressed == true) {


        }

        // Left 
        if (leftButtonPressed == true) {



        }
        //Right
        if (rightButtonPressed == true) {


        }


    }
}
