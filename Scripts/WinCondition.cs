using UnityEngine;
using System.Collections;
//
//this script defines the win condition(kill all targets)
//

public class WinCondition : MonoBehaviour {
	public int numEnemies = 8;
	bool won = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(numEnemies <=0)
		{
			won = true;	
			Screen.lockCursor = false;
		}
	}
	
	public void decrementEnemies()
	{
		numEnemies--;
	}
	
	void OnGUI () 
	{
		if(won)
		{
			// Make a background box
			GUI.Box(new Rect(10,10,100,120), "You Won!");
			
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
