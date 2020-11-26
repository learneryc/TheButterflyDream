using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = PlayerPrefs.GetInt("potionCounter", 0).ToString();
    }
}
