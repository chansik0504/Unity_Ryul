using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDelegateButtStudy : MonoBehaviour
{
    // 버튼 동적 생성을 위한 방법(무명함수 복습)
    public GameObject obj;

    void Awake()
    {
        // 버튼 동적 생성을 위한 로직
        obj = GameObject.FindGameObjectWithTag("BUTTON");
    }

    // Use this for initialization
    void Start () {

        obj.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { OnClickButton("우상준"); });
        /*
         * delegate (인자) { 실행코드 };  => 인자는 생략 가능하다
         * delegate ("우상준") { OnClickButton( "우상준" ); };
         * delegate { OnClickButton( "우상준" ); };
         */
    }

    //버튼이 클릭되면 호출될 이벤트 연결 함수 
    void OnClickButton(string name)
    {
        Debug.Log(name);
    }
}
