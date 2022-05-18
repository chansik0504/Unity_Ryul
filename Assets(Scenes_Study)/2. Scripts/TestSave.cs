using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestSave : MonoBehaviour
{
    public int score;
    public int point;
    //문자열 저장 변수
    string strFilePath;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        //	strFilePath = Application.dataPath+"/Save.dll"; -> 실행파일 루트에 저장파일 생성 
		//  strFilePath = "C:/test/Save.dll";               ->  디렉토리 루트를 설정 가능  
		// 실행파일 루트에 저장파일 생성 
        strFilePath = "./test/Save.dll";
        // 디버깅을 위한 함수로 콘솔 뷰로 문자열 등 여러 데이타를 보낼수 있다.(함수오버로딩)
        Debug.Log(strFilePath);
        // 파일 스트림을 쓰기 모드로 오픈한다.
        FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write);
        // 오픈 실패시 함수 종료 
        if (fs == null)
        {
            return;
        }

        // 문자열로 저장한다.
		//StreamWriter sw = new StreamWriter(fs);
		//sw.WriteLine (score);->한 라인씩 저장 
		//sw.WriteLine (point);
		// 기계어로 저장한다 (보통 이걸 사용)
        BinaryWriter sw = new BinaryWriter(fs);
        sw.Write(score);
        sw.Write(point);

        sw.Close();
        fs.Close();
    }

    public void LoadData()
    {
        strFilePath = "./test/Save.dll";

        // 해당 파일이 없을시 함수 종료 
        if (File.Exists(strFilePath) == false)
        {
            return;
        }

        // 파일 스트림을 일기 모드로 오픈한다.
        FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read);
        // 오픈 실패시 함수 종료
        if (fs == null)
        {
            return;
        }

        // 문자열을 읽기 위한 StreamReader 생성 
		//StreamReader sr = new StreamReader(fs);
		//score = int.Parse (sr.ReadLine ()); -> 한 라인씩 읽어드리고 인트형 변환 
		//point = int.Parse (sr.ReadLine ());
		// 기계어을 읽기 위한 StreamReader 생성
        BinaryReader sr = new BinaryReader(fs);
        score = sr.ReadInt32();
        point = sr.ReadInt32();

        sr.Close();
        fs.Close();

        // 문자열 저장을 확인한다.
        Debug.Log("END");
    }
}
