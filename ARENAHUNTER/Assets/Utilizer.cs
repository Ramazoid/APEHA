using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilizer : MonoBehaviour
{
    
    public Stack<GameObject> spherePool = new Stack<GameObject>();
    public Stack<GameObject> CubePool = new Stack<GameObject>();
 
    private static Utilizer inst;

    void Start()
    {
        inst = this;
    }

    internal static void Take(GameObject go)
    {
        if (go.name.Contains("Sphere"))
        {
            inst.spherePool.Push(go);

            Off(go);
        }

        else if (go.name.Contains("Cube"))
        {
            inst.CubePool.Push(go);

            Off(go);
        }

        else if (go.name.Contains("Bullet"))
        {
            go.GetComponent<Bullet>().Restart(true);
        }
    }

    internal static void Info()
    {
        print("cubePool Count=" + inst.CubePool.Count);
    }

    private static void Off(GameObject go)
    {
        go.transform.position = new Vector3(-1000, -1000, 0);
        go.SetActive(false);
    }
    void Update()
    {
    }

    public GameObject GetRabbit(string name)
    {
        switch (name)
        {
            case "Sphere":
                if (spherePool.Count > 0)
                {
                    return spherePool.Pop();
                }
                else return null;
                break;
            case "Cube":
                if (CubePool.Count > 0)
                {
                    return CubePool.Pop();
                }
                else return null;
                break;
            default: return null;
        }

    }
    }

