using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 가비지 컬렉터 호출
using System;

/*
 
    // 가비지 컬렉션을 강제로 실행시켜 객체를 메모리에서 바로 해제하고 싶을때 사용
    GC.Collect();
    // 가비지 컬렉션이 객체를 해제할때까지 대기 상태 유지
    GC.WaitForPendingFinalizers();

*/

public class GCTest : IDisposable
{
    ~GCTest()
    {
        Debug.Log("GCGC");
    }

    public void Dispose()
    {
        Debug.Log("Dispose");
    }
}

public class UsingUse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GCTest gc = new GCTest();
        //gc = null;
        //GC.Collect();
        //GC.WaitForPendingFinalizers();

        using (gc)
        {
            gc = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
