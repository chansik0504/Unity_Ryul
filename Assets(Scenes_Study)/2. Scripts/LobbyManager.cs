using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject uiInven;
    public GameObject[] lobbyBtn;

    public void InvenOpen()
    {
        lobbyBtn[0].SetActive(false);
        lobbyBtn[1].SetActive(false);
        uiInven.SetActive(true);
    }

    public void InvenClose()
    {
        uiInven.SetActive(false);
        lobbyBtn[0].SetActive(true);
        lobbyBtn[1].SetActive(true);
    }

    public void PlayGame()
    {
        GameObject.Find("SoundManager").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundCanvas").GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene("scPlayUi");
    }
}
