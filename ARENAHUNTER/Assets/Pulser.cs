using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulser : MonoBehaviour
{
    internal bool pulse;
   public bool fade;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (pulse)
        {
            transform.localScale += Vector3.one / 100;
            if (transform.localScale.x >=1)
                pulse = false;
        }
        if (fade)
        {
            transform.localScale -= Vector3.one / 100;
            if (transform.localScale.x <= 0.01f)
            {
                gameObject.SetActive(false);
                fade = false;
            }
        }

        
    }

    public void SetContent(string content)
    {
        GetComponent<Text>().text = content;
    }
}
