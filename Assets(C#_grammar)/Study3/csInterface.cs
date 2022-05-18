using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
    public interface IStudy
    {
        //속성을 선언하는 방법

        //get을 가지고 있는 속성 설정 가능
        string Property_1 { get; }
        //set을 가지고 있는 속성 설정 가능
        string Property_2 { set; }
        //get과 set을 가지고 있는 속성 설정 가능
        string Property_3 { get; set; }


        //메소드를 선언하는 방법

        //인자를 받지않고 리턴하지 않는 메소드
        void Method();
        //인자를 받고 반환하는 메소드
        string Convert(string data);
    }


    public interface IPower
    {
        int Power
        {
            get; set;
        }

        //인자를 받지않고 리턴하지 않는 메소드
        void Method();
    }

    /*
     * 인터페이스끼리 상속:
     *  인터페이스는 인터페이스끼리 상속이 가능하다 그러나 클래스를
     *  상속 받는것은 불가능하다.
     *  이렇게 사용시 나중에 IUserName을 상속 받게 되면 Power,UserName
     *  속성을 모두 구현 가능며, 인터페이스에서는 상속 받은 속성을
     *  굳이 넣지 않아도(사용안해도) 상관없다.
     * 
     */
    public interface IUserName : IPower
    {
        string UserName
        {
            get; set;
        }
    }

    /*
     * 클래스로 상속 :
     * 인터페이스의 장점은 클래스에서 인터페이스를 여러개를 상속 받을 수 있다
     * JAVA와 마찬가지로 C#은 다중상속 불가능~!
     * 
     * 인터페이스에서 상속 받은 속성과 메소드들을 클래스에서 작성
     * 하는 것을 "구현" 하다 라고 표현하는데...인터페이스에서 
     * 상속 받은 속성과 메소드들은 무조건 모두 구현해야함. 아니면 에러...
     * 밑에 예제처럼 IPower,IUserName 인터페이스에서 부터 상속 받은
     * PlayerState 클래스가 Power,Method와 UserName 이렇게 전부를
     * 모두 구현해야 한다.
     * 
     */


    public class PlayerState1 : IPower, IUserName
    {
        int _Power;
        string _UserName;

        bool man;

        public bool Man
        {
            get
            {
                return man;
                //throw new NotImplementedException();
            }

            set
            {
                man = value;
                //throw new NotImplementedException();
            }
        }

        public int Power
        {
            get
            {
                return _Power;
                //throw new NotImplementedException();
            }

            set
            {
                _Power = value;
                //throw new NotImplementedException();
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
                //throw new NotImplementedException();
            }

            set
            {
                _UserName = value;
                //throw new NotImplementedException();
            }
        }

        public void Method()
        {
            //throw new NotImplementedException();
        }
    }

    public class PlayerState2 : IUserName
    {
        //public 엑서서를 사용하지 않는게 굿~!
        int _Power;
        string _UserName;

        bool man;

        //생성자
        public PlayerState2(string name)
        {
            _UserName = name;
            Debug.Log(_UserName);
        }
        // 이런식으로 인터페이스 상속 후 자신에게 맞게 추가해서 쓰자...
        public bool Man
        {
            get
            {
                return man;
                //throw new NotImplementedException();
            }

            set
            {
                man = value;
                //throw new NotImplementedException();
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
                //throw new NotImplementedException();
            }

            set
            {
                _UserName = value;
                //throw new NotImplementedException();
            }
        }

        //이 프로퍼티 사용 안할때...
        public int Power { get; set; }

        public void Method()
        {
            //throw new NotImplementedException();
        }
    }

    /* 
     * 추가 설명
     * 
     * 인터페이스는 필드를 포함 할 수없다.
     */
    public interface Item<T>
    {
        //인자를 받고 리턴하지 않는 메소드
        void Method(T item);
    }


    public class ItemUse<T> : Item<T>
    {
        private int item;

        public void Fct1(T item)
        {
            Debug.Log(item);
        }



        //void Item<T>.Method(T item)
        //{
        //    Debug.Log(item);
        //}

        public void Method(T item)
        {
            Debug.Log(item);
        }


        public void Fct2()
        {
            //Method(item);
        }
    }
}
/*
 * abstract class와 차이점은 abstract class 에선 추상화 할 내용만
 * abstract 키워드로 처리할 수 있었지만 인터페이스에선 모두다 추상화 시켜야 한다.
 */