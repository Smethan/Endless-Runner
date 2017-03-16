using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private float ShootWait = 0.8f;
    public GameObject Shot;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shooter;
    }

    IEnumerator Shooter()
    {
        while(true) {
            EnemyShoot;
            yield return new WaitForSeconds(1f);
        }

        yield return 0;
    }

    void EnemyShoot()
    {
        Vector3 SpawnPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Quaternion SpawnRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(Shot, SpawnPosition, SpawnRotation);
    }

}
