using UnityEngine;
using System.Collections;

public class BallFeel : MonoBehaviour {

	public Transform ball1, ball2;	// assign in inspector 

	// Use this for initialization
	void Start () {
		StartCoroutine(BallSwap(ball1.position, ball2.position));
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator BallSwap(Vector3 ball1start, Vector3 ball2start){
		Debug.Log("coroutine started");
		yield return 0;
		Debug.Log("1 frame elapsed");
		yield return new WaitForSeconds(1f);
		Debug.Log("1 second elapsed");

		while (true){
			float t = 0f;
			while (t < 1f){
				t += Time.deltaTime;
				ball1.position = Vector3.Lerp(ball1start, ball2start, t);
				ball2.position = Vector3.Lerp(ball2start, ball1start, t);
				if (t > 0.48f && t < 0.52f && !GetComponent<AudioSource>().isPlaying){
					GetComponent<AudioSource>().Play();
					StartCoroutine(ScreenShake());
				}
				yield return 0;
			}
		}
	}

	IEnumerator ScreenShake(float intensity = .5f, float frequency = 100f, float length = 1f){
		float t = 1f;
		Vector3 origCamPos = Camera.main.transform.position;
		float rand1 = Random.Range(0f,10f);
		float rand2 = Random.Range(0f,10f);
		while (t > 0f){
			t -= Time.deltaTime;
			Vector3 offset = Camera.main.transform.up * (Mathf.PerlinNoise(t * 100f, rand1)*2f-1f)
							+ Camera.main.transform.right * (Mathf.PerlinNoise(t * 133f,rand2)*2f-1f);
			offset *= intensity * t;
			Camera.main.transform.position = origCamPos + offset;

			yield return 0;
		}
		Camera.main.transform.position = origCamPos;
	}
}
