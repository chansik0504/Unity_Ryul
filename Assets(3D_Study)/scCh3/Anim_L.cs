using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 클래스는 [System.Serializable] Attribute를 명시 하여야
 * Inspector 뷰에 노출 
 */
[System.Serializable]
//애니메이션 클립을 저장할 클래스 
public class Anim
{
    public AnimationClip idle;
    public AnimationClip run;
    public AnimationClip attack1;
    public AnimationClip attack2;
    public AnimationClip attack3;
    public AnimationClip attack4;
    public AnimationClip hit1;
    public AnimationClip hit2;
}

public class Anim_L : MonoBehaviour {


    //인스펙터뷰에 노출시킬 Anim 클래스 변수 
    public Anim anims;

    //하위에 있는 모델의 Animation 컴포넌트에 접근하기 위한 레퍼런스
    private Animation _anim;

    //애니메이션 상태 저장 
    AnimationState animStae;


    // Use this for initialization
    void Start () {

        //자신의 자식에 있는 Animation 컴포넌트를 찾아와 레퍼런스에 할당 
        _anim = GetComponentInChildren<Animation>();
        //Animation 컴포넌트의 clip속성에 idle 애니메이션 클립 지정 
        _anim.clip = anims.idle;
        //지정한 애니메이션 클립(애니메이션) 실행 
        _anim.Play();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("a") )
        {
            Debug.Log("Attack1");
            _anim["Attack1"].speed = 0.5f;
            _anim.CrossFade(anims.attack1.name, 0.35f);

        }
        else if(Input.GetKeyDown("b"))
        {
            Debug.Log("Attack1");
            _anim["Attack1"].speed = 1.0f;
            _anim.CrossFade(anims.attack1.name, 0.35f);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Attack1");
            _anim["Attack1"].speed = 2.0f;
            _anim.CrossFade(anims.attack1.name, 0.35f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Attack1");
            _anim.CrossFade(anims.attack1.name, 0.35f);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //속도제어 No
            _anim[anims.attack1.name].speed = 2.0f; // 안먹음 why?
            _anim.PlayQueued(anims.attack1.name, QueueMode.PlayNow);
            _anim.PlayQueued(anims.attack2.name, QueueMode.CompleteOthers);
            _anim.PlayQueued(anims.attack3.name, QueueMode.CompleteOthers);
            animStae = _anim.PlayQueued(anims.attack4.name, QueueMode.CompleteOthers);
            //속도 제어 ok
            animStae.speed = 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _anim.CrossFade(anims.attack4.name, 0.35f);
        }
    }
}