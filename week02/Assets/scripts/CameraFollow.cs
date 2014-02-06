using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform tofollow;
	public float damping = 5f;

	float p;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		p = Mathf.Lerp(transform.position.x, tofollow.position.x, Time.deltaTime * damping);

		transform.position = new Vector3(p,transform.position.y,transform.position.z);
	}
}
