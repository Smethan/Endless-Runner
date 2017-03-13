using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroy : MonoBehaviour {

    public int scoreValue;
    private GameController gameController;
    public GameObject Enemyexplosion;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Instantiate(Enemyexplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            other.GetComponent<PlayerMovement>().GameOver = true;
        }
        if (other.tag == "Boundary")
        {
            return;
        }

    }
}
