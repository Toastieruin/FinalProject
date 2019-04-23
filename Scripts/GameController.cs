using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject[] powerup;
    public Vector3 spawnValues;
    public Vector3 powerValues;
    public int powerCount;
    public int hazardCount;
    public float powerWait;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    public bool gameOver;
    private bool restart;
    private int score;

    public static GameController Instance;

    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;

    private AudioSource audioSource;
    private bool paused1;
    private bool paused2;
    private bool paused3;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        audioSource = GetComponent<AudioSource>();
        paused1 = true;
        paused2 = true;
        paused3 = true;
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("Main");
            }
        }
        if (paused1 && paused3 && paused2)
        {
            audioSource.clip = song1;
            audioSource.Play(0);
            paused1 = false;
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            for (int p=0; p < powerCount; p++)
            {
                GameObject powerups = powerup[Random.Range(0, powerup.Length)];
                Vector3 powerPosition = new Vector3(powerValues.x, powerValues.y, powerValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(powerups, powerPosition, spawnRotation);
                yield return new WaitForSeconds(powerWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 200)
        {
            winText.text = "You Win!\n Game Created\n by\n Corey Gillian";
            gameOver = true;
            restart = true;
            if (paused2 && paused3)
            {
                paused1 = true;
                audioSource.clip = song2;
                audioSource.Play(0);
                paused2 = false;
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!\n Game Created\n by\n Corey Gillian";
        gameOver = true;
        if (paused2 && paused3)
        {
            paused1 = true;
            audioSource.clip = song3;
            audioSource.Play(0);
            paused3 = false;
        }
    }
}