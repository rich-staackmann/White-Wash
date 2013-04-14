using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	bool isPaused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P) && isPaused == false)
		{
			Time.timeScale = 0.0f;
			Screen.lockCursor = false;
			isPaused = true;
			return;
		}
		
		if(Input.GetKeyDown(KeyCode.P) && isPaused == true)
		{
			Time.timeScale = 1.0f;
			Screen.lockCursor = true;
			isPaused = false;
			return;
		}
	}
	
	void OnGUI () 
	{
		if(isPaused)
		{
			// Make a background box
			GUI.Box(new Rect(10,10,100,120), "Pause Menu");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,80,20), "Level 1")) 
			{
				Application.LoadLevel(1);
			}
			if(GUI.Button(new Rect(20,70,80,20), "Level 2")) 
			{
				Application.LoadLevel(2);
			}

			// Make the second button.
			if(GUI.Button(new Rect(20,100,80,20), "Quit" +
				"")) 
			{
				Application.Quit();
			}
		}
	}
	
	
}
