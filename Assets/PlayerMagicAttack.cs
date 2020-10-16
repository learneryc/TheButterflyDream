using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    public GameObject fireAttack;
    private Swordman player;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Swordman>();
    }

    // Update is called once per frame
     void Update()
     {
        if (Input.GetKeyDown(KeyCode.R))
        {
                Instantiate(fireAttack, firePoint.position, firePoint.rotation);
            
        }
     }
}
