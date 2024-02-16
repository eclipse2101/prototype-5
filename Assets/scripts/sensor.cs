using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    private ItemSpawner itemSpawner; 
    
    // Start is called before the first frame update
    void Start()
    {
        itemSpawner = GameObject.Find("Item Spawner").GetComponent<ItemSpawner>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    { 
         if (!gameObject.CompareTag("Bad"))
         {
            itemSpawner.GameOver();
         }
         if (!gameObject.CompareTag("Instant death"))
         {
            itemSpawner.GameOver();
         }
         Destroy(gameObject);
    }
}
