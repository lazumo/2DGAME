using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rota : MonoBehaviour {
	public Animator Switch;
	bool temp=false;
	int d=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movement();
	}
	void movement()
	{
		if (Switch.GetBool("on")!=temp)
		{
			d*=-1;
			transform.Rotate(0f,0f,d*-90f,Space.Self);
			temp=!temp;
		}
		
	}
}
