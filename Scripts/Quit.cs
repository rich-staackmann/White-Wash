using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// This script controls the Quit button on the main menu
	void Update () {
	
	}
	
	void OnMouseEnter()
	{
		//renderer.material.color = Color.red;
		if(Input.GetMouseButtonDown(0))
		{
			Application.Quit();
		}
	}
	
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Application.Quit();
		}
	}
	
	void OnMouseExit()
	{
		//renderer.material.color = Color.white;
	}
}
