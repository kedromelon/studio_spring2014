using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gaia : MonoBehaviour {

	public int numTreesToSpawn;

	public float range = 10f;

	public GameObject[] trees = new GameObject[5];

	List<GameObject> spawnedTrees = new List<GameObject>();

	// Use this for initialization
	void Start () {

		MakeTrees();


	}

	void MakeTrees(){

		foreach (GameObject tree in spawnedTrees){
			Destroy(tree);
		}

		for (int i = 0; i < numTreesToSpawn; i++){
			GameObject tree;
			float randf = Random.Range(0f, 1f);
			if (randf < .25f){
				tree = trees[0];
			}else if(randf < .5f){
				tree = trees[1];
			}else if(randf < .7f){
				tree = trees[2];
			}else if(randf < .9f){
				tree = trees[3];
			}else{
				tree = trees[4];
			}
			
			Vector3 randVector = transform.position + Random.insideUnitSphere*range;
			randVector.y = transform.position.y;
			
			float randscale = Random.Range(.75f,1.25f);
			
			tree.transform.localScale = new Vector3(randscale,randscale,randscale);
			
			spawnedTrees.Add(Instantiate(tree, randVector, Quaternion.identity) as GameObject);
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space))
			MakeTrees();
	}

}
