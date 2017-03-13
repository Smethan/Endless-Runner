using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject Hazard;
    public GameObject PowerUp;
    public int SpawnWait;
    public int StartWait;
    public int WaveWait;
    public int hazardCount;
    public Text ScoreText;
    public int Score;
    private float[] SpawnPoints;
    private PlayerMovement player;
    public Text GameOverText; 

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
        SpawnPoints = new float[3] { -3, 0, 3 };
        Score = 0;
        UpdateScore();
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerMovement>();
        }
        GameOverText.enabled = false;

    }
    void Update()
    {
        if (player.GameOver)
        {
            StopAllCoroutines();
            PlayerGameOver();
        }
    }
    void PlayerGameOver ()
    {
        GameOverText.enabled = true;
        //GameOverText.text = GameOverText.text + "Score: " + Score;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void UpdateScore()
    {
        ScoreText.text = "" + Score;
    }
    public void AddScore (int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }
	
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i ++)
            {
                Quaternion SpawnRotation = Quaternion.Euler(90, 0, 0);
                //Quaternion spawnRotation = Quaternion.identity;
                Vector3 Spawnposition = new Vector3(SpawnPoints[Random.Range(0, SpawnPoints.Length)], -18, 10);
                Vector3 SpawnpositionLow = new Vector3(SpawnPoints[Random.Range(0, SpawnPoints.Length)], -18.2f, 10);
                Instantiate(Hazard, Spawnposition, SpawnRotation);
                float RandomNum = Random.Range(0, 5000);
                if (Score % 1000 == 0)
                {
                    Instantiate(PowerUp, SpawnpositionLow, SpawnRotation);
                }
                Debug.Log(RandomNum);
                yield return new WaitForSeconds(SpawnWait);
                
            }
            yield return new WaitForSeconds(WaveWait);
        }
    }

}
