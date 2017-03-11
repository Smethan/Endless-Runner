using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    private float minX = -3f;
    private float maxX = 3f;
    private GameObject newProjectile;
    private float nextFire = 0.5F;
    private int PowerLength = 5;

    public float MoveSpeed;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireDelta = 0.5F;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
  // void FixedUpdate ()
   // {
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");
   //     Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
   //     rb.velocity = movement * MoveSpeed;
   // }

    void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.localPosition.x - 3, transform.localPosition.y, transform.localPosition.z);
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.localPosition.x + 3, transform.localPosition.y, transform.localPosition.z);

        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireDelta;
           Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.localPosition.y,transform.localPosition.z);
        // GetComponentInChildren<Transform>().position = transform.position;
    }

    public void PowerUpPlayer()
    {
        StopCoroutine(PowerUpTime());
        StartCoroutine(PowerUpTime());
    }

    IEnumerator PowerUpTime ()
    {
        fireDelta = 0.01f;
        yield return new WaitForSeconds(5f);
        fireDelta = 0.5f;
        
    }
    

	// Update is called once per frame

}
