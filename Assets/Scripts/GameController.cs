using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;

    //����������� �����
    public Sprite filledCube;
    public Sprite emptyCube;

    private Vector3 tempPosition;
    private Vector3 startPosition;

    public static float normal_Step_Timer = 0.45f;
    public static float fast_Step_Timer = 0.15f; // ����� ����� ����� ������ ����
    
    public GameObject[ , ] tempTetrisGrid = new GameObject[ TetrisGrid.width, TetrisGrid.height];

    public static bool leftButtonPressed = false;
    public static bool rightButtonPressed = false;
    public static bool rotateButtonPressed = false;
    public static bool accelerationButtonPressed = false;


    private void Start()
    {


        InitEmptyGrid(); // ������ ������� �� GameObject �� �������� ������ ������ Grid
    }

    private void Update()
    {
        //��������� ������� 
        UpdateGridSprites();
    }

    private void InitEmptyGrid()
    {
        startPosition = transform.position;

        for (int y = 0; y < TetrisGrid.height; y++) {

            for (int x = 0; x < TetrisGrid.width; x++) {
                tempPosition = startPosition + new Vector3(TetrisGrid.grid_Step * x, -TetrisGrid.grid_Step * y, 0f);
                transform.position = tempPosition;


                TetrisGrid.tetrisGrid[x, y] = cellPrefab;

                TetrisGrid.tetrisGrid[x, y].transform.position = transform.position; //������� ������ ������
                TetrisGrid.fillMatrix[x, y] = 0; // ������������� ������ ������

                GameObject obj = Instantiate(TetrisGrid.tetrisGrid[x, y], transform.position, Quaternion.identity);

                tempTetrisGrid[x, y] = obj;

            }
            // ���������� ���������
            tempPosition = startPosition;
        }

        TetrisGrid.tetrisGrid = tempTetrisGrid;
    }


    private void UpdateGridSprites()
    {
        for (int y = 0; y < TetrisGrid.height; y++) {

            for (int x = 0; x < TetrisGrid.width; x++) {


                //���� �������� � �������� ������� = 1, �� ���� ����� �����������
                if (TetrisGrid.fillMatrix[x, y] == 1) {
                    TetrisGrid.tetrisGrid[x, y].GetComponent<SpriteRenderer>().sprite = filledCube;


                }

                if (TetrisGrid.fillMatrix[x, y] == 0) {
                    TetrisGrid.tetrisGrid[x, y].GetComponent<SpriteRenderer>().sprite = emptyCube;
                }

            }
        }
    }

    //DEBUG
    public void RestartScene()
    {
        
        TetrisGrid.neetToSpeawn = true;
        SceneManager.LoadScene("MainMenu");
        

    }

}

  


