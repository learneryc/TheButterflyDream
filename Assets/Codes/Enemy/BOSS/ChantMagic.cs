using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChantMagic : MonoBehaviour
{

    public GameObject magic;
    public Transform[] pos;
    private Animator anim;
     // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Chant();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chant()
    {
        StartCoroutine(Magic());
        
    }
    IEnumerator Magic()
    {
        yield return new WaitForSeconds(1f);
        for(int i =0;i< pos.Length;i++)
        {
            //yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            Instantiate(magic,new Vector2(pos[i].position.x + Random.Range(0f, 1f) - 0.5f,pos[i].position.y),Quaternion.identity);
            Instantiate(magic,new Vector2(pos[i].position.x + Random.Range(0f, 1f) - 0.5f,pos[i].position.y +Random.Range(1f, 3f) ),Quaternion.identity);

        }
        yield return new WaitForSeconds(3f);
        for(int i =0;i< pos.Length;i++)
        {
            //yield return new WaitForSeconds(Random.Range(0f, 0.5f));
            Instantiate(magic,new Vector2(pos[i].position.x + Random.Range(0f, 1f) - 0.5f,pos[i].position.y + 0.5f ),Quaternion.identity);
            Instantiate(magic,new Vector2(pos[i].position.x + Random.Range(0f, 1f) - 0.5f,pos[i].position.y + Random.Range(1f, 6f) ),Quaternion.identity);

        }
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("Sit");
    }

    public void Sit()
    {
        StartCoroutine(toChant());
    }
    IEnumerator toChant()
    {
        yield return new WaitForSeconds(10f);
        anim.SetTrigger("Chant");
    }
    
}
