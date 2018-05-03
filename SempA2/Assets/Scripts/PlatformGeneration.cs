using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlatformGeneration : MonoBehaviour
{

	public GameObject platformBegin, platformCenter, platformEnd, platformUp, platformDown, earth;
	public GameObject teleportObject, spawnPoint;
	public GameObject[] backgroundVegetation;
	public GameObject[] foregroundVegetation;
	public GameObject[] backgroundGrasses;
	public GameObject[] foregroundGrasses;
	public Transform Terrain, SpawnPoints, Vegetation;

	public int minPlatformSize;
	public int maxPlatformSize;
	public int maxPlatformHeight;
	public int minPlatformHeight;
	public int platforms;
	public int earthDepth;
	public float vegetationChance;
	public float grassesChance;

	public Boolean generateMap = true;
	private float platformNum;
	private float spriteSize;

	// Use this for initialization
	void Start ()
	{

		if (!generateMap) {
			return;
		}
		platformNum = 0;
		spriteSize = platformBegin.GetComponent<SpriteRenderer> ().size.x;
		// Spawn beginning platforms
		Instantiate (platformBegin, new Vector2 (-(spriteSize * 3), 0), Quaternion.identity).transform.parent = Terrain;
		Instantiate (platformCenter, new Vector2 (-(spriteSize * 2), 0), Quaternion.identity).transform.parent = Terrain;
		Instantiate (teleportObject, new Vector2 (-(spriteSize * 2), (float)((spriteSize + teleportObject.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025)), Quaternion.identity).transform.parent = Terrain;
		Instantiate (platformCenter, new Vector2 (-spriteSize, 0), Quaternion.identity).transform.parent = Terrain;
		for (int i = 1; i < earthDepth; i++) {
			GenerateEarth (-(spriteSize * 3), -(spriteSize * i));
			GenerateEarth (-(spriteSize * 2), -(spriteSize * i));
			GenerateEarth (-spriteSize, -(spriteSize * i));
		}

		// Now randomly generate
		float prevPlatformHeight = 0;
		float platformHeight = 0;
		for (float plat = 0; plat < platforms; plat++) {
			
			int platformSize = Mathf.RoundToInt (UnityEngine.Random.Range (minPlatformSize, maxPlatformSize));
			for (int tiles = minPlatformSize; tiles < platformSize; tiles++) {
				Instantiate (platformCenter, new Vector2 (platformNum, platformHeight), Quaternion.identity).transform.parent = Terrain;
				GenerateVegetation (platformNum, platformHeight);
				if (tiles % 3 == 0) {
					Instantiate (spawnPoint, new Vector2 (platformNum, platformHeight + spriteSize / 2), Quaternion.identity).transform.parent = SpawnPoints;
				}
				for (int i = 1; i < earthDepth; i++) {
					GenerateEarth (platformNum, platformHeight - (spriteSize * i));
				}
				platformNum += spriteSize;
			}
			prevPlatformHeight = platformHeight;
			platformHeight += spriteSize * (UnityEngine.Random.Range (minPlatformHeight, maxPlatformHeight));

			// Platform up
			while (platformHeight > prevPlatformHeight && (platformHeight - prevPlatformHeight > 0.01f)) {
				platformNum += spriteSize / 2;
				Instantiate (platformUp, new Vector2 (platformNum, prevPlatformHeight + spriteSize / 2), Quaternion.identity).transform.parent = Terrain;
				if (UnityEngine.Random.Range (0, 3) == 0) {
					Instantiate (spawnPoint, new Vector2 (platformNum, platformHeight + spriteSize * 2), Quaternion.identity).transform.parent = SpawnPoints;
				}
				// Instantiate (earth, new Vector2 (platformNum - spriteSize / 2, prevPlatformHeight - (spriteSize / 2)), Quaternion.identity).transform.parent = Terrain;
				for (int i = 1; i < earthDepth - 1; i++) {
					GenerateEarth (platformNum + spriteSize / 2, prevPlatformHeight - (spriteSize * i));
					GenerateEarth (platformNum - spriteSize / 2, prevPlatformHeight - (spriteSize * i));
				}
				platformNum += spriteSize + (spriteSize / 2);
				prevPlatformHeight += spriteSize;
			}

			// Platform down
			while (platformHeight < prevPlatformHeight && (prevPlatformHeight - platformHeight > 0.01f)) {
				platformNum += spriteSize / 2;
				Instantiate (platformDown, new Vector2 (platformNum, prevPlatformHeight - spriteSize / 2), Quaternion.identity).transform.parent = Terrain;
				if (UnityEngine.Random.Range (0, 3) == 0) {
					Instantiate (spawnPoint, new Vector2 (platformNum, platformHeight + spriteSize * 2), Quaternion.identity).transform.parent = SpawnPoints;
				}
				for (int i = 1; i < earthDepth - 1; i++) {
					GenerateEarth (platformNum - spriteSize / 2, prevPlatformHeight - (spriteSize * i));
					GenerateEarth (platformNum + spriteSize / 2, prevPlatformHeight - spriteSize / 2 - (spriteSize * i));
				}
				platformNum += spriteSize + (spriteSize / 2);
				prevPlatformHeight -= spriteSize;
			}
		}

		// Spawn final platform
		Instantiate (platformCenter, new Vector2 (platformNum, platformHeight), Quaternion.identity).transform.parent = Terrain;
		Instantiate (platformCenter, new Vector2 (platformNum + spriteSize, platformHeight), Quaternion.identity).transform.parent = Terrain;
		float y = platformHeight;
		y += (float)((spriteSize + teleportObject.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025);
		Instantiate (teleportObject, new Vector2 (platformNum + spriteSize, y), Quaternion.identity).transform.parent = Terrain;
		Instantiate (platformEnd, new Vector2 (platformNum + spriteSize * 2, platformHeight), Quaternion.identity).transform.parent = Terrain;
		for (int i = 1; i < earthDepth; i++) {
			GenerateEarth (platformNum, platformHeight - (spriteSize * i));
			GenerateEarth (platformNum + spriteSize, platformHeight - (spriteSize * i));
			GenerateEarth (platformNum + spriteSize * 2, platformHeight - (spriteSize * i));
		}
		// SaveScene ();
	}

	void GenerateVegetation (float x, float y)
	{
		float newY = y;
		int ran = UnityEngine.Random.Range (0, 100);
		if (ran <= vegetationChance) {
			if (UnityEngine.Random.Range (0, 10) >= 3) {
				//Background
				if (backgroundVegetation.Length != 0) {
					ran = UnityEngine.Random.Range (0, backgroundVegetation.Length);
					GameObject veg = backgroundVegetation [ran];
					newY += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
					Instantiate (backgroundVegetation [ran], new Vector2 (x, newY), Quaternion.identity).transform.parent = Vegetation;
					// Generate some grass
					if (UnityEngine.Random.Range (0, 100) >= grassesChance && backgroundGrasses.Length > 0) {
						if (foregroundGrasses.Length > 0) {
							if (UnityEngine.Random.Range (0, 2) == 1) {
								ran = UnityEngine.Random.Range (0, backgroundGrasses.Length);
								veg = backgroundGrasses [ran];
								y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
								Instantiate (backgroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;		
							} else {
								ran = UnityEngine.Random.Range (0, foregroundGrasses.Length);
								veg = foregroundGrasses [ran];
								y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.1f;
								Instantiate (foregroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;		
							}
						} else {
							ran = UnityEngine.Random.Range (0, backgroundGrasses.Length);
							veg = backgroundGrasses [ran];
							y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
							Instantiate (backgroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;	
						}
					}
				} else if (foregroundVegetation.Length != 0) {
					ran = UnityEngine.Random.Range (0, foregroundVegetation.Length);
					GameObject veg = foregroundVegetation [ran];
					newY += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.1f;
					Instantiate (foregroundVegetation [ran], new Vector2 (x, newY), Quaternion.identity).transform.parent = Vegetation;
					// Generate some grass
					if (UnityEngine.Random.Range (0, 100) >= grassesChance && backgroundGrasses.Length > 0) {
						ran = UnityEngine.Random.Range (0, backgroundGrasses.Length);
						veg = backgroundGrasses [ran];
						y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
						Instantiate (backgroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;		
					} else if (foregroundGrasses.Length > 0) {
						ran = UnityEngine.Random.Range (0, foregroundGrasses.Length);
						veg = foregroundGrasses [ran];
						y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.1f;
						Instantiate (foregroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;				
					}
				}
			} else {
				// Foreground
				if (foregroundVegetation.Length != 0) {
					ran = UnityEngine.Random.Range (0, foregroundVegetation.Length);
					GameObject veg = foregroundVegetation [ran];
					newY += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.1f;
					Instantiate (foregroundVegetation [ran], new Vector2 (x, newY), Quaternion.identity).transform.parent = Vegetation;
					// Generate some grass
					if (UnityEngine.Random.Range (0, 100) >= grassesChance && backgroundGrasses.Length > 0) {
						ran = UnityEngine.Random.Range (0, backgroundGrasses.Length);
						veg = backgroundGrasses [ran];
						y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
						Instantiate (backgroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;		
					} else if (foregroundGrasses.Length > 0) {
						ran = UnityEngine.Random.Range (0, foregroundGrasses.Length);
						veg = foregroundGrasses [ran];
						y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.1f;
						Instantiate (foregroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;			
					}
				} else if (backgroundVegetation.Length != 0) {
					ran = UnityEngine.Random.Range (0, backgroundVegetation.Length);
					GameObject veg = backgroundVegetation [ran];
					newY += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
					Instantiate (backgroundVegetation [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;
					// Generate some grass
					if (UnityEngine.Random.Range (0, 100) >= grassesChance && backgroundGrasses.Length > 0) {
						if (foregroundGrasses.Length > 0) {
							if (UnityEngine.Random.Range (0, 1) == 1) {
								ran = UnityEngine.Random.Range (0, backgroundGrasses.Length);
								veg = backgroundGrasses [ran];
								y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
								Instantiate (backgroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;		
							} else {
								ran = UnityEngine.Random.Range (0, foregroundGrasses.Length);
								veg = foregroundGrasses [ran];
								y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.1f;
								Instantiate (foregroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;				
							}
						} else {
							ran = UnityEngine.Random.Range (0, backgroundGrasses.Length);
							veg = backgroundGrasses [ran];
							y += (spriteSize + veg.GetComponent<SpriteRenderer> ().size.y) / 2 - spriteSize * 0.025f;
							Instantiate (backgroundGrasses [ran], new Vector2 (x, y), Quaternion.identity).transform.parent = Vegetation;	
						}
					}
				}
			}
		}
	}

	void GenerateEarth (float x, float y)
	{
		Instantiate (earth, new Vector2 (x, y), Quaternion.identity).transform.parent = Terrain;
	}

	void SaveScene ()
	{
		/*string[] path = EditorSceneManager.GetActiveScene ().path.Split (Char.Parse ("/"));
		path [path.Length - 1] = "AutoSave_" + path [path.Length - 1];
		bool saveOK = EditorSceneManager.SaveScene (EditorSceneManager.GetActiveScene (), string.Join ("/", path));
		print (saveOK); */
	}
}
