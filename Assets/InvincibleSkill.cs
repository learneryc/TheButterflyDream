using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleSkill : MonoBehaviour
{
    Swordman player;
    public GameObject foot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jack").GetComponent<Swordman>();
        foot = GameObject.Find("Foot");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(foot.transform.position.x,foot.transform.position.y + 0.8f);
    }

    public void startskill(){
        player.isInvulnerable = true;
    }
    public void endskill(){
        player.isInvulnerable = false;
    }
    public void desskill(){
        Destroy(gameObject);
    }
}
