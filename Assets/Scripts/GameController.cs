using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public TetrisGrid tetrisGrid;



    //filled Cubesprite
    public Sprite filledCube;

    [SerializeField]
    private int width;
    [SerializeField]
    private int height;

    private Vector2Int startPosition;

    [SerializeField]
    private Vector2Int[] tetraminoToMove;

    public float fall_Speed = 0.45f;
    public float fast_Fall_Speed = 0.2f; // Когда игрок нажал кнопку вниз

    // true if need to spawn next block
    public bool neetToSpawn = false;


    private int currentTetraminoLength;


    private void Start()
    {
        MakeSingleton();

        tetrisGrid = GetComponent<TetrisGrid>();

        tetrisGrid.InitGrid();

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

        currentTetraminoLength = tetraminoToMove.Length;

        // Каждый blockSpawnFrequency появляем случайный блок
        if (neetToSpawn == true /*|| firstStart == true*/) {


            //blockCreator.SpawnTetramino();
            
            //Flag for first spawn
            firstStart = false;

            neetToSpawn = false;
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


    private void MoveBlock(Vector2Int[] tetraminoPositions, Vector3 direction)
    {
        // clear current cells
        for (int i = 0; i < currentTetraminoLength; i++)
            foreach (Vector2Int coord in tetraminoPositions) {

                //DisableCell(tetrisGridInstance.grid[coord.x, coord.y].GetComponent<SpriteRenderer>());

            }

        // fill new cells
        for (int i = 0; i < currentTetraminoLength; i++) {

            //EnableCell(tetrisGridInstance.grid[tetraminoPositions[i].x, tetraminoPositions[i].y].GetComponent<SpriteRenderer>());

            tetraminoPositions[i].y += 1;
        }
    }

    private bool CanMove(Vector2Int[] blockPositions, Vector3 direction)
    {



        return true;
    }


    //DEBUG
    public void RestartScene()
    {
        
        SceneManager.LoadScene("MainMenu");
        
    }

}

  


