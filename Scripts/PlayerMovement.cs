using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
	public float speedScalar = 10.0f;
	public float rotScalar = 5.0f;
	public float upDownRange = 60.0f;
	float verticalRotation = 0.0f;
	float verticalVelocity = 0.0f;
	public float jumpSpeed = 5.0f;
	CharacterController cc;
	public float sprintSpeed = 1.5f;
	bool isCrouched = false;
	GameObject gun;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();
		gun = GameObject.Find("Gun");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//crouch
		if(Input.GetKeyDown(KeyCode.C) && isCrouched == false)
		{
			cc.transform.localScale = (new Vector3(1,0.5f,1));	//i tried scaling the controllers height, but it is a pain and i kept falling through the floor
			gun.transform.localScale = (new Vector3(0.1f,0.8f,0.4f));	//to compensate for scalling the controller, we scale the gun by 2 times
			isCrouched = true;
		}
		else if(Input.GetKeyDown(KeyCode.C) && isCrouched == true)
		{
			cc.transform.localScale = (new Vector3(1,1.0f,1));
			gun.transform.localScale = new Vector3(0.1f,0.8f,0.2f);	//scale the gun back to normal
			isCrouched = false;
		}
		else
			; 
		//rotation
		float rotLeftRight = Input.GetAxis("Mouse X") * rotScalar;
		verticalRotation -= Input.GetAxis("Mouse Y") * rotScalar; //euler rotation goes from 0 to 360 degrees, in order to clamp the rotation we store the rotation change in a variable
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange); //we clamp the variable between -60 and 60
		transform.Rotate(0,rotLeftRight,0);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation,0,0); //you can't just rotate the character up and down, so we grab the camera
		
		//movement
		float forwardSpeed = Input.GetAxis("Vertical") * speedScalar;
		float sideSpeed = Input.GetAxis("Horizontal") * speedScalar;
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		//jump
		if(Input.GetButtonDown("Jump") && cc.isGrounded)
		{
			verticalVelocity = jumpSpeed;
		}
		//sprint
		if(Input.GetKey(KeyCode.LeftShift) && cc.isGrounded) //we don't wan to sprint in the air, so isGrounded is checked
		{
			forwardSpeed *= sprintSpeed;
		}
			
		
		Vector3 speed = new Vector3(sideSpeed,verticalVelocity,forwardSpeed);
		speed = transform.rotation * speed;
		
		
		cc.Move(speed * Time.deltaTime);
	}
}
