using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGizmo : MonoBehaviour
{
    //기즈모 색상 
    public Color Mycolor = Color.red;
    //기즈모 반지름 
    public float Myraduis = 0.05f;

    // 유니티 콜백함수 
    void OnDrawGizmos()
    {
        Gizmos.color = Mycolor;
        Gizmos.DrawSphere(transform.position, Myraduis);//폭팔범위 설정
    } //화면에 항상 켜져있다.
} 