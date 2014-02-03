using UnityEngine;
using System.Collections;

public class adventure : MonoBehaviour {

	string currentRoom = "Lobby";

	// Use this for initialization
	void Start () {
		currentRoom = "Lobby";
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "You are currently in: " + currentRoom + "\n";

		switch(currentRoom){
			case ("Lobby"):
				textBuffer += "\nYou see the NYU Poly security guard";
				textBuffer += "\n\nPress [w] to use elevator";
				textBuffer += "\nPress [s] to go outside";
				if (Input.GetKeyDown(KeyCode.W)) currentRoom = "Elevator";
				if (Input.GetKeyDown(KeyCode.S)) currentRoom = "Outside";
				break;
			case ("Outside"):
				textBuffer += "\nWow, there's a lot of snow";
				textBuffer += "\nThis kinda sucks";
				textBuffer += "\n\nPress [s] to go back inside";
				if (Input.GetKeyDown(KeyCode.S)) currentRoom = "Lobby";
				break;
			case ("Elevator"):
				textBuffer += "\nPress [1] to go to back to the lobby";
				textBuffer += "\nPress [8] to go to the Game Center";
				textBuffer += "\n\nall the other buttons are broken...";
				if (Input.GetKeyDown(KeyCode.Alpha1)) currentRoom = "Lobby";
				if (Input.GetKeyDown(KeyCode.Alpha8)) currentRoom = "Eighth Floor";
				break;
			case ("Eighth Floor"):
				textBuffer += "\nHold [w] to tap NYU ID";
				if (Input.GetKey(KeyCode.W)) textBuffer += "\n\nYour ID isn't working\nThat's too bad";
				else textBuffer += "\nPress [s] to go back to the elevator\n\n";
				if (Input.GetKeyDown(KeyCode.S)) currentRoom = "Elevator";
				break;
		}

		GetComponent<TextMesh>().text = textBuffer;



	}
}
