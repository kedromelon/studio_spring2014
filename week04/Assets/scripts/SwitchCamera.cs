using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public GameObject fromcamera, tocamera;

	void OnTriggerEnter(){
		fromcamera.camera.enabled = false;
		tocamera.camera.enabled = true;
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.R))
			Application.LoadLevel(Application.loadedLevel);
	}
}
