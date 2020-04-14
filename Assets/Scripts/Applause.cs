using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Applause : MonoBehaviour
{
    AudioSource applauseSound;
	public AudioSource song;
	public Animator anim;
    public bool startApplause;
    // Start is called before the first frame update
    void Start()
    {
        applauseSound = GetComponent<AudioSource>();


        anim = GetComponent<Animator>();
        int pickAnumber = Random.Range(1, 6);
        Debug.Log(pickAnumber);
        anim.SetInteger("sittingPose", pickAnumber);
        anim.SetBool("isSitting", true);
        int pickAnumber2 = Random.Range(1, 8);
        anim.SetInteger("clappingPose", pickAnumber2);

        startApplause = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (startApplause)
        {
            startApplause = false;
            StartCoroutine(Applaud());
        }


    }
    IEnumerator Applaud()
    {
        Debug.Log("hey");
        applauseSound.Play();
        anim.SetBool("isSitting", false);
        anim.SetBool("isClapping", true);
        yield return new WaitWhile(() => applauseSound.isPlaying);
        anim.SetBool("isClapping", false);
        anim.SetBool("isSitting", true);
    }
}
