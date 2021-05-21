using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poper : MonoBehaviour
{
    public RectTransform boom;
    private int hide;
    private static  Poper inst;

    void Start()
    {
        inst = this;
        inst.boom.gameObject.SetActive(false);
        hide = 3;
    }

    
    void Update()
    {
        if(--hide<=0)
            inst.boom.gameObject.SetActive(false);

    }

    internal static void Boom(GameObject go)
    {
        inst.boom.gameObject.SetActive(true);
        Vector3 pos = Camera.main.WorldToScreenPoint(go.transform.position);
        inst.boom.anchoredPosition = pos;
        inst.hide = 5;
    }
}
