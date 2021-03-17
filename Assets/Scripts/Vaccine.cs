using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    
    
    
    // we need speed variable
    [SerializeField] 
    private float _vaccineSpeed = 8f;
    

    // Update is called once per frame
    void Update()
    {
        // use translate function to move the vaccine up! 
        transform.Translate(Vector3.up * _vaccineSpeed * Time.deltaTime);
    }
}


