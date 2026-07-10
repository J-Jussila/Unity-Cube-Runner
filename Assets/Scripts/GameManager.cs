using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        // Repeat forever until the coroutine is stopped
        while (true)
        {
            // Random delay between 0.5 and 2 seconds.
            float waitTime = Random.Range(0.5f, 2f);
            // Pause the coroutine for chosen amount of time.
            yield return new WaitForSeconds(waitTime);
            // Create a new obstacle at the spawn point with no rotation.
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);

        StartCoroutine("SpawnObstacles");
        // Call ScoreUp() first time after 2 seconds,
        // then call it every 1 second after.
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
