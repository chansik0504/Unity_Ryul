/*
 * 싱글톤 패턴: 많이 알려진 패턴중 하나로서 ...잘못쓰면 모든 프로그램을 망치는 패턴이다(안티 패턴)
 * 당연...잘 쓰면 좋다..ㅎㅎ 써야할 때 쓰자.
 * 싱글톤은 자신의 단일 인스턴스만 생성될 수 있게 해주는 클래스이며
 * 일반적으로 해당 인스턴스에 대한 간단한 액세스를 제공합니다.
 * 사용법은 게임에서 매니저 클래스나 컨트롤러 클래스를 싱글톤으로 만들어서 
 * 필요한 클래스에서 참조 용으로 쓴다.(다른 오브젝트에서 접근 가능)
 * 한마디로, 다양한 곳에서 하나의 변수를 처리하기 위해 사용 (스코어 처리 등...)
 */

public class Singleton1 
{
    public int num;

    //static 선언으로 프로그램 실행 전 미리 메모리 공간에 할당
    //또한 접근은 Singleton1 이 이름으로 접근

    private static Singleton1 instance = null;

    public static Singleton1 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton1();
            }

            return instance;
        }
    }

    // 생성자
    private Singleton1()
    {
        num = 100;
    }
}