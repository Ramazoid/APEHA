using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 initPosition;
    private Quaternion initRotation;
    private Renderer ren;
    public bool fire;
    internal Utilizator utilizer;
    private bool restarted;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.localPosition;
        initRotation = transform.rotation;
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fire)
        {
            ren.enabled = true;
            transform.position += transform.forward * Time.deltaTime*10;
            //transform.Translate(transform.right* Time.deltaTime*5);
        }
    }

    internal void Restart(bool forced=false)
    {
        ren.enabled = false;
            fire = false;
            transform.localPosition = initPosition;
            
    }
    private void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Rabbit")
        {
            Poper.Boom(col.gameObject);
            Utilizer.Take(col.gameObject);
            
            Sounds.Play("pop",3);
        }

        }
}

