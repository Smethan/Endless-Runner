using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroy : MonoBehaviour {

    public int scoreValue;
    private GameController gameController;

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
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Boundary")
        {
            return;
        }

    }
}
