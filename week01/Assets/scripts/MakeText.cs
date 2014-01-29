using UnityEngine;
using System.Collections;

public class MakeText : MonoBehaviour {



	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = "YOOOO";
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= Vector3.up * Mathf.Sin(Time.time*15f)/10f;
	}
}
