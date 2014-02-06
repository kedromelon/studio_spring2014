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

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		velocity = controller.velocity;
		moveVector = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
			moveVector += transform.forward;
		if (Input.GetKey(KeyCode.S))
			moveVector -= transform.forward;
		if (Input.GetKey(KeyCode.A))
			moveVector -= transform.right;
		if (Input.GetKey(KeyCode.D))
			moveVector += transform.right;

		if (controller.isGrounded){
			if (Input.GetKeyDown(KeyCode.Space))
				velocity.y = jumpSpeed;
			velocity.x = Mathf.Lerp(velocity.x, moveVector.x*speed, Time.deltaTime * acceleration);
			velocity.z = Mathf.Lerp(velocity.z, moveVector.z*speed, Time.deltaTime * acceleration);
		}else{
			velocity.x = Mathf.Lerp(velocity.x, moveVector.x*speed, Time.deltaTime * acceleration / 2f);
			velocity.z = Mathf.Lerp(velocity.z, moveVector.z*speed, Time.deltaTime * acceleration / 2f);
		}
			
		velocity.y -= gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

	}

	void OnTriggerEnter(){
		transform.position = new Vector3(0f,2f,0f);
	}
}
