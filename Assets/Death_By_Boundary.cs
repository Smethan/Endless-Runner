using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_By_Boundary : MonoBehaviour {
    public GameObject Boundary;
    
    void OnTriggerExit (Collider col)
    {
        Destroy(col.gameObject);
    }
}
