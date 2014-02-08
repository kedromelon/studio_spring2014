using UnityEngine;
using System.Collections;

public class PlatformerController : MonoBehaviour {

	CharacterController controller;
	Vector3 velocity;
	Vector3 moveVector;

	public float gravity = 9.8f;
	public float speed = 1f;
	public float jumpSpeed = 10f;
	public float acceleration = 5f;
	public float airacceleration = 2f;
	public float turnspeed = 5f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		velocity = controller.velocity;
		moveVector = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
			moveVector += Vector3.forward;
		if (Input.GetKey(KeyCode.S))
			moveVector -= Vector3.forward;
		if (Input.GetKey(KeyCode.A))
			moveVector -= Vector3.right;
		if (Input.GetKey(KeyCode.D))
			moveVector += Vector3.right;

		if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
			moveVector *= 0.707f;

		if (controller.isGrounded){
			if (Input.GetKeyDown(KeyCode.Space))
				velocity.y = jumpSpeed;
			velocity.x = Mathf.Lerp(velocity.x, moveVector.x*speed, Time.deltaTime * acceleration);
			velocity.z = Mathf.Lerp(velocity.z, moveVector.z*speed, Time.deltaTime * acceleration);
		}else{
			velocity.x = Mathf.Lerp(velocity.x, moveVector.x*speed, Time.deltaTime * airacceleration);
			velocity.z = Mathf.Lerp(velocity.z, moveVector.z*speed, Time.deltaTime * airacceleration);
		}

		if (velocity.x != 0f || velocity.z != 0f)
			transform.rotation = Quaternion.Slerp(transform.rotation, 
			                                      Quaternion.LookRotation(new Vector3(velocity.x, 0f, velocity.z)),
			                                      Time.deltaTime * turnspeed);
			
		velocity.y -= gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

	}

	void OnTriggerEnter(){
		// reset to starting point
		transform.position = new Vector3(0f,2f,0f);
	}
}
