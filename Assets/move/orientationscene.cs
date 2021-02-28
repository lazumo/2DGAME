using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class orientationscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
		{
			clean();
			SceneManager.LoadScene(2);
			
		}
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			clean();
			SceneManager.LoadScene(0);
			
		}
	}
	void clean()
	{
		 foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
             Destroy(o);
         }
	}
}
