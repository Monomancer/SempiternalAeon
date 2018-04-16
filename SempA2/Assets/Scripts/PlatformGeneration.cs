using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformGeneration : MonoBehaviour
{

	public GameObject platformBegin, platformCenter, platformEnd, platformUp, platformDown, earth;
	public GameObject spawnPoint;
	public GameObject[] backgroundVegetation;
	public GameObject[] foregroundVegetation;
	public Transform Terrain, SpawnPoints, Vegetation;

	public int minPlatformSize;
	public int maxPlatformSize;
	public int maxPlatformHeight;
	public int minPlatformHeight;
	public int earthDepth;

	public int platforms = 50;

	private float platformNum = 0;
	private float spriteSize = 0.64f;

	// Use this for initialization
	void Start ()
	{
		Instantiate (platformBegin, new Vector2 (0 - (spriteSize * 3), 0), Quaternion.identity).transform.parent = Terrain;
		Instantiate (platformCenter, new Vector2 (0 - (spriteSize * 2), 0), Quaternion.identity).transform.parent = Terrain;
		Instantiate (platformCenter, new Vector2 (0 - spriteSize, 0), Quaternion.identity).transform.parent = Terrain;
		for (int i = 1; i < earthDepth; i++) {
			Instantiate (earth, new Vector2 (0 - (spriteSize * 3), 0 - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
			Instantiate (earth, new Vector2 (0 - (spriteSize * 2), 0 - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
			Instantiate (earth, new Vector2 (0 - spriteSize, 0 - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
		}
		float prevPlatformHeight = 0;
		float platformHeight = 0;
		for (float plat = platformNum; plat < platforms; plat++) {
			
			int platformSize = Mathf.RoundToInt (Random.Range (minPlatformSize, maxPlatformSize));
			for (int tiles = minPlatformSize; tiles < platformSize; tiles++) {
				var test = Instantiate (platformCenter, new Vector2 (platformNum, platformHeight), Quaternion.identity).transform;
				test.parent = Terrain;
				// Only works correctly for grassy scene. All additional vegetation sprites 
				// must be placed at the bottom in the sprite sheet
				SpawnVegetation (test.transform.position.x, test.transform.position.y);
				for (int i = 1; i < earthDepth; i++) {
					Instantiate (earth, new Vector2 (platformNum, platformHeight - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
				}
				if (tiles % 4 == 0) {
					Instantiate (spawnPoint, new Vector2 (platformNum, platformHeight + spriteSize / 2), Quaternion.identity).transform.parent = SpawnPoints;
				}
				platformNum += spriteSize;
			}
			prevPlatformHeight = platformHeight;
			// platformHeight += spriteSize * (Random.Range (minPlatformHeight, maxPlatformHeight));
			platformHeight += spriteSize * (Random.Range (0, 2) == 0 ? 1 : -1);

			while (platformHeight > prevPlatformHeight) {
				platformNum += spriteSize / 2;
				Instantiate (platformUp, new Vector2 (platformNum, prevPlatformHeight + spriteSize / 2), Quaternion.identity).transform.parent = Terrain;
				for (int i = 1; i < earthDepth; i++) {
					Instantiate (earth, new Vector2 (platformNum + spriteSize / 2, platformHeight - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
					Instantiate (earth, new Vector2 (platformNum - spriteSize / 2, platformHeight - spriteSize / 2 - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
				}
				platformNum += 0.96f;
				prevPlatformHeight += spriteSize;
			}

			while (platformHeight < prevPlatformHeight) {
				platformNum += spriteSize / 2;
				Instantiate (platformDown, new Vector2 (platformNum, prevPlatformHeight - spriteSize / 2), Quaternion.identity).transform.parent = Terrain;
				for (int i = 1; i < earthDepth; i++) {
					Instantiate (earth, new Vector2 (platformNum + spriteSize / 2, platformHeight - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
					Instantiate (earth, new Vector2 (platformNum - spriteSize / 2, platformHeight + spriteSize / 2 - (spriteSize * i)), Quaternion.identity).transform.parent = Terrain;
				}
				platformNum += 0.96f;
				prevPlatformHeight -= spriteSize;
			}
		}
	}

	void SpawnVegetation (float x, float y)
	{
		// int random = Random.Range (0, 10);
		if (Random.Range (0, 10) <= 3) {
			if (Random.Range (0, 10) <= 4) {
				//Background
				int ran;
				if (backgroundVegetation.Length != 0) {
					ran = Random.Range (0, backgroundVegetation.Length);
					GameObject veg = backgroundVegetation [ran];
					y += veg.GetComponent<SpriteRenderer> ().size.y;
					Instantiate (backgroundVegetation [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;
				} else if (foregroundVegetation.Length != 0) {
					ran = Random.Range (0, foregroundVegetation.Length);
					GameObject veg = foregroundVegetation [ran];
					y += veg.GetComponent<SpriteRenderer> ().size.y;
					Instantiate (foregroundVegetation [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;
				}
			} else {
				//Foreground
				int ran;
				if (foregroundVegetation.Length != 0) {
					ran = Random.Range (0, foregroundVegetation.Length);
					GameObject veg = foregroundVegetation [ran];
					y += veg.GetComponent<SpriteRenderer> ().size.y;
					Instantiate (foregroundVegetation [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;
				} else if (backgroundVegetation.Length != 0) {
					ran = Random.Range (0, backgroundVegetation.Length);
					GameObject veg = backgroundVegetation [ran];
					y += veg.GetComponent<SpriteRenderer> ().size.y;
					Instantiate (backgroundVegetation [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;
				}
			}
		}
	}
}
