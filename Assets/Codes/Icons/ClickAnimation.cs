using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
	public float scale = -0.1f;
	public int size = 10;
	private Vector3[] scaleChange;
	private int sIterator;

	void Start() {
		float factor = 2*scale/size;
		scaleChange = new Vector3[size];
		Vector3 change = new Vector3(factor,factor,0f);
		for (int i=0;i<size/2;i++) {
			scaleChange[i] = change;
		}
		for (int i=(size+1)/2;i<size;i++) {
			scaleChange[i] = -change;
		}
		sIterator = size;
	}

    // Update is called once per frame
    void Update()
    {
    	if (sIterator == size) return;
        this.transform.localScale += scaleChange[sIterator];
        sIterator++;
    }

    public void Click() {
    	sIterator = 0;
    }
}
