using UnityEngine;
using System.Collections;

public class flicker : MonoBehaviour {

	int n;
	bool b;
	public int howoftentonotflicker = 10;

	// Update is called once per frame
	void Update () {
		n = Random.Range(0,howoftentonotflicker);
		if (n == 0)
			b = false;
		else 
			b = true;
		renderer.enabled = b;
		if (GetComponent<Light>() != null)
			light.enabled = b;
	}
}
