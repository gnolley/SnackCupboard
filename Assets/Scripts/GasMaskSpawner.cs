using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskSpawner : MonoBehaviour {
	public GameObject gasMask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnGasMask() {
		Instantiate(gasMask, transform.position, transform.rotation);
	}
}
