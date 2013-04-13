using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//This controls the text to actually load the first level at the menu screen
	void OnMouseEnter()
	{
		//renderer.material.color = Color.red;
		if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel(1);
		}
	}
	
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel(1);
		}
	}
	
	void OnMouseExit()
	{
		//renderer.material.color = Color.white;
	}
}
