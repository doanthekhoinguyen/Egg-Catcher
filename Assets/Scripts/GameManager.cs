using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject egg;

    public Transform spawnPoint;

    Vector3 spawnPosition;  

    bool gameOver = false;

    public float eggSpawnRate;

    public float maxPos;

    int score = 0;

    public TextMeshProUGUI scoreText;

    public GameObject startUI;

    public GameObject gameoverUI;

    public GameObject basket;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPoint.position;
        //StartCoroutine("SpawnEggs");
        
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEgg()
    {
        float randomx = Random.Range(-maxPos, maxPos);

        spawnPosition.x = randomx;
        Instantiate(egg, spawnPosition, Quaternion.identity);

    }
     
    IEnumerator SpawnEggs()
    {
        while(true)
        {
            yield return new WaitForSeconds(eggSpawnRate);
            SpawnEgg();
        }
    } 

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        startUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
        basket.SetActive(true);

        StartCoroutine("SpawnEggs");

    }

    public void Gameover()
    {
        StopCoroutine("SpawnEggs");
        gameoverUI.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
