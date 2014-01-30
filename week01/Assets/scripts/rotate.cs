using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float speed = 2.5f;

	// Update is called once per frame
	void Update () {
		transform.Rotate(transform.up * Time.deltaTime * speed);
	}
}
