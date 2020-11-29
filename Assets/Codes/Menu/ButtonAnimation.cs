using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
	public float speed = 0.8f;
	private Vector3 rotationChange;

	public float scale = -0.1f;
	public int size = 80;
	private Vector3[] scaleChange;
	private int rIterator = 0;

	public bool fadingColor = false;
	public int fadingFactor = 40;
	private Image image;
	private Color[] colorChange;
	private int fIterator = 0;
	void Start() {
		rotationChange=Vector3.back*speed;

		float factor = 2*scale/size;
		scaleChange = new Vector3[size];
		Vector3 change = new Vector3(factor,factor,0f);
		for (int i=0;i<size/2;i++) {
			scaleChange[i] = change;
		}
		for (int i=(size+1)/2;i<size;i++) {
			scaleChange[i] = -change;
		}

		image = GetComponent<Image>();
		Color color = (new Color(1,1,1,1)-image.color)/fadingFactor;
		colorChange = new Color[fadingFactor];
		for (int i=0;i<fadingFactor/2;i++) {
			colorChange[i] = color;
		}
		for (int i=(fadingFactor+1)/2;i<fadingFactor;i++) {
			colorChange[i] = -1*color;
		}


	}

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationChange);
        this.transform.localScale += scaleChange[rIterator];
        rIterator = (rIterator+1)%size;

        if (fadingColor) fadeColor();
    }

    void fadeColor() {
    	image.color += colorChange[fIterator];
    	fIterator = (fIterator+1)%fadingFactor;
    }
}
