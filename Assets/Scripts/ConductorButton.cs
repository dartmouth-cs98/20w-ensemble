using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorButton : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    bool playing = false;

    public AudioSource applause;
    bool ended = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!music.isPlaying && playing) {
            if(!ended) {
                endAll();
                ended = true;
            }
            
        }
    }

    public void playAll() {
        playing = true;
        Animator conductorAnim = this.gameObject.GetComponent<Animator>();
        conductorAnim.SetBool("is_playing", true);

    	GameObject[] violinists = GameObject.FindGameObjectsWithTag("violinist");
    	foreach(GameObject violinist in violinists) {
    		Animator anim = violinist.GetComponent<Animator>();
    		anim.SetBool("is_playing", true);
    	}

    	GameObject[] cellists = GameObject.FindGameObjectsWithTag("cellist");
    	foreach(GameObject cellist in cellists) {
    		Animator anim = cellist.GetComponent<Animator>();
    		anim.SetBool("is_playing", true);
    	}

        GameObject[] conductors = GameObject.FindGameObjectsWithTag("conductor");
        foreach(GameObject conductor in conductors) {
            Animator anim = conductor.GetComponent<Animator>();
            anim.SetBool("is_playing", true);
        }
    }

    public void pauseAll() {
        playing = false;
        Animator conductorAnim = this.gameObject.GetComponent<Animator>();
        conductorAnim.SetBool("is_playing", false);

        GameObject[] violinists = GameObject.FindGameObjectsWithTag("violinist");
        foreach(GameObject violinist in violinists) {
            Animator anim = violinist.GetComponent<Animator>();
            anim.SetBool("is_playing", false);
        }

        GameObject[] cellists = GameObject.FindGameObjectsWithTag("cellist");
        foreach(GameObject cellist in cellists) {
            Animator anim = cellist.GetComponent<Animator>();
            anim.SetBool("is_playing", false);
        }

        GameObject[] conductors = GameObject.FindGameObjectsWithTag("conductor");
        foreach(GameObject conductor in conductors) {
            Animator anim = conductor.GetComponent<Animator>();
            anim.SetBool("is_playing", false);
        }
    }

    public void endAll() {
        // Animator conductorAnim = this.gameObject.GetComponent<Animator>();
        // conductorAnim.SetBool("is_playing", false);

        GameObject[] violinists = GameObject.FindGameObjectsWithTag("violinist");
        foreach(GameObject violinist in violinists) {
            Animator anim = violinist.GetComponent<Animator>();
            // anim.SetBool("is_playing", false);
            anim.SetBool("done_playing", true);
        }

        GameObject[] cellists = GameObject.FindGameObjectsWithTag("cellist");
        foreach(GameObject cellist in cellists) {
            Animator anim = cellist.GetComponent<Animator>();
            // anim.SetBool("is_playing", false);
            anim.SetBool("done_playing", true);
        }

        GameObject[] conductors = GameObject.FindGameObjectsWithTag("conductor");
        foreach(GameObject conductor in conductors) {
            Animator anim = conductor.GetComponent<Animator>();
            // anim.SetBool("is_playing", false);
            anim.SetBool("done_playing", true);
        }

        GameObject[] audiences = GameObject.FindGameObjectsWithTag("audience");
        foreach(GameObject mem in audiences) {
            Animator anim = mem.GetComponent<Animator>();
            anim.SetBool("isClapping", true);
            anim.SetBool("isSitting", false);
        }

        applause.Play();
        


    }
}
