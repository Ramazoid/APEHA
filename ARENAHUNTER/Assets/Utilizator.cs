using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilizator : MonoBehaviour
{
    
    void Start()
    {
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        Utilizer.Take(col.gameObject);
    }

  
}
