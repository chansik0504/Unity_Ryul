using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study1 : MonoBehaviour
{
    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        AnimatorTransitionInfo aaaaa = anim.GetAnimatorTransitionInfo(0);
        if (aaaaa.IsUserName("Rush"))
        {
            Debug.Log(1);
        }

        AnimatorStateInfo aaa = anim.GetCurrentAnimatorStateInfo(0);
        Debug.Log(aaa.IsName("Rush1"));
        // Debug.Log(aaa.IsTag("Rush2"));

        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).nameHash);

        if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.Rush1"))
        {
            Debug.Log(2);
        }

    }
}