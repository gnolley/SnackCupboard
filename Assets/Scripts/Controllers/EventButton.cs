//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.UnityEventHelper;

public class EventButton : MonoBehaviour {

    public Actions.Colour ButtonColour;
    private VRTK_Button_UnityEvents buttonEvents;
    private GameManager GM;
    public AudioSource buttonSound;

    /// <summary>
    /// Called by VRTK when this button had been pressed
    /// </summary>
    public void PushButton(object sender, VRTK.Control3DEventArgs e)
    {
        buttonSound.Play();
        Debug.Log("Button Pressed: " + ButtonColour.ToString());
        GM.UsedItem(Actions.Verbs.PUSH, ButtonColour, Actions.Interactable.BUTTON);
    }

    private void Start()
    {
        GM = GameManager.gameManager;
        buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
        buttonEvents.OnPushed.AddListener(PushButton);
    }
}
