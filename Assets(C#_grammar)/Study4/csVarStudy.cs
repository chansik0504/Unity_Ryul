using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csVarStudy : MonoBehaviour
{
    int[] aaa;

    void Awake()
    {
        //무명형식 (Anonymous Type)
        //그래도 우린 의미가 정확한게 좋다~ 따라서 한번 쓰고 버릴거만~
        var myInstance = 3;
        Debug.Log(myInstance);

        // myInstance = 4.5f; // Error 마우스로 가져가보면 int로 변해있다.

        // 어라 됩니다.
        myInstance = (int)4.5f;
        Debug.Log(myInstance);

        // 배열 선언과 동시에 초기화(C# 기준)
        aaa = new int[] { 100, 90, 80, 70 };
        Debug.Log(string.Format("1 {0}, 2 {1}, 3 {2}, 4 {3}", aaa[0], aaa[1], aaa[2], aaa[3]));
    }

    // Use this for initialization
    void Start()
    {

        //무명 형식의 인스턴스는 다른 객체들처럼 프로퍼티에 접근하여 사용할 수 있다.
        var myInstance1 = new { Name = "홍길동", Age = 28 };
        Debug.Log(myInstance1.Name + " , " + myInstance1.Age.ToString());
        //myInstance1.Age = 100; // Error

        // 어라 됩니다.(당근 새롭게 할당)
        myInstance1 = new { Name = "우상준", Age = 100 };
        Debug.Log(myInstance1.Name + " , " + myInstance1.Age.ToString());

        var myInstance2 = new { Subject = "수학", Scores = new int[] { 100, 90, 80, 70 } };
        Debug.Log(myInstance2.Subject + " , " + myInstance2.Scores[0].ToString());

        // 어라 된다.
        myInstance2.Scores[0] = 10;
        Debug.Log(myInstance2.Subject + " , " + myInstance2.Scores[0].ToString());

        // 형식을 인지 안해도 되니깐..편리하다 (foreach문에서 사용상 장점)
        foreach (var score in myInstance2.Scores)
        {
            Debug.Log(score);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/* 무명 형식 (이름이 필요없는 무명 형식)
 * 
 * int, double, string, Filestream, MyClass 이런 형식들은 이름이 필요하다. 이유는
 * 이름을 이용해 인스턴스를 만들기 때문이다. int a, double b....스크립트 다른 구역에서..a = 10; , b =2.0f.
 * 
 * (무명 형식에서 주의할 점)무명 형식의 프로퍼티에 할당된 값은 변경이 불가능 하므로
 *  한번 무명 형식의 인스턴스가 만들어지고 나면, 읽기만 할 수 있다는 뜻이다 (c#...)
 * 
 * 무명 형식은 형식의 선언과 동시에 인스턴스를 할당한다.
 * 이러한 특징 때문에, 인스턴스를 만들고 다시는 사용하지 않을 경우에 유용하다.
 * 
 */