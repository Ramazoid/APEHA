using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDriver : MonoBehaviour
{
    public GameObject Tower;
    public GameObject Turrel;

    public Bullet Bullet;
    public float offsetHeight = 1;
    private Utilizator utilizer;
    private bool elevationDone;
    private bool fired;
    public  UIPUlseManager pulseManager;

    void Start()
    {
        utilizer = FindObjectOfType<Utilizator>();
        pulseManager = GetComponent<UIPUlseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Utilizer.Info();
        if (fired)
        {
            
            fired = false;
            Bullet.fire = true;
            Sounds.Play("shot", 0);

        }

        if (Input.GetMouseButton(0))
        {
            pulseManager.GoOut("HandTip");
            Bullet.Restart();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int mask = ~LayerMask.NameToLayer("Ground");
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity, mask))
            {

                Vector3 offset = new Vector3(0, 0, Tower.transform.localPosition.y + Tower.transform.parent.transform.position.y);

                float angle = Vector3.Angle(Camera.main.WorldToScreenPoint(Tower.transform.position), Input.mousePosition);

                Tower.transform.LookAt(hit.point + Vector3.up * offsetHeight);

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Bullet.Restart();
            // UnityEditor.EditorApplication.isPaused = true;
            fired = true;

            Bullet.utilizer = utilizer;
        }
        
    }
    internal void SETTurrelElevation(float elevation)
    {
        if (!elevationDone)
        {
            offsetHeight = elevation;
            elevationDone = true;

        }

    }
}
