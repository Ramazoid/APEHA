using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] clips;
    private static Sounds inst;
    private  AudioSource player;

    void Start()
    {
        inst = this;
        inst.player = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    internal static void Play(string clipname,int variants)
    {
        if(variants!=0)
        inst.player.clip = FindClip(clipname + UnityEngine.Random.Range(1, variants));
        else
            inst.player.clip = FindClip(clipname);

        inst.player.Play();
        
    }

    private static AudioClip FindClip(string clipname)
    {
        AudioClip clip = Array.Find<AudioClip>(inst.clips, (clip) => { return clip.name == clipname; });


        return clip;
    }
}
