using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csIDictionaryStudy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        /*
        IDictionary 인터페이스:

        IDictionary 인터페이스는 키와 값을 쌍으로 보관하는 컬렉션들의 기반 형식이다.
        그리고 IList 인터페이스처럼 IDictionary 인터페이스도 ICollection 인터페이스를 기반으로 정의한 형식이다.
        IDictionary 인터페이스에는 키와 값을 쌍으로 보관할 때 사용하는 Add 메서드를 제공하고 있으며 
        내부 규칙에 따라 보관될 위치를 결정하게 된다. 따라서 IList 인터페이스와 다르게 특정 위치에 보관하는 
        Insert 메서드는 제공하지 않는다. 그리고 IDictionary 인터페이스에는 같은 키를 가진 요소를 보관할 수 없다. 
        만약, Add 메서드를 이용하여 같은 키를 가진 요소를 보관하려고 시도하면 예외가 발생!!!.

        void Add(object key, object value); //키와 값을 쌍으로 보관하는 메서드

        */

        //Add 메서드를 이용하여 요소(키와 값을 쌍으로 함) 보관
        Hashtable ht = new Hashtable();

        ht.Add("홍길동", "율도국");

        ht.Add("장언휴", "이에이치");



        foreach (DictionaryEntry d in ht)

        {
            Debug.Log(d.Key);
            Debug.Log(d.Value);
            Debug.Log(d.Key.ToString() + d.Value);

        }

        /*  결과
         *  홍길동:율도국
         *  장언휴:이에이치
         */

        /*
        IDictionary 인터페이스에서는 인덱서를 사용할 때 키를 입력 인자로 전달하면 값을 참조할 수 있다. 
        그리고 인덱서를 대입 연산자 좌항에 사용하면 보관된 요소의 값이 바뀌게 된다!!!. 만약, 해당 키를 갖는 
        요소가 없다면 키와 값을 쌍으로 보관해 준다. Add 메서드에서는 같은 키가 보관되어 있을 때 예외를 발생하지만,
        인덱스는 예외를 발생하지 않고 보관된 값을 변경한다.

         object this[object key]{ get; set; } //인덱서
        */


        //Hashtable의 인덱서 사용
        Hashtable ht2 = new Hashtable();

        ht2["홍길동"] = "율도국";

        ht2["장언휴"] = "이에이치";

        ht2["홍길동"] = "대한민국";

        foreach (DictionaryEntry d in ht2)

        {
            Debug.Log(d.Key);
            Debug.Log(d.Value);
            Debug.Log(d.Key.ToString() + d.Value);

        }

        /*  결과
         * 홍길동:대한민국
         * 장언휴:이에이치
         */

        /*
        IDictionary 인터페이스에서는 특정 키에 해당하는 요소를 제거하는 Remove 메서드를 제공한다. 
        IList 인터페이스에서는 특정 위치에 요소를 제거하는 RemoveAt 메서드를 제공하지만, IDictionay 인터페이스에서는
        키를 기준으로 키와 값을 쌍으로 보관하기 때문에 RemoveAt 메서드를 제공하지 않는다. 하지만 보관된 모든 요소를 
        제거하는 메서드인 Clear는 제공.

        void Remove(object key); //특정 키에 해당하는 요소를 제거하는 메서드
        void Clear(); //보관된 모든 요소를 제거하는 메서드

         */

        //IDictionary 개체에 보관한 요소 제거하기
        Hashtable ht3 = new Hashtable();

        ht3["홍길동"] = "율도국";

        ht3["장언휴"] = "이에이치";

        ht3["김 구"] = "대한민국";



        ht3.Remove("홍길동");

        foreach (DictionaryEntry d in ht3)

        {

            Debug.Log(d.Key);
            Debug.Log(d.Value);
            Debug.Log(d.Key.ToString() + d.Value);

        }



        ht3.Clear();

        Debug.Log("보관된 요소 개수: " + ht3.Count);

        /*  결과
        * 김 구:대한민국
        * 장언휴:이에이치
        * 보관된 요소 개수:0
        */

        /*
         IDictionary 인터페이스에서는 특정 키의 요소가 보관되었는지 확인하는 Contains 메서드를 
         제공한다. 그리고 키를 보관하는 컬렉션을 가져오는 Keys 속성과 값을 보관하는 컬렉션을 
         가져오는 Values 속성을 제공한다. 특이한 사항으로는 키와 값으로 보관을 하기 때문에 
         foreach 문에서 열거할 때 DictionaryEntry 형식으로 보관된 요소를 접근하게 제공하고 있다.
         이를 위해 IDictionaryEnumerator를 반환하는 GetEnumerator 메서드를 제공하고 있다.
         */

        //IDictionary 인터페이스에서 약속한 멤버들
        Hashtable ht4 = new Hashtable();

        ht4["홍길동"] = "율도국";

        ht4["장언휴"] = "이에이치";

        Debug.Log(ht4.Contains("홍길동"));

        Debug.Log("키 항목");

        foreach (string s in ht4.Keys)

        {

            Debug.Log("    " + s);

        }

        Debug.Log("값 항목");

        foreach (string s in ht4.Values)

        {

            Debug.Log("    " + s);

        }

        Debug.Log("키:값");

        foreach (DictionaryEntry d in ht4)

        {

            Debug.Log("    " + d.Key + d.Value);

        }

        /*
         * 
         *  ht.GetEnumerator()를 호출함으로 collection 안에 있는 element들을 접근할 수 있다.
         *  열거자의 위치가 첫 element 전에 위치됨으로 MoveNext()함수를 호출하면 바로 첫번째 
         *  element에 접근할 수 있다.  
         *  MoveNext()함수는 더이상 읽을 element가 없을시 false를 반환.  
         *  아래 while 안에서 볼수 있듯이 key와 value로써 각 element의 property에 엑세스가 가능하다
         * 
         */

        IDictionaryEnumerator ide = ht4.GetEnumerator();

        while (ide.MoveNext())
        {

            Debug.Log(string.Format("info {0} : {1}", ide.Key, ide.Value));
        }


        /* 이 외에도 컬렉션이 고정 사이즈인지 읽기만 가능한지를 가져오기 가능한 IsFixedSize 속성과 IsReadOnly 속성을 
           제공.
        */

        // IDictionary 인터페이스에서 약속한 멤버들

        /*
        interface IDictionary : ICollection

        {

            void Add(object key, object value); //키와 값을 쌍으로 보관하는 메서드

            void Clear(); //보관된 모든 요소를 제거하는 메서드

            bool Contains(object key); //보관된 요소의 특정 키가 있는지 확인하는 메서드

            IDictionaryEnumerator GetEnumerator();//foreach에서 요소를 열거하기 위한 메서드

            bool IsFixedSize { get; } //고정 사이즈 속성 - 가져오기

            bool IsReadOnly { get; } //읽기만 가능한지에 대한 속성 - 가져오기

            ICollection Keys { get; } //키 컬렉션 속성 - 가져오기

            void Remove(object key); //특정 키에 해당하는 요소를 제거하는 메서드

            ICollection Values { get; } //값 컬렉션 속성 - 가져오기

            object this[object key] { get; set; } //인덱서 



            #region ICollection 멤버

            void CopyTo(Array array, int index);

            int Count { get; }

            bool IsSynchronized { get; }

            object SyncRoot { get; }

            #endregion

            #region IEnumerable 멤버

            IEnumerator IEnumerable.GetEnumerator();

            #endregion

        }
    */

        /*
           이처럼 C#에서 제공하는 컬렉션은 일반적으로 필요한 멤버를 추상화하여 인터페이스 기반으로 정의하였다. 
           우리는 하나의 컬렉션을 사용할 수 있다면 다른 컬렉션도 어렵지 않게 사용할 수 있다. 
        */


    }

    // Update is called once per frame
    void Update()
    {

    }
}


