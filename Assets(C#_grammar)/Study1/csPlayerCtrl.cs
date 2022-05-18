using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerCtrl : MonoBehaviour
{
    public delegate void PlayerDieHandler();
    
    // 어떠한 위치에서도 자기자신을 접근할수 있음, 함수도 어디서든 접근가능 ( Public + static )
    public static event PlayerDieHandler OnPlayerDie;
    public bool isPlayerDie;
    PlayerDieHandler test;

    //Player의 사망 처리 루틴 (플레이어가 사망했을때 적들에게 플레이어가 죽었다는 것을 알리는 함수)
    public void PlayerDie1()
    {
        Debug.Log("Player Die");

        // Enemy라는 Tag를 가진 모든 게임오브젝트 찾기
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //모든 적의 OnPlayerDie 함수를 순차적으로 호출 
        foreach (GameObject enemy in enemies)
        {
            enemy.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        }

        /*
         * foreach 반복문을 통해 순차적으로 공격중지 함수를 호출하는(SendMessage를 사용한 호출 방식) 
         * 방식은 스테이지에 적들이 아주 많다는 극단적인 상황을 가정한다면 순차적인 호출 방식은 
         * 비효율적(Delegate, Event 사용 이유)
         * 
         * 따라서 Event Driven(이벤트 구동)방식으로 변경하자.=> 플레이어가 사망했을 때 유니티 엔진에게
         * "내가 죽었다"라고 (통보) 알려주면 유니티시스템에서는 Event(이벤트)를 발생시킨다. 이때 이 이벤트에
         * 연결된 모든 적들이 해당 동작을 수행하게 하는 방식이 순차적으로 호출하는 방식보다 속도면에서
         * 효율적 이다.
         * 
         * cf) csEventStudy 스크립트 참조.
         */

    }

    public void PlayerDie2()
    {
        Debug.Log("Player Die");
        OnPlayerDie();
    }
}
