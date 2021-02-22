using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Drawing;



[System.Serializable]
public class BlockLogic : MonoBehaviour
{

    public Vector2Int[] startblockOffsets; // ’рани начальные, чтоб знать отступы. »спользуетс€ дл€ поворота блока


    public Vector2Int[] blockPositions;


    private float timer = 0f;
    private float previous_Step_Timer = 0f;

    private bool movable = true; // ≈сли false фигура больше не двигаетс€

    int degree = 0;

    private void Start()
    {
        

        blockPositions = new Vector2Int[startblockOffsets.Length];

        for (int i = 0; i < startblockOffsets.Length; i++) {

            blockPositions[i].x = startblockOffsets[i].x;
            blockPositions[i].y = startblockOffsets[i].y;
        }

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && CanMoveDown()
            && CanMoveHorizontal("Left") && CanMoveHorizontal("Right")) {
            //RotateBlock();
        }

        // ѕроверка можно ли двигать блок
        if (movable == true) {
            timer += Time.deltaTime;

            // Left 
            if (Input.GetKeyDown(KeyCode.A) && CanMoveHorizontal("Left") == true) {

                MoveBlockHorizontal("Left");

            }
            //Right
            if (Input.GetKeyDown(KeyCode.D) && CanMoveHorizontal("Right") == true) {

                MoveBlockHorizontal("Right");
            }

            if (timer - previous_Step_Timer > GameController.normal_Step_Timer && CanMoveDown() == true) {

                Debug.Log("Moved down 1");
                MoveBlockDown();
                previous_Step_Timer = timer;
            }
        }

    }

    private void MoveBlockDown()
    {
        // очищаем текущие клетки
        foreach (Vector2Int coord in blockPositions) {
            
            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + coord.x, 
                                   coord.y] = 0;

        }

        // закрашиваем новые координаты и обновл€ем отступы нашего блока
        for (int i = 0; i < blockPositions.Length; i++) {

            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[i].x,
                                  blockPositions[i].y + 1] = 1;

            blockPositions[i].y += 1;
        }
    }

    private bool CanMoveDown()
    {
        int index = 0;
        foreach (Vector2Int cubeCoord in blockPositions) {

            Vector2Int cubeToCheck = new Vector2Int(cubeCoord.x + TetrisGrid.spawnStartPosition.x, cubeCoord.y + 1);

            if (cubeCoord.y + 1 > TetrisGrid.height - 1 ||
                TetrisGrid.fillMatrix[cubeToCheck.x, cubeToCheck.y] == 2) {

                foreach (Vector2Int cubeCoord_ in blockPositions) {
                    TetrisGrid.fillMatrix[cubeCoord_.x + TetrisGrid.spawnStartPosition.x, cubeCoord_.y] = 2;
                }
                TetrisGrid.neetToSpeawn = true;

                movable = false;
                return false;
                

            }
            index++;
        }       
        return true;
    }

    private bool CanMoveHorizontal(string direction)
    {
        if (direction == "Left") {

            foreach (Vector2Int cubeCoord in blockPositions) {

                // ≈сли достиг границы, или блок зан€т (“о есть в fillMatrix[i,j] = 2) то нельз€ двигать
                if (TetrisGrid.spawnStartPosition.x + cubeCoord.x - 1 < 0 ||
                    TetrisGrid.fillMatrix[cubeCoord.x + TetrisGrid.spawnStartPosition.x - 1, cubeCoord.y] == 2) {

/*                    foreach (Vector2Int cubeCoord_ in blockOffsets) {
                        TetrisGrid.fillMatrix[cubeCoord_.x + TetrisGrid.spawnStartPosition.x, cubeCoord_.y] = 2;
                    }*/
                    return false;

                }

            }
        }else if (direction == "Right") {
            foreach (Vector2Int cubeCoord in blockPositions) {

                if (TetrisGrid.spawnStartPosition.x + cubeCoord.x + 1 > TetrisGrid.width - 1 ||
                    TetrisGrid.fillMatrix[cubeCoord.x + TetrisGrid.spawnStartPosition.x + 1, cubeCoord.y] == 2) {

/*                    foreach (Vector2Int cubeCoord_ in blockOffsets) {
                        TetrisGrid.fillMatrix[cubeCoord_.x + TetrisGrid.spawnStartPosition.x, cubeCoord_.y] = 2;
                    }*/
                    return false;
                } 


            }
        }

        return true;
    }




    private void MoveBlockHorizontal(string direction)
    {
        // очищаем текущие клетки
        foreach (Vector2Int coord in blockPositions) {

            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + coord.x, coord.y] = 0;
        }

        if (direction == "Left") {
            for (int i = 0; i < blockPositions.Length; i++) {

                TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[i].x - 1, blockPositions[i].y] = 1;
                blockPositions[i].x -= 1;
            }

        }else if (direction == "Right") {

            for (int i = 0; i < blockPositions.Length; i++) {

                TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[i].x + 1, blockPositions[i].y] = 1;
                blockPositions[i].x += 1;
            }

        }
    }

    private void RotateBlock()
    {

        //ќчищаем текущие клетки
        for (int i = 0; i < startblockOffsets.Length; i++) {



            TetrisGrid.fillMatrix[ TetrisGrid.spawnStartPosition.x + blockPositions[i].x,
                                                                   + blockPositions[i].y]   = 0;
        }



        // ѕоворачиваем блок
        // startPosition[0] считаем как pivot
        for (int i = 0; i < blockPositions.Length - 1; i++) {

            if (degree != null) {

                int temp = startblockOffsets[i + 1].x - startblockOffsets[0].x; 
                startblockOffsets[i + 1].x = startblockOffsets[i + 1].y - startblockOffsets[0].y;

                startblockOffsets[i + 1].y = -temp; 

            }


        }
        // заполн€ем новые изменЄнные клетки
        for (int j = 0; j < blockPositions.Length; j++) {

            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[j].x, blockPositions[j].y] = 1;

        }
    }

    //DEBUG

}



