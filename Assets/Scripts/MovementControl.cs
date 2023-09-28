using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public static bool leftButtonPressed = false;
    public static bool rightButtonPressed = false;
    public static bool rotateButtonPressed = false;
    public static bool accelerationButtonPressed = false;

    private float timer;
    private float previous_Step_Timer;

    private float fall_Speed;

    private void Update()
    {
        timer += Time.deltaTime;

        MovementInput();

        MoveDown();
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

    private void MoveBlock(Vector2Int[] currentPositions, Vector3 targetPositions)
    {
        // clear current cells
        for (int i = 0; i < currentPositions.Length; i++)
            foreach (Vector2Int coord in currentPositions) {

                GameController.tetrisGrid.DisableSpriteOnPosition(tetrisGrid.grid[coord.x, coord.y].GetComponent<SpriteRenderer>());

            }

        // fill new cells
        for (int i = 0; i < currentPositions.Length; i++) {

            GameController.tetrisGrid.EnableSpriteOnPosition(GameController.tetrisGrid.grid[targetPositions.x, targetPositions.y].GetComponent<SpriteRenderer>());

            currentPositions[i].y += 1;
        }
    }

    private void MoveDown()
    {
        if (timer - previous_Step_Timer > fall_Speed /*&& CanMove() == true*/) {



            previous_Step_Timer = timer;
        }
    }
}
