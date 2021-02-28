using UnityEngine;
using UnityEngine.UI;  
using System.Collections;
using System.Collections.Generic;
 public class pause : MonoBehaviour 
 {
     bool paused =false;
	 public void Pause() //Function to take care of Pause Button.. 
	{

    
    if (Time.timeScale == 1 && paused == false) //1 means the time is normal so the game is running..
    {
        
        Time.timeScale = 0; //Pause Game..
    }
    else
    {
        Time.timeScale = 1; //Resume Game..
    }
	}
 }