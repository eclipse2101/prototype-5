using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody itemRb;
    // Start is called before the first frame update
    void Start()
    {
        itemRb = GetComponent<Rigidbody>();
        itemRb.AddForce (Vector3.up * Random.Range(12,16), ForceMode.Impluse); 
        itemRb.AddTorque(Random.Range(-10,10), Random.Range(-10,10), Random.Range(-10,10), ForceMode.Impluse);
        transform.position = new Vector3(Random.Range(-4,4), -6); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(12,16);
    } 
    
        
}
