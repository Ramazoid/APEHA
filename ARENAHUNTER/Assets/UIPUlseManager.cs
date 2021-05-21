using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPUlseManager : MonoBehaviour
{
    private static UIPUlseManager inst;
    public Pulser[] pulsers;
    void Start()
    {


    }

    void Update()
    {

    }

    public void GoIn(string pulserName, string content)
    {
        Pulser p = GetPulser(pulserName);
        if(content!=null)
            p.SetContent(content);
        p.transform.localScale = Vector3.one / 2;
        p.gameObject.SetActive(true);
        p.pulse = true;
    }

    private Pulser GetPulser(string pulserName)
    {
        Pulser p = Array.Find<Pulser>(pulsers, (pu) => { return pu.name == pulserName; });
        if (p == null)
        {
            throw new Exception($"Pulser not found[{pulserName}]");
        }

        return p;
    }

    internal void GoOut(string pulserName)
    {

        Pulser p = GetPulser(pulserName);
        p.fade = true;
    }

    public void Init()
    {
        pulsers = FindObjectsOfType<Pulser>();
        foreach (Pulser p in pulsers)
            p.gameObject.SetActive(false);

    }

    public void Redraw(string pulserName, string content)
    {
        Pulser p = GetPulser(pulserName);
        p.SetContent(content);
    }

}