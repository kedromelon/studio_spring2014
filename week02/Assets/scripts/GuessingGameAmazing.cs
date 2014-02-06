using UnityEngine;
using System.Collections;

// THIS CODE IS FULL OF ERRORS! DEBUG IT!

// 0) first, copy and paste this into a file in a Unity project
// 1) read the comments and variable names to figure out the coder's intention
// 2) go to the "Console" tab in Unity, look for stop sign icons -- these are code compile errors.
//	  the error will tell you the filename, then the line number and column, e.g. "GuessingGame.cs (8,100)"
// 3) double-click on an error in the Console to go to it in MonoDevelop
// 4) look at the line it specified, look around it, look at the lines before it -- it's just a hint
// 5) guess what the computer science-y words mean!
// 6) you may need to do some scene setup / configuration to fix this!

public class GuessingGameAmazing : MonoBehaviour {
	
	int guess = 0; // this is the number the player is guessing
	int secretNumber; // this is the number we have to guess
	string instructions;
	TextMesh textmesh;

	// Use this for initialization
	void Start () {
		// at the beginning of the game, generate a random number from 0 to 20
		secretNumber = Random.Range(0, 21);
		textmesh = GetComponent<TextMesh>();
		instructions = "PRESS SPACEBAR TO GUESS\nPRESS ARROW KEYS TO EDIT GUESS:\n";
		textmesh.text = instructions;
	}

	// Update is called once per frame
	void Update () {

		// push left arrow to decrease guess
		if ( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
			guess -= 1;
			textmesh.text = instructions + guess.ToString(); // change Text Mesh text
		}
		
		// push right arrow to increase guess
		if ( Input.GetKeyDown( KeyCode.RightArrow ) ) {
			guess += 1;
			textmesh.text = instructions + guess.ToString(); // change Text Mesh text
		}
		
		// if player presses spacebar, then evaluate the guess
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			if ( guess > secretNumber ) { 
				textmesh.text = "your guess was too high"; // change Text Mesh text
			} else if ( guess < secretNumber ) {
				textmesh.text = "your guess was too low"; // change Text Mesh text
			} else {
				textmesh.text = "YOU WIN, YOU ARE THE BEST"; // change Text Mesh text
			}
		}
	}

}