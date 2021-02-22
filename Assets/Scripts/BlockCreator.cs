using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    private float previous_Step_Timer ;
    private float timer ;

    // ����� ����� ������� ���� ������  
    public  GameObject[] blocksToSpawn;

    private int randomIndex;

    [SerializeField]
    private float blockSpawnFrequency = 5f;
    // Start is called before the first frame update


    bool b = false; //Debug
    void Update()
    {
        
        
        timer += Time.deltaTime;

        // ������ blockSpawnFrequency �������� ��������� ����
        if (TetrisGrid.neetToSpeawn == true) {


            SpawnBlock();
            //b = true;  //Debug

            TetrisGrid.neetToSpeawn = false;
        }
    }

    private void SpawnBlock()
    {
        int randIndex = getRandomBlock();

        
        // ��������� ���������� �����
        Instantiate(blocksToSpawn[randIndex], blocksToSpawn[randIndex].transform.position, Quaternion.identity);

        foreach(Vector2Int cubeCoord in blocksToSpawn[randIndex].GetComponent<BlockLogic>().startblockOffsets) {

            TetrisGrid.fillMatrix[TetrisGrid.spawnStartPosition.x + cubeCoord.x, cubeCoord.y] = 1;

        }   
    }



    public int getRandomBlock()
    {
        randomIndex = UnityEngine.Random.Range(0, blocksToSpawn.Length);
        return randomIndex;
    }
}


