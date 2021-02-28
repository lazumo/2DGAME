using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour {

	// Use this for initialization
    
    
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	 private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.tag=="dead")
        {
           Destroy(this.gameObject);
        }
    }
}
