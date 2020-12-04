using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
	public float speed = 0.8f;
	public bool pause = false;
	public int pauseAngle = 1;
	public int pauseTime = 60;
	private Vector3 rotationChange;
	private int angle = 0;
	private int rIterator = 0;
	private bool pauseRotation=false;

	public float scale = -0.1f;
	public int size = 80;
	private Vector3[] scaleChange;
	private int sIterator = 0;

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
    	if (pause) {
    		if (pauseRotation) {
    			if (rIterator == pauseTime) {
    				pauseRotation = false;
    				rIterator = 0;
    			}
    			rIterator++;
    		} else {
    			this.transform.Rotate(rotationChange);
    			angle = (angle+(int)speed)%pauseAngle;
    			if (angle == 0) {
    				pauseRotation = true;
    			}
    		}
    	} else {
			this.transform.Rotate(rotationChange);
		}
        this.transform.localScale += scaleChange[sIterator];
        sIterator = (sIterator+1)%size;

        if (fadingColor) fadeColor();
    }

    void fadeColor() {
    	image.color += colorChange[fIterator];
    	fIterator = (fIterator+1)%fadingFactor;
    }
}
