using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    //레그돌의 각 관절에 추가된 Rigidbody 컴포넌트 연결 배열 
    Rigidbody[] rbody;
    Animation _anim;

    // Use this for initialization
    void Start()
    {

        //애니메이션 컴포넌트 연결 
        _anim = GetComponentInChildren<Animation>();

        // 애니메이션 플레이
        _anim.Play();

        //각 관절에 추가된 Rigidbody 컴포넌트를 배열에 저장 
        rbody = GetComponentsInChildren<Rigidbody>();
        //Ragdoll 비활성화 
        SetRagdoll(false);

        //일정 시간이 지난 뒤에 Ragdoll을 활성화하는 코루틴 함수 호출 
        StartCoroutine(this.WakeupRagdoll());


    }

    //Ragdoll 활성화/비활성화하는 함수 
    void SetRagdoll(bool isEnable)
    {
        //배열에 저장된 모든 Rigidbody 컴포넌트의 isKinematic 옵션을 셋팅 
        foreach (Rigidbody _rbody in rbody)
        {
            _rbody.isKinematic = !isEnable;
        }
    }

    //일정 시간이 지난 후 Ragdoll을 활성화하는 코루틴 함수 
    IEnumerator WakeupRagdoll()
    {
        // 5초 대기 후
        yield return new WaitForSeconds(5.0f);
        // 애니메이션 종료
        _anim.Stop();
        //Ragdoll 활성화
        SetRagdoll(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}