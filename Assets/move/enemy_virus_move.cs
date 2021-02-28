using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_virus_move : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D rb;
	public Transform right,left;
	public float speed=3f;
	int direction=1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement();
	}
	void Movement()
	{
		rb.velocity=new Vector2(direction*speed,rb.velocity.y);
	}
	private void OnTriggerEnter2D(Collider2D collision)//口罩蒐集判定
    {
     if (collision.tag=="bound")
        {
			direction=-direction;
        }
    }
	
}
