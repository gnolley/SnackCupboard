using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {
	public GameObject console;
	public GameObject managerCollection;
	public AudioClip[] intros = new AudioClip[10];
	public AudioClip[] failIntros = new AudioClip[3];
	public AudioClip[] verbs = new AudioClip[4];
	public AudioClip[] adjectives = new AudioClip[4];
	public AudioClip[] nouns = new AudioClip[4];

	InstructionManager IMngr;
	GameManager GM;
	private int[] instructions;
	private AudioSource speaker;

	// Use this for initialization
	void Awake() {
		speaker = GetComponent<AudioSource>();
		IMngr = managerCollection.GetComponent<InstructionManager>();
		GM = managerCollection.GetComponent<GameManager>();
	}

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void sayIntro(string lastTaskOutcome) {
		if (lastTaskOutcome != "failed") {
			speaker.clip = intros[GM.GetCurrentTask() - 1];
		} else {
			speaker.clip = failIntros[GM.GetFails() - 1];
		}

		speaker.Play();

		if (GM.GetFails()  - 1 < 2) { // MAGIC NUMBER
			StartCoroutine("AfterIntro");
		}
	}

	private void UpdateConsole() {
		console.GetComponent<Console>().printInstruction(IMngr.verb, IMngr.colour, IMngr.interactable);
	}

	private IEnumerator AfterIntro() {
		yield return new WaitForSeconds(speaker.clip.length);
		speaker.clip = verbs[(int)IMngr.verb];
		speaker.Play();
		yield return new WaitForSeconds(verbs[(int)IMngr.verb].length);
		speaker.clip = adjectives[(int)IMngr.colour];
		speaker.Play();
		yield return new WaitForSeconds(adjectives[(int)IMngr.colour].length);
		speaker.clip = nouns[(int)IMngr.interactable];
		speaker.Play();
		managerCollection.GetComponent<GameManager>().StartCountDown();
		UpdateConsole();
	}
}
