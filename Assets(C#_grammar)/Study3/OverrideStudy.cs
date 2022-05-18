using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideStudy : MonoBehaviour
{
    /*
           virtual(가상화), override(재정의)

           멤버 함수에 virtual 키워드를 명시하여 멤버를 선언하면 가상 멤버가 된다. 
           따라서 파생 형식에서 기반 형식의 가상 멤버를 재정의할 때는 
           override 키워드를 명시하여 재정의 한다. 
    */

    /*
           internal은 C#에만 있는 접근 한정자로 현재 Assembly만 자유롭게 접근이
           가능한 한정자 인데...한마디로 현재 프로젝트만 접근 가능한거다...

           Assembly란 빌드된 출력 단위를 말하는데 (DLL,exe)같은 파일 형식이다.
           따라서 internal 선언은 내 Assembly 안에서는 전역처럼(여기저기) 쓰이지만,
           다른 Assembly에서는 직접 호출 불가하게(즉, 숨길때) 만들 경우 사용.
    */

    public class Player
    {
        internal virtual void ItemUse() //virtual 키워드로 가상 메서드 선언
        {
            Debug.Log("Portion Use");
        }
    }

    class GunPlayer : Player
    {
        internal override void ItemUse() //override로 기반 형식의 가상 메서드 재정의
        {
            Debug.Log("Item Use");
        }
    }


    // Use this for initialization
    void Start()
    {
        //공부

        Player player1 = new Player();
        Player player2 = new GunPlayer();

        GunPlayer player3 = new GunPlayer();

        player1.ItemUse();
        player2.ItemUse();
        player3.ItemUse();
    }

    // Update is called once per frame
    void Update()
    {

    }
}