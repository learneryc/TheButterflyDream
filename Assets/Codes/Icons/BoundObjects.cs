using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundObjects : MonoBehaviour
{
    public Swordman Player;
    public PlayerMagicAttack PlayerMagic;

    void Start() {
    	if (Player == null)
    		Player = BindPlayer();

    	if (PlayerMagic == null)
    		PlayerMagic = BindPlayerMagic();
    }

    public Swordman BindPlayer(string name = "Jack") {
        return GameObject.Find(name).GetComponent<Swordman>();
    }

    public PlayerMagicAttack BindPlayerMagic(string name = "Jack") {
        return GameObject.Find(name).GetComponent<PlayerMagicAttack>();
    }

    public void getHeal() {
    	PlayerMagic.getHeal();
    }

    public void SwordmanAttack() {
        Player.attack();
    }

    public void SwordmanJump() {
        Player.jump();
    }
}
