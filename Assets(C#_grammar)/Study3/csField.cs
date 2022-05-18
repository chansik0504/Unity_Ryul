namespace Field
{
    public class Armor
    {
        public string name;

        // 상수 (constant) : 정적 접근 // 클래스함수로밖에 접근할수없다
        public const int m_defence = 1000;

        // static도 정적 접근
        // 읽기 전용 필드 (ReadOnly) 위에보다 이게 더 좋음
        public static readonly string _Color = "Black";
    }

    public class Man
    {
        // 이름을 저장할 공간 = 필드
        private string userName;

        // 이름을 외부에서 사용 : 속성 (Property)
        public string _Name // 속성명으로 지정, 메인 이름에 속성 부여시 사용
        {
            get
            {
                return userName; // 필드명
            }
            set
            {
                userName = value; // 필드명
            }
        }
    }
    // 사용자가 정한 필드의 속성을 사용하기 위해서는 필드의 이름 그대로 속성에서 리턴하여 사용
}