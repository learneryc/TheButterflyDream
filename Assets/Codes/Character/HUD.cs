using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    public Swordman player;


    void Start () {
    }

    void Update() {
        //HeartUI.sprite = HeartSprites[player.curHealth];
    }
}
