using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicCDIcon1 : MonoBehaviour
{
    //FireBall
    public Button magicbtn;
    public Image mask;
    public Text cd;
    private float cdtime = 3f;
    private float cultime = 0f;
    public PlayerMagicAttack playermagic;
    // Start is called before the first frame update
    void Start()
    {
        magicbtn.onClick.AddListener(Onclickbtn);
        cdtime = playermagic.magic1CDTime;
        EndMagic();
    }

    // Update is called once per frame
    void Update()
    {
        if(magicbtn.interactable == false)
        {
            if(mask.fillAmount > 0f && mask.fillAmount <= 1.0f)
            {
                cultime += Time.deltaTime;
                mask.fillAmount = (cdtime - cultime) / cdtime;

                cd.text = Mathf.CeilToInt( cdtime - cultime).ToString();
            }

            if(mask.fillAmount == 0)
            {
                EndMagic();
            }
        }
    }

    public void Onclickbtn(){
  
        playermagic.FireBallAttack();
        StartMagic();
    }

    public void StartMagic(){
        mask.fillAmount = 1;
        magicbtn.interactable = false;
        cd.text = cdtime.ToString();
    }

    public void EndMagic(){
        mask.fillAmount = 0;
        magicbtn.interactable = true;
        cd.text = string.Empty;
        cultime = 0;
    }
}
