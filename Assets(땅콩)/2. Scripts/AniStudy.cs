using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniStudy : MonoBehaviour
{
    public int hash;
    public Animator anim;

    void Awake()
    {
        hash = Animator.StringToHash("Base Layer.Player_Run");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (anim.GetCurrentAnimatorStateInfo(0).nameHash == hash) // 해쉬값으로 찾기
        // {
        //     Debug.Log(2);
        // }

        // AnimatorTransitionInfo aaaaa = anim.GetAnimatorTransitionInfo(0);
        // if (aaaaa.IsUserName("Jump")) // Transition 의 이름 ( 화살표 )
        // {
        //     Debug.Log(1);
        // }

        AnimatorStateInfo aaa = anim.GetCurrentAnimatorStateInfo(0);
        // Debug.Log(aaa.IsName("Death")); // 이름으로 찾기
        Debug.Log(aaa.IsTag("Falling")); // 태그로 찾기
    }
}
