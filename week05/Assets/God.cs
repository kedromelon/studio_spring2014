using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class God : MonoBehaviour {

	public Wanderer blueprint;

	List<Wanderer> FriendsList = new List<Wanderer>();

	// Use this for initialization
	void Start () {
		int friendCount = 100;

		for(int i = 0; i < friendCount; i++){
			FriendsList.Add(SpawnFriend());
		}
	}

	Wanderer SpawnFriend(){
		Wanderer newFriend = 
			Instantiate(blueprint, 
		            new Vector3(Random.Range(-5f,5f),
		            1f,
		            Random.Range(-5f,5f)), 
		            Quaternion.Euler(0f, Random.Range(0f,360f),0f)) as Wanderer;

		return newFriend;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)){
			foreach(Wanderer friend in FriendsList){
				friend.destination = new Vector3(0f,0f,0f);
			}
		}

		if (Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit = new RaycastHit();
			
			if (Physics.Raycast(ray, out rayHit, Mathf.Infinity)){
				foreach(Wanderer friend in FriendsList){
					friend.destination = rayHit.point;
				}
			}
		}

	}
}
