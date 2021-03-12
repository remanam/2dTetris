using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public bool leftButtonPressed = false;
    public bool rightButtonPressed = false;
    public bool rotateButtonPressed = false;
    public bool accelerationButtonPressed = false;

    [SerializeField]
    private Vector2Int[] tetraminoToMove;

    private int currentTetraminoLength;

    private float timer;
    private float previous_Step_Timer;

    private TetrisGrid tetrisGridInstance;

    private BlockCreator blockCreator;


    private void Start()
    {
        tetrisGridInstance = GameController.instance.tetrisGrid;
        blockCreator = GameController.instance.blockCreator;



        tetraminoToMove = blockCreator.SpawnTetramino();
    }

    private void Update()
    {
        
        currentTetraminoLength = tetraminoToMove.Length;

        //if (GameController.instance.neetToSpawn == true)

        // �������� ����� �� ������� ����

        timer += Time.deltaTime;

        if (rotateButtonPressed == true) {
                

        }

        // Left 
        if (leftButtonPressed == true ) {

                

        }
        //Right
        if (rightButtonPressed == true ) {

                
        }



        if (timer - previous_Step_Timer > GameController.instance.normal_Block_Speed /*&& CanMove() == true*/) {

            
                
            previous_Step_Timer = timer;
        }

    }

    // enable sprite of a cell
    private void EnableCell(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.enabled = true;
    }

    private void DisableCell(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.enabled = false;
    }

    private bool isCellFilled(SpriteRenderer spriteRenderer)
    {
        if (spriteRenderer.enabled == true) {
            return false;
        }

        return true;
    }

    private void MoveBlock(Vector2Int[] tetraminoPositions, Vector3 direction)
    {
        // clear current cells
        for(int i = 0; i < currentTetraminoLength; i++)
        foreach (Vector2Int coord in tetraminoPositions) {

            DisableCell(tetrisGridInstance.grid[coord.x, coord.y].GetComponent<SpriteRenderer>());

        }

        // fill new cells
        for (int i = 0; i < currentTetraminoLength; i++) {

            EnableCell(tetrisGridInstance.grid[tetraminoPositions[i].x, tetraminoPositions[i].y].GetComponent<SpriteRenderer>());

            tetraminoPositions[i].y += 1;
        }
    }

    private bool CanMove(Vector2Int[] blockPositions, Vector3 direction)
    {



        return true;
    }


    /*    private void RotateBlock()
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
                    TetrisGrid.fillMatrix[blockPositions[i].x + TetrisGrid.spawnStartPosition.x + tempStartOffsets[i].x, blockPositions[i].y + tempStartOffsets[i].y] == 2) {

                    return;

                }
            }

            // ������������ ����
            // startPosition[0] ������� ��� ����� ������
            for (int i = blockPositions.Length - 1; i >= 0; i--) {



                //������� ������ �����
                TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + blockPositions[i].x,
                                                                        +blockPositions[i].y] = 0;


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
                    blockPositions[i].x += startblockOffsets[i].x;
                    blockPositions[i].y += startblockOffsets[i].y;
                }
                else {
                    // ����������� ������ � ����� �������
                    int temp0 = startblockOffsets[0].x;
                    startblockOffsets[0].x = startblockOffsets[0].y;
                    startblockOffsets[0].y = -temp0;
                }

                // ���������� ������� � ������ ���������
                tetrisGridInstance.fillMatrix[GameController.instance.tetrisGrid.spawnStartPosition.x + blockPositions[i].x, blockPositions[i].y] = GameController.cell.FILLED;
            }
        }*/
}
