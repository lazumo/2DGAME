using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupmove : MonoBehaviour {
    public Collider2D collidor;
    public int cupdes;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "floor")
        {
            Destroy(collision.gameObject);
            cupdes++;
        }
    }
}
