using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour {

    public Transform target;
    public float x_Offset;
    public float y_Offset;


    public Vector3 cameraPosition;

    // Use this for initialization
    void Start () {
        cameraPosition = target.position;
        cameraPosition.x += x_Offset;
        cameraPosition.y += y_Offset;
        transform.position = cameraPosition;
	}
	
	// Update is called once per frame
	void Update () {
        cameraPosition = target.position;
        cameraPosition.x += x_Offset;
        cameraPosition.y += y_Offset;
        transform.position = cameraPosition;
    }
}
