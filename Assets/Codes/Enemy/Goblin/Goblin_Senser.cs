using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Senser : MonoBehaviour
{

    public Goblin_Bass m_MonBass;
    private BoxCollider2D  m_touchSensor;
    private CircleCollider2D m_touchSensor2;
    // Start is called before the first frame update
    void Start()
    {
        m_touchSensor = GetComponent<BoxCollider2D>();
        m_touchSensor2 = GetComponent<CircleCollider2D>();
        //m_MonBass = this.transform.root.GetComponent<Goblin_Mon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            m_MonBass.Current_Tartget = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            m_MonBass.Current_Tartget = null;
        }
    }
}
