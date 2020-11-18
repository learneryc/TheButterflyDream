using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSwitch : MonoBehaviour
{
    public GameObject ActionButtons;
    public GameObject InteractionButtons;

    public void SwitchToInteraction() {
    	ActionButtons.SetActive(false);
    	InteractionButtons.SetActive(true);
    }
    public void SwitchToAction() {
    	ActionButtons.SetActive(true);
    	InteractionButtons.SetActive(false);
    }
}
