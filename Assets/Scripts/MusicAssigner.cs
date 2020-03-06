using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicAssigner : MonoBehaviour
{
    public TextMeshPro text1;
    private AudioSource source;
    public AudioClip cannon; //set this in ispector with audiofile
    public AudioClip letItGo; //set this in ispector with audiofile
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm=UnityEngine.Object.FindObjectOfType<GameManager>();
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // if (gm.songID==0){
        //     text1.text = "CANNON";
        //     source.clip=cannon;
        // }
        // else{
        //     text1.text = "ELSA";
        //     source.clip=letItGo;
        // }
        // source.Play();
        if (gm.songID==0){
            text1.text = "CANNON";
            source.clip=cannon;
        }
        else{
            text1.text = "ELSA";
            source.clip=letItGo;
        }
        source.Play();
    }
}
