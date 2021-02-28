using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public TetrisGrid tetrisGrid;

    [SerializeField]
    private GameObject cellPrefab;

    //For compact scene object storage
    [SerializeField]
    private Transform parentForGridCell;

    //filled Cubesprite
    public Sprite filledCube;


    private Vector3 tempPosition;
    private Vector3 startPosition;

    public float normal_Block_Timer = 0.45f;
    public float fast_Block_Timer = 0.15f; // Когда игрок нажал кнопку вниз


    public GameObject[,] tempTetrisGrid;



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
        tetrisGrid = new TetrisGrid(10, 20, new Vector2Int(2, 4));


        tempTetrisGrid = new GameObject[tetrisGrid.GetMatrixSize().x,  tetrisGrid.GetMatrixSize().y];
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

        for (int y = 0; y < tetrisGrid.GetMatrixSize().y; y++) {

            for (int x = 0; x < tetrisGrid.GetMatrixSize().x; x++) {
                tempPosition = startPosition + new Vector3(tetrisGrid.grid_Step * x, -tetrisGrid.grid_Step * y, 0f);
                transform.position = tempPosition;


                tetrisGrid.tetrisGrid[x, y] = cellPrefab;

                tetrisGrid.tetrisGrid[x, y].transform.position = transform.position; //Позиции пустых клеток
                tetrisGrid.fillMatrix[x, y] = 0; // Устанавливаем пустые клетки

                GameObject obj = Instantiate(tetrisGrid.tetrisGrid[x, y], transform.position, Quaternion.identity);
                // Set parent transform for convinience
                obj.transform.SetParent(parentForGridCell);

                tempTetrisGrid[x, y] = obj;

            }
            // Сбрасываем трансформ
            tempPosition = startPosition;
        }

            tetrisGrid.tetrisGrid = tempTetrisGrid;
    }


    private void UpdateGridSprites(Vector2Int[] positions, Vector2Int[] posToUpdate)
    {
        for (int i; i < positions.Length; 


                //Если значения в элементе матрице = 1, то этот кубик закрашиваем
                if (tetrisGrid.fillMatrix[x, y] == TetrisGrid.cell.FILLED) {
                    tetrisGrid.tetrisGrid[x, y].GetComponent<SpriteRenderer>().sprite = filledCube;


                }

                if (tetrisGrid.fillMatrix[x, y] == TetrisGrid.cell.EMPTY) {
                    tetrisGrid.tetrisGrid[x, y].SetActive(false); // Делаем ячейку неактивной
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

  


