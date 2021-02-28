using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	public Animator animator;
	public AudioSource switchAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "chara")
        {
				switchAudio.Play();
				animator.SetBool("on",!animator.GetBool("on"));
        }
    }
}
