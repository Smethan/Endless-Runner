using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float ShootWait = 0.8f;
    public GameObject Shot;
    public int health;
    // Use this for initialization
    void Awake()
    {
        StartCoroutine(Shooter());
    }

    // Update is called once per frame
    public void SubtractHealth(int AmntToSubtract)
    {
        health -= AmntToSubtract;
    }

    IEnumerator Shooter()
    {
        while(true) {
            EnemyShoot();
            yield return new WaitForSeconds(ShootWait);
        }

        yield return 0;
    }

    void EnemyShoot()
    {
        Vector3 SpawnPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Quaternion SpawnRotation = Quaternion.Euler(90, 0, 0);
        Instantiate(Shot, SpawnPosition, SpawnRotation);
    }

}
