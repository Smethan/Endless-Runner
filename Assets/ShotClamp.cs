using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotClamp : MonoBehaviour {
    private float minX = -3f;
    private float maxX = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mathf.Clamp(transform.localPosition.x, minX, maxX);
    }
}
