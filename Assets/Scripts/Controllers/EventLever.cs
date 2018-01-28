using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.UnityEventHelper;

public class EventLever : MonoBehaviour {

    private VRTK_Control_UnityEvents leverEvent;
    private GameManager GM;
    public float pullTriggerAngle = 50f, pushTriggerAngle = -50f;
    public Actions.Colour colour;
    private float timer = 1.5f;
    bool canSend = true;

	// Use this for initialization
	void Start () {
        leverEvent = GetComponent<VRTK_Control_UnityEvents>();
        leverEvent.OnValueChanged.AddListener(LeverMove);
        GM = GameManager.gameManager;
	}
    
    /// <summary>
    /// Called when the lever is pushed or pulled, basic logic to send to Game Manager
    /// </summary>
    /// <param name="sender"> Object event sent from</param>
    /// <param name="e"> Event. In this case onValueChange </param>
    private void LeverMove(object sender, VRTK.Control3DEventArgs e)
    {
        if (canSend)
        {
            if (e.value < pushTriggerAngle) { GM.UsedItem(Actions.Verbs.PUSH, colour, Actions.Interactable.LEVER); StartCoroutine("Timer"); }
            if (e.value > pullTriggerAngle) { GM.UsedItem(Actions.Verbs.PULL, colour, Actions.Interactable.LEVER); StartCoroutine("Timer"); }

            }
    }

    IEnumerator Timer()
    {
        canSend = false;
        yield return timer;
        canSend = true;
    }

}
