using UnityEngine;
using System.Collections;

public class Wanderer : MonoBehaviour {

	public Vector3 destination = Vector3.zero;
	public float wanderRange = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().AddForce(Vector3.Normalize(destination - transform.position), ForceMode.VelocityChange);

		destination = new Vector3(Random.Range(-wanderRange,wanderRange),transform.position.y,Random.Range(-wanderRange,wanderRange));

		if (Mathf.Abs(rigidbody.velocity.y) <= 0f){
			rigidbody.velocity += transform.up * 10f;
		}
	}


}
