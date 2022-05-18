using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Interface;

public class csInterfaceUse : MonoBehaviour
{

    /*
     * 다음과 같이 캐스팅이 가능하다.
     * PlayerState2 클래스는 IUserName 인터페이스로부터 상속 받았으므로
     * IUserName의 UserName에 접근 할 수 있어 정상적으로 "WooPro" 출력
     * 
     */
    IUserName playerState;
    IUserName UserName;
    ItemUse<int> Item;

    // Use this for initialization
    void Start()
    {

        // 생성자도 이용해보고...
        playerState = new PlayerState2("WooPro");
        // 프로퍼티도 이용해보고...
        Debug.Log(playerState.UserName);

        Item = new ItemUse<int>();

        Item.Fct1(5);

        Item.Method(5);


        //UserName = new IUserName(); // 불가능
    }

    // Update is called once per frame
    void Update()
    {

    }
}