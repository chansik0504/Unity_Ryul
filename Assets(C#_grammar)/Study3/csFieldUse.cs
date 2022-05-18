using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Field;

public class csFieldUse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Field.Armor armor = new Field.Armor(); 
        // 가능 하지만 귀찮, 그래서 맨위에 using Field 써줌

        Armor armor = new Armor();

        armor.name = "블랙드래곤";
        // armor.m_defence = 500;
        // m_defence == const <- 상수에 접근하려면 클래스로 접근해야함
        // armor._Color = "Red"; // <- 마찬가지

        Debug.Log(Armor.m_defence);
        Debug.Log(Armor._Color);


        // Man클래스의 인스턴스 생성
        Man man = new Man();
        // 사용 (set)
        man._Name = "우상준";
        Debug.Log(string.Format("이름 : {0}, 갑옷 : {1}, 디펜스 : {2}, 색상 : {3}",
            man._Name, /*사용 X (get)*/ armor.name, Armor.m_defence, Armor._Color));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
