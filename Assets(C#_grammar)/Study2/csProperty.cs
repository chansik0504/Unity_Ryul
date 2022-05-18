using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CCC
{

}

public class csProperty : MonoBehaviour {

    private int health = 30;

    public int Health
    {
        get
        {
            return health;
        }
        private set
        {
            health = value;
        }

    }

    // Use this for initialization
    void Start()
    {
        print(Health);
        Health = 50;
        print(Health);

        //(cf) MonoBehaviour 이거 때문에 null 나온다...
        csCsharpStudy aaa = new csCsharpStudy();
        Debug.Log(aaa);

        // 마찬가지
        csProperty bbb = new csProperty();
        Debug.Log(bbb);

        //된다...ㅜㅜ
        CCC ccc = new CCC();
        Debug.Log(ccc);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
/*
 * 1. set 접근자의 value키워드는 set 접근자가 할당하는 값을
 * 정의하는 하나의 예약어이다. 따라서 set 안에서만 유효하다.
 *
 *  2. set 접근자만을 구현하면 쓰기 전용 , get 접근자만을 구현하면
 *  읽기 전용이다. private으로도 구현 가능하다.(유연한 처리 가능)
 *
 * 3. get , set, 내에서 각종 조건을 걸어줄 수도,
 * 혹은 사전 조건, 사후 조건을 프로퍼티 내에서 구현할 수도 있다.
 *
 * 4. 주의 사항!
 *
 * 변수와 프로퍼티의 이름은 같아야 하고 대 소문자로 구분한다.(관례)
 * 
 * 5.  프로퍼티 활용
 * public string Name{ get; set; }
 * public int Hp{ get; private set; }
 * public float Speed{ private get; set; }
 */
