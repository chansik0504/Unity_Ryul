using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // Application.LoadLevel("scLobby");
        SceneManager.LoadScene("scLobby");
    }
}
