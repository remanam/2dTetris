using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid
{
    public static TetrisGrid _instance;

    public static float grid_Step = 0.3755f;

    public const int width = 10;
    public const int height = 20;

    // ���������� �������, ������ ����� ���������� �����
    public static Vector2Int spawnStartPosition =  new Vector2Int(4, 0); 

    // 0 - �����, 1 - ����������� ������
    public static int[,] fillMatrix = new int[ width, height];

    [SerializeField]
    // ������� �������
    public static GameObject[,] tetrisGrid = new GameObject[width, height];

    // ���������� ����� �� �������� ��������� ���� ������� 
    public static bool neetToSpeawn = true;








}
