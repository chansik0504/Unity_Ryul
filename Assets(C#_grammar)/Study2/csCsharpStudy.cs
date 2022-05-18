using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCsharpStudy : MonoBehaviour
{    public int Value1, Value2;

    /*
	 * 클래스는 System.Serializable 이라는 어트리뷰트(Attribute)를 명시해야 
	 * Inspector 뷰에 노출 (c++ 방식) =>캡슐화
	 */
    [System.Serializable]

    public class Item1
    {
        private int m_amount;

        public int GetAmount()
        {
            return m_amount;
        }

        public void SetAmount(int num)
        {
            m_amount = num;
        }
    }


    /*
	 * 클래스는 System.Serializable 이라는 어트리뷰트(Attribute)를 명시해야 
	 * Inspector 뷰에 노출 (c# 방식) =>캡슐화(프로포티)
	 */

    [System.Serializable]
    public class Item2
    {
        private int m_amount;

        public int num
        {
            get
            {
                Debug.Log(2);
                return m_amount;
            }
            set
            {
                Debug.Log(1);
                m_amount = value; // (value : 암시적 매개 변수)
            }
        }
    }

    //인스펙터뷰에 표시할  클래스 변수 
    public Item1 item1;
    public Item2 item2;

    // Use this for initialization
    void Start()
    {

        //Item1 item1 = new Item1();

        item1.SetAmount(5);
        Value1 = item1.GetAmount();

        //Item2 item2 = new Item2();

        item2.num = 22;
        Value2 = item2.num;

        Debug.Log(Value1 + " : " + Value2);

        /* 
         * 변수 공부 
         * 
         * c#에서는 크게 두가지 형태의 변수가 존재
         * 
         * 1. Value타입(구조체형)
         * 2. 참조타입(클레스형)
         * 
         * Value타입의 변수들은 스택에 메모리가 잡힘
         *  
         */

        //변수의 크기를 알려면 변수이름으로 크기 확인이 안되고
        //자료형으로 알아야 된다.
        //cf) C#에서는 char를 byte개념으로 쓰는게 아니라 byte라는 변수가 따로 존재
        //    그리고 c#에서는 기본적으로 문자체계가 유니코드이다 따라서 
        //    char 형은 2byte...


        Debug.Log(string.Format("decimal {0}  info {1} ~ {2}", sizeof(decimal), decimal.MinValue, decimal.MaxValue));

        Debug.Log(string.Format("ulong {0}  info {1} ~ {2}", sizeof(ulong), ulong.MinValue, ulong.MaxValue));

        Debug.Log(string.Format("long {0}  info {1} ~ {2}", sizeof(long), long.MinValue, long.MaxValue));

        Debug.Log(string.Format("float {0}  info {1} ~ {2}", sizeof(float), float.MinValue, float.MaxValue));

        Debug.Log(string.Format("int {0}  info {1} ~ {2}", sizeof(int), int.MinValue, int.MaxValue));

        Debug.Log(string.Format("char {0}  info {1} ~ {2}", sizeof(char), char.MinValue, char.MaxValue));

        Debug.Log(string.Format("byte {0}  info {1} ~ {2}", sizeof(byte), byte.MinValue, byte.MaxValue));

        Debug.Log(string.Format("sbyte {0}  info {1} ~ {2}", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue));

    }

}