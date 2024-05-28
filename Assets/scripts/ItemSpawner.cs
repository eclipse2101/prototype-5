using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class ItemSpawner : MonoBehaviour
{
    public float spawnRate = 1; 
    public int Health = 3; 
    public List<GameObject> targets; 
    private int score; 
    public TextMeshProUGUI textScore; 
    public TextMeshProUGUI gameOverScreen; 
    public Button restartButton; 
    public bool gameActive;
    public GameObject titleScreen; 
    public TextMeshProUGUI healthUi; 
    public TextMeshProUGUI PauseScreen; 
    public Button ExitButton; 
    public bool Paused; 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameActive = false;
        restartButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
    }
    
    public void StartGame(float Difficulty)
    {
        
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0); 
        gameActive = true;
        titleScreen.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false); 
        spawnRate /= Difficulty;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Update is called once per frame
    void Update()
    {
        ///////Health/////////////
        if (Health == 0)
        {
         GameOver();
        }
        
        if(gameActive == true || Health >= 0)
        {
         healthUi.text = "Health: " + Health;
        }
        ///////Pause Function//////
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
          if(gameActive == true && Paused == false)
          {
          TimeStop(); // pause the game 
          }
        else
           {
            TimeResume(); // resume the game
           }
        }
        
        /*
        editors note: ZA WARUDO STOP TIME
        */
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
       textScore.text = "Score: " + score;
    }
    public void TimeStop()
    {
       Paused = true;
       Time.timeScale = 0f;
       PauseScreen.gameObject.SetActive(true);
       ExitButton.gameObject.SetActive(true); 
    }

    public void TimeResume()
    {
       Paused = false;
       Time.timeScale = 1f;
       PauseScreen.gameObject.SetActive(false);
       ExitButton.gameObject.SetActive(false); 
    }
}
