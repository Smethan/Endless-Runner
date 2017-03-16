using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private float ShootWait = 0.8f;
    public GameObject Shot;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(EnemyShoot());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            Vector3 SpawnPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            Quaternion SpawnRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(Shot, SpawnPosition, SpawnRotation);
            //yield return new WaitForSeconds(ShootWait);
        }
    }

}
