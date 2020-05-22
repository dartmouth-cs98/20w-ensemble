using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAll() {
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

        GameObject[] audiences = GameObject.FindGameObjectsWithTag("audience");
        foreach(GameObject mem in audiences) {
            Animator anim = mem.GetComponent<Animator>();
            anim.SetBool("isClapping", true);
            anim.SetBool("isSitting", false);
        }


    }
}
