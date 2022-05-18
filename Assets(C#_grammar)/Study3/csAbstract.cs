using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  C#에서는 abstract 키워드를 사용하여 클래스를 정의하여 상속을 통해서만
 *  사용할 수 있는 기반 클래스를 만들 수 있다. 이 클래스를 추상 클래스라 한다.
 *  추상 클래스는 객체를 생성할 수 없으며 단지 상속을 통해 기반 클래스 역할만 함.
 * 
 */

abstract class Sword1
{
    public Sword1()
    {
        Debug.Log("Sword1 생성자");
    }

    public void Attack()
    {
        Debug.Log("Swing1");
    }


    //C# 도 소멸자가 있다... 동작은 가비지콜랙터(Garbage Collector)가 객체를 
    //소멸하기 전에 호출된다....이는 가비지콜랙터(Garbage Collector)가 정리 못하는
    //리소스를 해제하기 위한 문법이나 ... 쓰지말자..가비지콜랙터(Garbage Collector)가
    //다 해주는데...자원 낭비이다..
    //쓸라면 잘 써야한다...
    //이유는 CLR(Common Language Runtime)의 가비지컬렉터가 객체를 쓰레기라고 하는 시기를
    //정확하게 알수가 없기 때문이다..C#에서는 CLR의 가비지 컬렉터가 있기때문에 자기 스스로
    //판단하여 객체를 소멸하기때문에 상황에 맞게 쓰는 것을 추천.
    //그래서 OnDestroy() 함수를 쓰자는거다~(즉시 시전)

    ~Sword1()
    {
        Debug.Log("Sword1 소멸지1");
    }

}


/*
 * 추상 클래스에는 메서드의 수행 코드는 정의하지 않고 
 * abstract 키워드를 명시(선언)하여 추상 메서드를 캡슐화할 수 있는데
 * 이와같이 추상 메서드를 캡슐화하면 파생 형식(자식 클래스)에선
 * 추상 멤버를 재정의해야(override 키워드 사용) 객체를 생성 가능.
 */

//추상 클래스
abstract class Sword2
{
    //추상 메서드
    public abstract void Attack();

    public Sword2()
    {
        Debug.Log("Sword2 생성자");
    }

    ~Sword2()
    {
        Debug.Log("Sword2 소멸지2");
    }

}

class Man1 : Sword1

{
    public Man1()
    {
        Debug.Log("Man1 생성자");
    }

    ~Man1()
    {
        Debug.Log("Man1 소멸자");
    }
}

class Man2 : Sword2

{
    //기반 형식 Sword2의 추상 메서드 Attack 재정의 (재정의 안하면 error)

    public override void Attack()

    {

        Debug.Log("Swing2");

    }

}



public class csAbstract : MonoBehaviour
{

    // 이건 레퍼런스 선언
    Sword1 sword;

    Man1 man1;
    Man2 man2;

    // Use this for initialization
    void Start()
    {

        //추상 클래스 또는 인터페이스의 인스턴스 생성 불가
        // sword = new Sword();

        man1 = new Man1();
        man2 = new Man2();

        man1.Attack();
        man2.Attack();

        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {


    }
}