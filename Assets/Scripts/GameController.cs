using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static TetrisGrid tetrisGrid;

    private MovementControl movementControl;


    //filled Cubesprite
    public Sprite filledCube;

    [SerializeField]
    private int width;
    [SerializeField]
    private int height;

    [SerializeField]
    private Vector2Int[] tetraminoToMove;

    public float fall_Speed = 0.45f;
    public float fast_Fall_Speed = 0.2f; // Когда игрок нажал кнопку вниз

    // true if need to spawn next block
    public bool neetToSpawn = false;


    private void Start()
    {

        tetrisGrid = GetComponent<TetrisGrid>();
        tetrisGrid.SetupGrid(width, height);

        tetrisGrid.InitGrid();

        tetrisGrid.CreateTetramino(tetraminoToMove);

    }


    public bool firstStart = true;
    void Update()
    {
       

        // Каждый blockSpawnFrequency появляем случайный блок
        if (neetToSpawn == true /*|| firstStart == true*/) {

            //blockCreator.SpawnTetramino();
            
            //Flag for first spawn
            firstStart = false;

            neetToSpawn = false;
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

  


