using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float z = 0;
    float x = 0;
    // Start is called before the first frame update
    void Start()
    {
        z = Random.Range(-9,9);
        x = Random.Range(-9,9);
        // transform.position = new Vector3(x,0.5f,z); 
        // transform.Translate(x,0.5f,z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
