using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceAnimation : MonoBehaviour
{
    Animator anim;
    public int gender;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        int pickAnumber = Random.Range(1, 5);
        // anim.SetInteger("sittingPose", pickAnumber);
        anim.SetInteger("sittingPose", pickAnumber);
        anim.SetInteger("gender", gender);
        anim.SetBool("isSitting", true);
        //int pickAnumber2 = Random.Range(10, 13);
        //anim.SetInteger("clappingPose", pickAnumber2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) // go to cheering
        {
            anim.SetBool("isSitting", false);
            anim.SetBool("isClapping", true);

        }
        if (Input.GetKeyDown("2")) // go back to sitting
        {
            anim.SetBool("isClapping", false);
            anim.SetBool("isSitting", true);
        }


    }
}