/*  Object형식:
   
    object형식은 "상속" 덕분에 어떤 데이터든지 다룰수 있는 데이터 형식이다.
    C#은 object가 모든 데이터를 다룰 수 있도록 하기 위해 특별 조치를 취했는데,
    모든 데이터 형식이 자동으로 object형식으로부터 상속받게 한 것이다.
    다시 말해 object형식이 모든 데이터 형식의 부모라고 하면 된다.
    ※ 모든 데이터 형식이 가능하다. 프로그래머가 만든 데이터 형식도 마찬가지다.
    따라서 컴파일러는 어떤 형식의 데이터라도 object에 담아 처리할 수 있게 된다.

     object a = 100;
     object b = 3.14;
     object c = true;
     object d = "헬로우 월드";

     Debug.Log(a);
     Debug.Log(b);
     Debug.Log(c);
     Debug.Log(d);

     박싱과 언박싱: 각 자료형이 처리하는 방식이 다르므로 제공되는 메커니즘


     object형식은 참조 형식이기 때문에 힙에 데이터를 할당한다.
     int나 double 형식은 값 형식이기 때문에 스택에 할당한다.
     그런데 앞에서 값 형식의 데이터를 object형식 객체에 담았다.
     이 경우는 어느 메모리에 데이터가 할당될까?
     object형식은 값 형식의 데이터를 힙에 할당하기 위한 박싱(Boxing)기능을 제공한다.
     object형식에 값 형식의 데이터를 할당하려는 시도가 이루어지면 object형식은 박싱을 수행해서 
     해당 데이터를 힙에 할당한다.
     이렇게 박싱이 일어나는 한 편, 힙에 있던 값 형식 데이터를 값 형식 객체에 다시 할당해야 하는 경우가 있다.
     다음이 그런 경우다.

     object a = 20;
     int b = (int)a

     위 코드에서 a는 20이 박싱되어 저장되어 있는 힙을 참조하고 있다.
     b는 a가 참조하고 있는 메모리로부터 값을 복사하려고 하는 중이다.
     이 때, 박싱되어 있는 값을 꺼내 값 형식 변수에 저장하는 과정을 언박싱(UnBoxing)이라고 한다.

     int a = 123;
     object b = (object)a;        // a에 담긴 값을 박싱하여 힙에 저장
     int c = (int)b;              // b에 담긴 값은 언박싱하여 스택에 저장
            
      Debug.Log(a);        // 결과 : 123
      Debug.Log(b);        // 결과 : 123
      Debug.Log(c);        // 결과 : 123

*/