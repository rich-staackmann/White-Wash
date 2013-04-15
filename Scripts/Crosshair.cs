using UnityEngine;
using System.Collections;

//the purpose of this script is to draw a crosshair image at the center of the screen


public class Crosshair : MonoBehaviour {
	public Texture2D crosshair;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width/2 - 64/2, Screen.height/2, 64, 64),crosshair);
	}
}
