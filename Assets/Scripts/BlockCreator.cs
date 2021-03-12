using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    private float previous_Step_Timer ;
    private float timer ;

    // Tetramino prefabs 
    public  GameObject[] tetraminos;

    [SerializeField]
    private Vector2Int spawnPosition;

    private int randomIndex;

    [SerializeField]
    private float blockSpawnFrequency = 5f;



    private void Start()
    {

    }

    // fill cell which forms a new Tetramino
    public Vector2Int[] SpawnTetramino()
    {
        int randIndex = getRandomBlockIndex();

        var tetraminoCoords = tetraminos[randIndex].GetComponent<Tetramino_Data>().GetTetraminoCoords();


        foreach (Vector2Int cell in tetraminoCoords) {

            GameController.instance.tetrisGrid.grid[spawnPosition.x + cell.x, 
                              spawnPosition.y + cell.y]
                              .GetComponent<SpriteRenderer>().enabled = true;

        }

        return tetraminoCoords;

    }


    public int getRandomBlockIndex()
    {
        randomIndex = UnityEngine.Random.Range(0, tetraminos.Length);
        return randomIndex;
    }
}


