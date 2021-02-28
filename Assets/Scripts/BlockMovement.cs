using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public bool leftButtonPressed = false;
    public bool rightButtonPressed = false;
    public bool rotateButtonPressed = false;
    public bool accelerationButtonPressed = false;

    private Transform blockToMove;


    private void Update()
    {
        // Проверка можно ли двигать блок
        if (movable == true) {
            timer += Time.deltaTime;

            if (rotateButtonPressed) {
                RotateBlock();

            }

            // Left 
            if (leftButtonPressed == true && CanMoveHorizontal("Left") == true) {

                MoveBlockHorizontal("Left");

            }
            //Right
            if (rightButtonPressed == true && CanMoveHorizontal("Right") == true) {

                MoveBlockHorizontal("Right");
            }



            if (timer - previous_Step_Timer > GameController.instance.normal_Block_Timer && CanMoveDown() == true) {

                Debug.Log("Moved down 1");
                MoveBlockDown();
                previous_Step_Timer = timer;
            }

        }
    }

    private void MoveBlock(Vector2Int[] blockPositions, Vector3 direction)
    {
        // очищаем текущие клетки
        foreach (Vector2Int coord in blockPositions) {

            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + coord.x,
                                   coord.y] = TetrisGrid.cell.EMPTY;

        }

        // закрашиваем новые координаты и обновляем отступы нашего блока
        for (int i = 0; i < blockPositions.Length; i++) {

            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[i].x,
                                  blockPositions[i].y + 1] = 1;

            blockPositions[i].y += 1;
        }
    }

    private bool CanMove(Vector2Int[] blockPositions, Vector3 direction)
    {



        return true;
    }
}
