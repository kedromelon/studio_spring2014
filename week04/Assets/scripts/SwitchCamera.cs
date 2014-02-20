using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public GameObject fromcamera, tocamera;

	void OnTriggerEnter(){
		fromcamera.camera.enabled = false;
		tocamera.camera.enabled = true;
	}
}
