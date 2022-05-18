using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExportAssetBundles : MonoBehaviour
{
    //CONTEXT/컴포넌트의이름 쓰면 컴포넌트의 설정에 뜬다.
    //리지드바디 컴포넌트의 우측상위의 톱니모양 클릭시 ...
    //컨텍스트 메뉴(context menu)에 Double Mass 메뉴 추가...
    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DoubleMass(MenuCommand command)
    {
        Rigidbody body = (Rigidbody)command.context;

        body.mass = body.mass * 2;

        Debug.Log("+ Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
    }

    [MenuItem("GameObject/MyCategory/Custom Game Object1", false, 1)]
    static void CreateCustomGameObject1(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("Custom Game Object");

        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);

        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);

        Selection.activeObject = go;
    }

    [MenuItem("GameObject/MyCategory/Custom Game Object2", false, 15)]
    static void CreateCustomGameObjectEx1(MenuCommand menuCommand)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    [MenuItem("GameObject/MyCategory/Custom Game Object2", true)]
    static bool CreateCustomGameObjectCheak()
    {
        //현재 활성화된 게임 오브젝트가 씬 에셋인지 체크(오브젝트 클릭시 활성)
        return Selection.activeObject.GetType() == typeof(SceneAsset);

    }

    //등록할 대분류 메뉴/중분류 메뉴 선언 
    //[MenuItem("경로")] 로 메뉴에 새로운 탭을 만들거나 
    //이미 존재하는 탭에 옵션이나 하위 메뉴를 만들 수 있다.
    // 뒤에 실행될 함수는 무조건 static 선언을 해야한다.
    [MenuItem("Build/Build AssetBundle #%&d")]
    //메뉴를 클릭하면 실행되는 함수 
    public static void BulidSceneToAssetBundle()
    {
        /*  BuildPipeline 클래스의 클래스함수인 BuildAssetBundles() 함수는 
            에셋 번들을 만들어 준다.BuildAssetBundles() 함수는 String 매개변수가 
            선언 되어있다. 이 매개변수는 빌드된 에셋 번들을 저장할 경로이다.
            예를 들어 Assets 폴더의 하위 폴더 AssetBundles 폴더에 저장하려면
            "Assets/AssetBundles" 라고 입력한다.
        */

        //AssetBundle로 만들 Scene의 경로와 이름을 배열에 저장 
        string sceneNames = "AssetBundles";

        //AssetBundle로 생성 
        //pc 버전
        BuildPipeline.BuildAssetBundles(sceneNames, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        //안드로이드 버전
        //BuildPipeline.BuildAssetBundles(sceneNames, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
