using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class floor : MonoBehaviour {
    public Collider2D coller;
    public float cup;
    public Text cupnum;
    float goal=3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cup")
        {
            Destroy(collision.gameObject);
            cup++;
            cupnum.text = (cup.ToString());
        }
        if (cup==goal)
        {
            SceneManager.LoadScene(4);
        }
    }
}
