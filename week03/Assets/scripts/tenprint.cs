using UnityEngine;
using System.Collections;

public class tenprint : MonoBehaviour {

	public TextMesh mytext;
	int charkey;
	int index = 0;
	public int charsinline = 50;

	// Use this for initialization
	void Start () {
		mytext = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		charkey = Random.Range(0,2);
		switch (charkey){
			case (0):
				charkey = 47;
				break;	
			case (1):
				charkey = 92;
				break;
		}

		mytext.text+=(char)charkey;

		index++;
		if ( index == charsinline ){
			index = 0;
			mytext.text += "\n";
		}

	}
}
