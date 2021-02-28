using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject,0.5f);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="enemy")
        {
            Destroy(collision.gameObject);
        }
    }

}
