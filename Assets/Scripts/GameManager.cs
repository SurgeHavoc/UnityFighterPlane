using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public int score;
    public int cloudsMove;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject coinPrefab;
    private GameObject pS;
    public int livesCount;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        InvokeRepeating("SpawnCoin", 5f, 10f);
        cloudsMove = 1;
        score = 0;
        pS = GameObject.Find("Player");
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + livesCount;
    }

    // Update is called once per frame
    void Update()
    {
        updateLives();
    }

    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 50; i++) 
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void updateLives()
    {
        livesCount = pS.GetComponent<Player>().lives;
        livesText.text = "Lives: " + livesCount;
    }
}
