using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMask : MonoBehaviour {
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.gameManager;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Head") {
			Destroy(this.gameObject);
			gameManager.StopGas();
		}
	} 
}
