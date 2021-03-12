using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public TetrisGrid tetrisGrid;

    //For compact scene object storage
    [SerializeField]
    private Transform parentForGridCell;


    [SerializeField]
    private Transform gridStartPosition; // Left Upper cell of the Grid

    

    [SerializeField]
    private GameObject cellPrefab;

    //filled Cubesprite
    public Sprite filledCube;

    [SerializeField]
    private int width;
    [SerializeField]
    private int height;

    private Vector2Int startPosition;



    public float normal_Block_Speed = 0.45f;
    public float fast_Block_Speed = 0.2f; // Когда игрок нажал кнопку вниз


    public BlockCreator blockCreator;

    // true if need to spawn next block
    public bool neetToSpawn = true;


    private void Awake()
    {
        MakeSingleton();
        blockCreator = GetComponent<BlockCreator>();

        tetrisGrid = new TetrisGrid(width, height, gridStartPosition.position);

        InitEmptyGrid();
    }

    private void MakeSingleton()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }


    public bool firstStart = true;
    void Update()
    {

        // Каждый blockSpawnFrequency появляем случайный блок
        if (neetToSpawn == true || firstStart == true) {


            blockCreator.SpawnTetramino();
            
            //Flag for first spawn
            firstStart = false;

            neetToSpawn = false;
        }
    }

    public void InitEmptyGrid()
    {
        Vector3 currentPosition;

        for (int y = 0; y < tetrisGrid.GetMatrixSize().y; y++) {

            for (int x = 0; x < tetrisGrid.GetMatrixSize().x; x++) {
                // Count position of each cell
                currentPosition = gridStartPosition.localPosition + new Vector3(tetrisGrid.grid_Step * x, -tetrisGrid.grid_Step * y, 0f);
                transform.position = currentPosition;


                tetrisGrid.grid[x, y] = cellPrefab;

                tetrisGrid.grid[x, y].transform.position = currentPosition; //set cell position


                GameObject obj = Instantiate(tetrisGrid.grid[x, y], tetrisGrid.grid[x, y].transform.position, Quaternion.identity);

                obj.GetComponent<SpriteRenderer>().enabled = false;

                //Set parent transform for convinience in inspector
                obj.transform.SetParent(parentForGridCell);


            }
            // Reset transform after each iteration
            currentPosition = gridStartPosition.localPosition;
        }
    }

    //Movement script does that, 
    public void UpdateGridSprites(Vector2Int[] positions, Vector2Int[] posToUpdate)
    {
        //Clear current cells
        for (int i = 0; i < positions.Length; i++) {

            tetrisGrid.grid[positions[i].x + startPosition.x, positions[i].y].SetActive(false); // Make cell inactive
        }

        //fill nextPosition
        for (int i = 0; i < positions.Length; i++) {

            tetrisGrid.grid[posToUpdate[i].x + startPosition.x, posToUpdate[i].y].GetComponent<SpriteRenderer>().sprite = filledCube; // fill cell


        }

    }

    //DEBUG
    public void RestartScene()
    {
        
        SceneManager.LoadScene("MainMenu");
        
    }

}

  


