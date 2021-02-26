using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private GameObject cellPrefab;

    //Окрашивание ячеек
    public Sprite filledCube;
    public Sprite emptyCube;

    private Vector3 tempPosition;
    private Vector3 startPosition;

    public float normal_Step_Timer = 0.45f;
    public float fast_Step_Timer = 0.15f; // Когда игрок нажал кнопку вниз
    
    public GameObject[ , ] tempTetrisGrid = new GameObject[ TetrisGrid.width, TetrisGrid.height];

    public bool leftButtonPressed = false;
    public bool rightButtonPressed = false;
    public bool rotateButtonPressed = false;
    public bool accelerationButtonPressed = false;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {

        InitEmptyGrid(); // Создаём матрицу из GameObject на позициях каждый клетки Grid
    }

    private void Update()
    {
        //Обновляем спрайты 
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

                TetrisGrid.tetrisGrid[x, y].transform.position = transform.position; //Позиции пустых клеток
                TetrisGrid.fillMatrix[x, y] = 0; // Устанавливаем пустые клетки

                GameObject obj = Instantiate(TetrisGrid.tetrisGrid[x, y], transform.position, Quaternion.identity);

                tempTetrisGrid[x, y] = obj;

            }
            // Сбрасываем трансформ
            tempPosition = startPosition;
        }

        TetrisGrid.tetrisGrid = tempTetrisGrid;
    }


    private void UpdateGridSprites()
    {
        for (int y = 0; y < TetrisGrid.height; y++) {

            for (int x = 0; x < TetrisGrid.width; x++) {


                //Если значения в элементе матрице = 1, то этот кубик закрашиваем
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

  


