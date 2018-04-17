using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlatforms : MonoBehaviour
{

    /// <summary>
    ///
    /// </summary>
    /// <param name="xGroundMin"> Used to prevent platforms from spawning below the ground </param>
    /// <param name="xMinDelta"> Min x distance from previous platform </param>
    /// <param name="xMaxDelta"> Max x distance from previous platform </param>
    public int maxPlatforms = 20;
    public GameObject platform1;
	public GameObject platform2;
    public float xGroundMin = 1.25f;
    public float xMinDelta = 1.5f;
    public float xMaxDelta = 10f;
    public float yMinDelta = -2.5f;
    public float yMaxDelta = 2.5f;


    //basics of code taken from Unity.com tutorial on basic platformer creation
    //changes and additions author: Benjamin Kauppi
    private Vector2 originPosition;


    void Start()
    {

        originPosition = transform.position;
        Spawn();

    }

//	GameObject random(GameObject platform1, GameObject platform2)
//	{
//		GameObject platforms = GameObject.FindGameObjectWithTag ("platform1");
//		GameObject platforms2 = GameObject.FindGameObjectWithTag ("platform2");
//		//platforms2 = GameObject.FindGameObjectWithTag ("platform2");
//		List<GameObject> list = new List<GameObject>();
//		list.Add (platforms);
//		list.Add (platforms2);
//		int index = Random.Range (0, list.Count);
//		return list[index];
//
//
//	}

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {

            Vector2 randomPosition = originPosition + new Vector2(Random.Range(xMinDelta, xMaxDelta), Random.Range(yMinDelta, yMaxDelta));
			List<GameObject> list = new List<GameObject>();
			list.Add (platform1);
			list.Add (platform2);
			int index = Random.Range (0, list.Count);
			Instantiate(list[index], randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}
