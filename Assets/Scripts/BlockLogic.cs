using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Drawing;



[System.Serializable]
public class BlockLogic : MonoBehaviour
{

    public Vector2Int[] startblockOffsets; // ����� ���������, ���� ����� �������. ������������ ��� �������� �����


    public Vector2Int[] blockPositions;


    private float timer = 0f;
    private float previous_Step_Timer = 0f;

    private bool movable = true; // ���� false ������ ������ �� ���������

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

                // ���� ������ �������, ��� ���� ����� (�� ���� � fillMatrix[i,j] = 2) �� ������ �������
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
        // ������� ������� ������
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

        Vector2Int[] tempStartOffsets = new Vector2Int[startblockOffsets.Length];

        //�������� ����� �� ������� ����
        for (int i = 0; i < blockPositions.Length; i++) {

            // ������� ��������� �������, ����� ��������� ����� �� �������
            int temp = startblockOffsets[i].x - startblockOffsets[0].x;
            tempStartOffsets[i].x = startblockOffsets[i].y - startblockOffsets[0].y;

            tempStartOffsets[i].y = -temp;

            //�������� ����� �� ��������� ����
            if (blockPositions[i].x + TetrisGrid.spawnStartPosition.x + tempStartOffsets[i].x > TetrisGrid.width - 1 ||
                blockPositions[i].x + TetrisGrid.spawnStartPosition.x + tempStartOffsets[i].x < 0 ||
                blockPositions[i].y + tempStartOffsets[i].y > TetrisGrid.height - 1 ||
                blockPositions[i].y + tempStartOffsets[i].y < 0 || 
                TetrisGrid.fillMatrix[blockPositions[i].x + TetrisGrid.spawnStartPosition.x + tempStartOffsets[i].x, blockPositions[i].y + tempStartOffsets[i].y] == 2 ) {

                return;
                
            }
        }

        // ������������ ����
        // startPosition[0] ������� ��� ����� ������
        for (int i = blockPositions.Length - 1; i >= 0; i--) {             
                
            

            //������� ������ �����
            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[i].x,
                                                                    + blockPositions[i].y] = 0;


            // ������� ������ �������
            blockPositions[i].x -= startblockOffsets[i].x;
            blockPositions[i].y -= startblockOffsets[i].y;

            // � ������ �� �������� ������ ����
            if (i != 0) {

                // ������� ����� �� ������� ��������
                startblockOffsets[i].x -= startblockOffsets[0].x;
                startblockOffsets[i].y -= startblockOffsets[0].y;

                // ������� �������
                int temp = startblockOffsets[i].x;
                startblockOffsets[i].x = startblockOffsets[i].y + startblockOffsets[0].y;
                startblockOffsets[i].y = -temp + startblockOffsets[0].x;

                // ��������� ����� �������
                blockPositions[i].x += startblockOffsets[i].x ;
                blockPositions[i].y += startblockOffsets[i].y ;
            }
            else {
                // ����������� ������ � ����� �������
                int temp0 = startblockOffsets[0].x;
                startblockOffsets[0].x = startblockOffsets[0].y;
                startblockOffsets[0].y = -temp0;
            }

            // ���������� ������� � ������ ���������
            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[i].x, blockPositions[i].y] = 1;
        }




    }


    //DEBUG

}



