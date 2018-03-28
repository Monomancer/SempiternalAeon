using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCoins : MonoBehaviour
{
    public int maxPlatforms = 20;
    public GameObject coin;
    public float xMinDelta = 1.5f;
    public float xMaxDelta = 10f;
    public float yMinDelta = 0f;
    public float yMaxDelta = 2.5f;
    

    //basics of code taken from Unity.com tutorial on basic platformer creation
    //changes and additions author: Benjamin Kauppi
    private Vector2 originPosition;


    void Start()
    {

        originPosition = transform.position;
        Spawn();

    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {

            Vector2 randomPosition = originPosition + new Vector2(Random.Range(xMinDelta, xMaxDelta), Random.Range(yMinDelta, yMaxDelta));
            Object.Instantiate(coin, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}
