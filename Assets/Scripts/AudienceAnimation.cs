using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            anim.SetBool("isSitting", false);
            anim.SetBool("isClapping", true);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.SetBool("isClapping", false);
            anim.SetBool("isSitting", true);
        }
    }
}
