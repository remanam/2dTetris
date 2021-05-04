using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static bool leftButtonPressed = false;
    public static bool rightButtonPressed = false;
    public static bool rotateButtonPressed = false;
    public static bool accelerationButtonPressed = false;

    private float timer;
    private float previous_Step_Timer;

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

    private void MoveDown()
    {
        if (timer - previous_Step_Timer > GameController.instance.fall_Speed /*&& CanMove() == true*/) {


            previous_Step_Timer = timer;
        }
    }
}
