using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour
{
    public bool isPlayerDie;

    void OnEnable()
    {
        csPlayerCtrl.OnPlayerDie += this.OnPlayerDie;
        csPlayerCtrl.OnPlayerDie += this.Test1;
        csPlayerCtrl.OnPlayerDie += this.Test2;
        csPlayerCtrl.OnPlayerDie += this.Test3;
        csPlayerCtrl.OnPlayerDie += this.Test4;
    }

    void OnDisable()
    {
        csPlayerCtrl.OnPlayerDie -= this.OnPlayerDie;
        csPlayerCtrl.OnPlayerDie -= this.Test1;
        csPlayerCtrl.OnPlayerDie -= this.Test2;
        csPlayerCtrl.OnPlayerDie -= this.Test3;
        csPlayerCtrl.OnPlayerDie -= this.Test4;
    }
    //플레이어가 사망했을 경우 실행되는 함수
    //Enemy 스크립트에 Enemy가 더는 공격 루틴이나 추적 루틴을 타지 않도록 모든 코루틴 함수를 정지
    void OnPlayerDie()
    {
        // 공격 중지, 추적(네비게이션) 중지, 승리 애니메이션 스타트
        // 유한상태머신(FSM : Finite State Machine)=>  Enemy의 상태를 체크하는 코루틴 함수를 모두 정지 
        // StopAllCoroutines();
        isPlayerDie = true;
    }
    void Test1()
    {
        Debug.Log("Test1");
    }
    void Test2()
    {
        Debug.Log("Test2");
    }
    void Test3()
    {
        Debug.Log("Test3");
    }
    void Test4()
    {
        Debug.Log("Test4");
    }
}
