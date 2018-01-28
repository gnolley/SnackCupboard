using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour {
	public GameObject[] debris = new GameObject[4];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnDebris() {
		Vector3 posOffset;
		for (int debrisNum = 0; debrisNum < 50; debrisNum++) {
			posOffset = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f));
			Instantiate(debris[Random.Range(0, debris.Length)], transform.position + posOffset, Random.rotation);
		}
	}
}
