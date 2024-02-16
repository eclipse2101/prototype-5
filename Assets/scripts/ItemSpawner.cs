using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class ItemSpawner : MonoBehaviour
{
    public float spawnRate = 1; 
    public List<GameObject> targets; 
    private int score; 
    public TextMeshProUGUI textScore; 
    public TextMeshProUGUI gameOverScreen; 
    public Button restartButton; 
    public bool gameActive;
    public GameObject titleScreen; 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    
    public void StartGame(int Difficulty)
    {
        
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0); 
        gameActive = true;
        titleScreen.gameObject.SetActive(false); 
        spawnRate /= Difficulty;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(gameActive)
        {
          yield return new WaitForSeconds(spawnRate);
          int index = Random.Range(0, targets.Count);
          Instantiate(targets[index]);
        }
    }

    public void UpdateScore (int scoreToAdd)
    {
       score += scoreToAdd;
       textScore.text = "Score:" + score;
    }
}
