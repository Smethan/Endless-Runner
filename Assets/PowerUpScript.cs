using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {
    
	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerMovement>().PowerUpPlayer();
            Destroy(gameObject);
        }
        if (col.tag == "Boundary")
        {
            return;
        }
        Destroy(gameObject);
    }
}
