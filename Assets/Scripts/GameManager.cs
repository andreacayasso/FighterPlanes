using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    private int score = 0;
    private int lives = 3;
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public int cloudsMove;

    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if (instance == null)
        {
           instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;     
        }
    
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned in the GameManager script.");
        }
        if (livesText == null)
        {
            Debug.LogError("Lives Text is not assigned in the GameManager script.");

        }

    }

    void Update()
    {
        // You can add code for handling coin appearance and destruction here
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
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
        // Add any additional Game Over functionality here
    }

    public void EarnScore(int scoreToAdd)
    {
        score +=scoreToAdd;

        if(scoreText !=null)
        {

        scoreText.text = "Score: " + score;
        }
}

    public void UpdateLives(int newLives)
    {
        lives = newLives;
        if(livesText !=null)

        {

            livesText.text = "Lives: " + lives;
        }
    }

}
