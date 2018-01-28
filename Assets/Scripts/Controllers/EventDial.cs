using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.UnityEventHelper;

public class EventDial : MonoBehaviour {
    private VRTK_Control_UnityEvents dialEvent;
    private GameManager GM;
    public Actions.Colour colour;

    private float timer = 1.5f;
    bool canSend = true;

    // Use this for initialization
    void Start()
    {
        dialEvent = GetComponent<VRTK_Control_UnityEvents>();
        dialEvent.OnValueChanged.AddListener(dialMove);
        GM = GameManager.gameManager;
    }

    /// <summary>
    /// Called when the dial is pushed or pulled, basic logic to send to Game Manager
    /// </summary>
    /// <param name="sender"> Object event sent from</param>
    /// <param name="e"> Event. In this case onValueChange </param>
    private void dialMove(object sender, VRTK.Control3DEventArgs e)
    {
        if (canSend)
        {
            GM.UsedItem(Actions.Verbs.ROTATE, colour, Actions.Interactable.DIAL);
            StartCoroutine("Timer");
        }
    }

    IEnumerator Timer()
    {
        canSend = false;
        yield return timer;
        canSend = true;
    }
}
