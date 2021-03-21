using System;
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
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
               
            }
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
