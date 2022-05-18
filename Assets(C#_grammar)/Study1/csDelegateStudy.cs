using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csDelegateStudy : MonoBehaviour
{
    //델리게이트에 연결할 함수의 원형 정의 1
    delegate void CallNumDelegate1(int num);
    //델리게이트에 연결할 함수의 원형 정의 2
    delegate int CallNumDelegate2(int num1, int num2);

    //델리게이트 변수 선언 1
    CallNumDelegate1 callNum1;

    // Use this for initialization
    void Start()
    {
        //callNum 델리게이트 변수에 OnePlusNum 함수 연결
        callNum1 = OnePlusNum;
        //함수 호출
        callNum1(4);

        //callNum 델리게이트 변수에 PowerNum 함수 연결
        callNum1 = PowerNum;
        callNum1(5);

         //callNum 델리게이트 변수에 OnePlusNum 함수 연결
        callNum1 = new CallNumDelegate1(OnePlusNum);
        //함수 호출
        callNum1(4);

        //callNum 델리게이트 변수에 PowerNum 함수 연결
        callNum1 = new CallNumDelegate1(PowerNum);
        callNum1(5);

        //델리게이트 변수 선언 2
        CallNumDelegate2 callNum2;

        // 무명(익명) 메서드(다른말로 익명 대리자 : 함수 이름이 없다)도 사용가능
        // 단순 메시지 출력처럼 코드의 길이가 1~2줄 정도로 너무 짧은 경우...아니면 그렇게 자주 
        // 쓸 일이 없는 코드를 작성하는데 굳이 메서드를 만들어 줘야 하나? C언어라면 매크로 함수,
        // C++이라면 인라인 함수를 쓰겠지만 C#에는 그런 기능이 없으니  ...이런 고민에서 나온 것이 무명 메서드(Anonymous Method)
        // 장점: 사용자가 원할때 함수를 달리 할 수있다.(예를 들어서 사용자의 입력을 받아 사칙연산을 하는 프로그램을 만든다면
        // return a + b; 이 한줄을 위해 별도로 메서드를 따로 만들필요가 없다)
        callNum2 = delegate (int num1, int num2) { return num1 + num2; };
        Debug.Log( callNum2 ( 7, 7 ) );

        // 람다식도 사용 가능 (문서 참조...) => 무명 메서드가 "메서드 안에 또 다른 메서드(사용자 입력으로 결정되는 사칙연산 프로그램)"와 같은 
        // 꼴이라면, 람다식은 무명 메서드를 더욱 더 슬림하게 한 것. 무명 메서드와 다른 점은 일단 앞에 delegate라는 키워드가 없다. 또한 매개변수의
        // 형식을 굳이 명시할 필요도 없다. 이미 delegate 선언 때 다 했으니깐!!!!! 
        /*
            장점:

            1.코드의 간결성: 효율적인 람다 함수의 사용을 통하여 불필요한 루프문의 삭제가 가능하며,
            동일한 함수를 재활용할 수 있는 여지가 커진다. 

            (매개변수) => {함수 본문;}
            (매개변수) => 반환식;

            2.필요한 정보만을 사용하는 방식을 통한 퍼포먼스 향상: 지연 연산을 지원하는 방식을 통하여 
            효율적인 퍼포먼스를 기대할 수 있다. 이 경우 메모리 상의 효율성 및 불필요한 연산의 배제가 가능하다는
            장점이 있다. 

            단점:
            
            1.어떤 방법으로 작성해도 모든 원소를 전부 순회하는 경우는 람다식이 조금 느릴 수 밖에 없다.
            (어떤 방법으로 만들어도 최종 출력되는 bytecode 나 어셈블리 코드는 단순 while(혹은 for) 문 보다 몇 단계를 
            더 거치게 된다.)

            2.익명함수의 특성상 함수 외부의 캡처를 위해 캡처를 하는 시간제약 논리제약적인 요소도 고려해야한다.

            3.람다식을 너무 남발하여 사용하게되면 오히려 코드를 이해하기 어려울 수 도 있다.

         */ 
        callNum2 = (int num1, int num2) => { return num1 * num2; } ;
        Debug.Log(callNum2(7, 7));

        callNum2 = (int num1, int num2) => (num1 * num2);
        Debug.Log(callNum2(7, 7));

        callNum2 = (num1, num2) => (num1 * num2);
        Debug.Log(callNum2(7, 7));

        callNum2 = (num1, num2) => num1 * num2;
        Debug.Log(callNum2(7, 7));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnePlusNum(int num)
    {
        int result = num + 1;
        Debug.Log("One Plus = " + result);
    }

    void PowerNum(int num)
    {
        int result = num + num;
        Debug.Log("Power Num = " + result);
    }
}

/*
 * Delegate
 * 델리게이트는 함수를 가리키는 변수라고 생각하면 이해하기 쉽다.(함수포인트???)
 * 윗 코드는 선언부에 Delegate를 선언하고  Start ()에서 Delegate 변수에 함수를 연결한 후 실행.
 * 
 * 
 */