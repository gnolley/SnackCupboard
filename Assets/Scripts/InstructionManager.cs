using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *ACTIONS - Start with BLER
 *Slide = bler-skoon, Pull = bler-shick, Rotate = bler-merl, Push = bler-fresk
 *
 *DESCRIPTIONS - end with ERN
 *Red = ting-ern, Green = lend-ern, Yellow = wolt-ern, Blue = zun-ern,
 *
 *OBJECTS - Have MIK in the middle
 *Lever = gren-mik-to, Button = Com-mik-do, Dial = pring-mik-ha, Slider = ad-mik-mi
 */

public class InstructionManager : MonoBehaviour {
	private const int VERB_COUNT = 4;
	private const int ADJECTIVE_COUNT = 4;
	private const int NOUN_COUNT = 4;

	public Actions.Verbs verb;
	public Actions.Colour colour;
	public Actions.Interactable interactable;

	public GameObject speaker;
	
	// Update is called once per frame
	void Update () {

	}

	public void NewInstructions(string lastTaskOutcome = "won") {
		CreateInstructions();
		speaker.GetComponent<Speaker>().sayIntro(lastTaskOutcome);
	}

	private void CreateInstructions() {
		verb = (Actions.Verbs)Random.Range(0,3);
		colour = (Actions.Colour)Random.Range(0, 3);

        // Choose the interaction based on the verb
        interactable = verb == Actions.Verbs.ROTATE ? Actions.Interactable.DIAL : verb == Actions.Verbs.SLIDE ?
            Actions.Interactable.SLIDER : verb == Actions.Verbs.PULL ? Actions.Interactable.LEVER :
                Random.Range(0, 1) == 0 ? Actions.Interactable.BUTTON : Actions.Interactable.LEVER;

	}
}
