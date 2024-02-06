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

    // Start is called before the first frame update
    void Start()
    {
        itemRb = GetComponent<Rigidbody>();
        itemRb.AddForce (RandomForce(), ForceMode.Impulse); 
        itemRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos(); 
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
        Destroy(gameObject);
    }

    private void OnTriggerEnter()
    {
         Destroy(gameObject);
    }

}
