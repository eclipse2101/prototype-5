using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody itemRb;
    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float maxTorque = 10; 
    public float xRange = 4;
    public float ySapwnPos = -6;
    private ItemSpawner itemSpawner; 
    public int pointscore; 
    public ParticleSystem explosionParticle; 

    // Start is called before the first frame update
    void Start()
    {
        itemRb = GetComponent<Rigidbody>();
        itemRb.AddForce (RandomForce(), ForceMode.Impulse); 
        itemRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        itemSpawner = GameObject.Find("Item Spawner").GetComponent<ItemSpawner>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    } 

    Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange,xRange), ySapwnPos); 
    }

    float RandomTorque()
    {
       return Random.Range(-maxTorque, maxTorque);
    }

    private void OnMouseDown()
    {
        if(itemSpawner.gameActive)
        {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        itemSpawner.UpdateScore(pointscore);
        }
    }

    private void OnTriggerEnter()
    { 
         if (!gameObject.CompareTag("Bad"))
         {
            itemSpawner.GameOver();
         }
         Destroy(gameObject);
    }

}
