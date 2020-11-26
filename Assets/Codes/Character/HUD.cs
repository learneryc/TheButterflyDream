using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    public BoundObjects boundObjects;


    void Start () {
    	if (boundObjects == null)
    		boundObjects = GameObject.Find("Icons")
    						.GetComponent<BoundObjects>();
    }

    void Update() {
        HeartUI.sprite = HeartSprites[boundObjects.Player.curHealth];
    }
}
