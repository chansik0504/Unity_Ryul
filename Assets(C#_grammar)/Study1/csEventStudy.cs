using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public delegate void MyEventDelegate(string a);

public class csEventStudy : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

        Publish publish = new Publish();

        publish.myEvent += Program.MyHandler1;
        publish.myEvent += Program.MyHandler2;

        //델리게이트 원형을 전역으로 선언하면 가능.
        //publish.myEvent += new MyEventDelegate(Program.MyHandler1);
        //publish.myEvent += new MyEventDelegate(Program.MyHandler2);

        for (int i = 0; i < 10; i++)
        {
            /* 불가능(외부 접근)
            if (i % 3 == 0)
            {
                publish.myEvent("Event: " + i);
            }
            else
            {
                Debug.Log(i);
            }
            */

            publish.DoActive(i);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}


class Publish
{
    //델리게이트 원형 선언 (전역으로 선언 가능, static 선언 불가능)
    public delegate void MyEventDelegate(string a);

    //event 선언
    public event MyEventDelegate myEvent;

    public void DoActive(int num)
    {
        if (num % 3 == 0)
        {
            myEvent("Event: " + num);
        }
        else
        {
            Debug.LogError(num);
        }
    }
}

class Program
{
    static public void MyHandler1(string message)
    {
        Debug.Log("My " + message);
    }

    static public void MyHandler2(string message)
    {
        Debug.Log("You " + message);
    }
}

/* event 사용 법
 * 
 * delegate 반환형 델리게이트명(매개변수...);
 * 한정자 event 델리게이트 이름;
 * 
 * delegate 와는 다르게 해당 클래스 외부에서는 직접 호출 불가능 (delegate를 캡슐화 한거...)
 * 이벤트 추가 및 삭제는 함수이름을 사용하여 +=, -= 만 사용 가능.
 */