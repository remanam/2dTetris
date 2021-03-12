using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramino_Data : MonoBehaviour
{

    [SerializeField]
    private Vector2Int[] TetraminoOffSets; // Form of tetramino

    public Vector2Int[] GetTetraminoCoords()
    {
        return TetraminoOffSets;
    }

}
