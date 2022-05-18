using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    int score = 0;
    public Text scoreText;
    public GameObject readyText;
    public GameObject gameoverText;
    public bool isPlayerAlive = true;

    void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 3.0f);
        readyText.SetActive(false);
        gameoverText.SetActive(false);
        StartCoroutine(showReady());
    }

    public void ShowGameOver()
    {
        gameoverText.SetActive(true);
    }

    public void KillPlayer()
    {
        isPlayerAlive = false;
        csSpawnManager.isSpawn = false;
        ShowGameOver();
    }

    void StartGame()
    {
        csPlayer.canShoot = true;
        csSpawnManager.isSpawn = true;
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "Score : " + this.score;
    }

    IEnumerator showReady()
    {
        int count = 0;
        while (count < 3)
        {
            readyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            readyText.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            count++;
        }
    }


    ////// 다시 시작 //////

    void RestartReady()
    {
        player.transform.position = new Vector3(0,-0.84f,0);
        gameoverText.SetActive(false);
        player.SetActive(true);
        StartCoroutine(showReady());
    }

    public void InitGame()
    {
        csObjectManager.instance.Clearbullets();
        csObjectManager.instance.ClearEnemies();
        score = 0;
        scoreText.text = string.Empty;
        Invoke("StartGame", 3.0f);
        RestartReady();
        // RestartReady();
        // StartGame();
    }

    
    // Update is called once per frame
    void Update()
    {

    }
}
