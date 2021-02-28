using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour {

    public Transform target;
    public Transform origin;

    float x;
    float y;

    float z;
    
	// Use this for initialization
	void Start () {
		x=target.position.x-origin.position.x;
        y=target.position.y-origin.position.y;
        z=target.position.z-origin.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition=new Vector3(0,0,0);
	}
}
