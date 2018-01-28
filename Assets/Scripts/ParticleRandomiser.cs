using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRandomiser : MonoBehaviour {

    AudioSource SoundEffect;

	// Use this for initialization
	void Start () {
		StartCoroutine("RandomParticleEvent");
	}
	
	// Update is called once per frame
	void Update () {

	}

	private IEnumerator RandomParticleEvent() {
		while (true) {
			yield return new WaitForSeconds(Random.Range(1f, 3.5f));
            if (SoundEffect != null)SoundEffect.Play();
			GetComponent<ParticleSystem>().Play();
		}
	}
}
