﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Applause : MonoBehaviour
{
	AudioSource audioSource;
	public AudioSource song;
	public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     	audioSource = GetComponent<AudioSource>(); 
     	anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        float time = audioSource.time;

        if(time == 3f) {
        	anim.SetBool("isSitting", false);
            anim.SetBool("isClapping", true);
            audioSource.Play();
        }
    }
}
