using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button ModeChanger; 
    private ItemSpawner ItemSpawner; 
    public int Difficulty; 
    
    // Start is called before the first frame update
    void Awake()
    {
       ModeChanger = GetComponent<Button>();    
       ModeChanger.onClick.AddListener(SetDiffuclty);
       ItemSpawner = GameObject.Find("Item Spawner").GetComponent<ItemSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDiffuclty()
    {
        Debug.Log(gameObject.name + " was clicked");
        ItemSpawner.StartGame(Difficulty);
    }
}
