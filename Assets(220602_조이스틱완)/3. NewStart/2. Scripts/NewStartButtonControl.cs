using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NewStartButtonControl : MonoBehaviour
{
    public void Unit_Warrior()
    {
        GameObject.Find("Canvas").transform.Find("Warrior").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Assassin").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Wizard").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Gunner").gameObject.SetActive(false);
    }

    public void Unit_Assassin()
    {
        GameObject.Find("Canvas").transform.Find("Warrior").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Assassin").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Wizard").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Gunner").gameObject.SetActive(false);
    }

    public void Unit_Wizard()
    {
        GameObject.Find("Canvas").transform.Find("Warrior").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Assassin").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Wizard").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Gunner").gameObject.SetActive(false);
    }

    public void Unit_Gunner()
    {
        GameObject.Find("Canvas").transform.Find("Warrior").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Assassin").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Wizard").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Gunner").gameObject.SetActive(true);
    }

    public void Skill_1()
    {
        GameObject.FindGameObjectWithTag("Rendering").GetComponentInChildren<Animator>().SetTrigger("Skill1");
    }

    public void Skill_2()
    {
        GameObject.FindGameObjectWithTag("Rendering").GetComponentInChildren<Animator>().SetTrigger("Skill2");
    }

    public void Skill_3()
    {
        GameObject.FindGameObjectWithTag("Rendering").GetComponentInChildren<Animator>().SetTrigger("Skill3");
    }

    public void Skill_4()
    {
        GameObject.FindGameObjectWithTag("Rendering").GetComponentInChildren<Animator>().SetTrigger("Skill4");
    }

    public void Select()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void Go_Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
