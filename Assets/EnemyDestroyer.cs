using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour {
    public int EnemyScoreValue;
    private GameController gameController;
    private PlayerMovement player;
    public GameObject Enemyexplosion;

    void Start()
    {
        GameObject PlayerMovementObject = GameObject.FindWithTag("Player");
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (PlayerMovementObject != null)
        {
            player = PlayerMovementObject.GetComponent<PlayerMovement>();
        }
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Enemy" && other.tag == "Shot")
        {
            if (gameObject.GetComponent<EnemyAI>().health > 0)
            {
                gameObject.GetComponent<EnemyAI>().SubtractHealth(player.shotdamage);
                Destroy(other.gameObject);
                Debug.Log(gameObject.GetComponent<EnemyAI>().health);
            }
            else
            {
                gameController.AddScore(EnemyScoreValue);
                Destroy(other.gameObject);
                Instantiate(Enemyexplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
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
