using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelloAnimations : MonoBehaviour
{
	public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        int pickAnumber = Random.Range(0, 2);
        anim.SetInteger("cello_type", pickAnumber);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
