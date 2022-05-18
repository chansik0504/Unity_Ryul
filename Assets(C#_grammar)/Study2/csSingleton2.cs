using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSingleton2 : MonoBehaviour
{
    //Debug.Assert() 테스트용 
    public GameObject assert;
    public static int a = 0;
    public int num = 100;


    /*
         문제점 현재 게임오브젝트가 계속해서 쌓이고...
         Singleton2 _instance 레퍼런스는,
         벌써 메모리에 올라갔기 때문에 추가적으로 생성은 안되고,
         새롭게 생성된 객체의 인스턴스만 바꿔치기 됨.
         따라서 num 값은 새롭게 생성된 num 값이기 때문에 증가되지 않음.
         결국 값도 증가하지 않고 스텍이 계속 낭비되어서 게임이 느려지고 튕기게 됨.
         해결책은 오픈씬~
    */
    private static csSingleton2 _instance = null;

    public static csSingleton2 Instance
    {
        get
        {
            if (_instance == null)
            {
                // c# 일 경우....
                // _instance = new CSingleton();

                //유니티 일 경우 MonoBehaviour 이거 땜에 동적 생성 안되니 Awake()에서 처리

                Debug.LogError("Singleton2 == null");

                /*
                 * LogError 는 중요한 변수가 null 이라면 Debug.LogError를 뛰워줘서 문제가 터져서
                 * 오류를 띄우기전에 알 수 있게해줌 (콘솔뷰의 error는 게임이 멈춤)
                 * 
                 * Debug.Assert()
                 * 객체에 연결된 script 에 많은 public GameObject 들을 노출시키고, 
                 * 다른 game object 들을 연결하게 된다. 그리고 이 연결을 종종 끊고 
                 * 다른 객체들을 연결하기도 하는데...
                 * 이런 과정들을 거치다보면 종종 실수로 객체의 연결이 끊어진 채 
                 * 지나치게 되기도 한다. 그러다가 나중에 릴리즈(개발버전) 후에 발견하거나, 특정 상황이 
                 * 되었을 때만 크래시를 내기도 한다. 주로 null exception 이 발생할 것 이다.
                 * 이를 방지하기 위해서 항상 Start() 에서 Debug.Assert() 를 이용해서 해당 객체의 
                 * 연결이 살아있는지를 확인하면 매우 편리하다. 그러면 빨리 문제를 확인할 수 있다.
                 * 빠른 문제 확인은 더 단단한 프로그래밍을 할 수 있게 도와줍니다.
                 * inspector 에서 가져오는 객체들은 항상 Start() 에서 assert 를 걸고 쓰는 
                 * 습관을 들이면 굿!!!
                 *
                */
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        Debug.Log(Instance);
        //이걸 해줘야하나 뭔가 불편...
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
       Debug.Assert(assert);
    }
}