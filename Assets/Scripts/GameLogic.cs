using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static float droptime = 0.9f;
    public static float quickdroptime = 0.05f;
    public static int width = 10, height = 20;
    public GameObject[] blocks;
    public Transform[,] grid = new Transform[width, height];

    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }

    public void SpawnBlock()
    {
        float guess = Random.Range(0, 1f);
        guess *= blocks.Length;
        Instantiate(blocks[Mathf.FloorToInt(guess)]);
    }

}
