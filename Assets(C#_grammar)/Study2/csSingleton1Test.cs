using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSingleton1Test : MonoBehaviour
{
    void Start()
    {
        //싱글톤 객체에 num에 10 대입(문제2)
        Singleton1.Instance.num = 10;

        //프로퍼티로 값 반화해서 워닝으로 콘솔로 보여줌(문제1)
        Debug.LogWarning(Singleton1.Instance.num);
    }
}
