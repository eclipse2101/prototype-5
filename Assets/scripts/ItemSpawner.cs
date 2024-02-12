using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ItemSpawner : MonoBehaviour
{
    public float spawnRate = 1; 
    public List<GameObject> targets; 
    private int score; 
    public TextMeshProUGUI textScore; 
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true)
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
