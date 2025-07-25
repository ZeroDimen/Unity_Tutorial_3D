using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPS_LoginManager : MonoBehaviour
{
    public InputField id;
    public InputField pw;

    public Text notify;

    private void Start()
    {
        notify.text = "";
    }

    public void SaveUserData()
    {
        if (!CheckInput(id.text, pw.text))
        {
            return;
        }
        
        if (!PlayerPrefs.HasKey(id.text))
        {
            PlayerPrefs.SetString(id.text, pw.text);
            notify.text = "아이디 생성이 완료되었습니다.";
        }
        else
        {
            notify.text = "이미 존재하는 아이디 입니다.";
        }
    }

    public void CheckUserData()
    {
        if (!CheckInput(id.text, pw.text))
        {
            return;
        }
        
        string pass = PlayerPrefs.GetString(id.text);
        if (pw.text == pass)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            {
                notify.text = "입력하신 아이디와 패스워드가 일치하지 않습니다.";
            }
        }
    }

    private bool CheckInput(string id, string pw)
    {
        if (id == "" || pw == "")
        {
            notify.text = "아이디 또는 패스워드를 입력해주세요.";
            return false;
        }
        else
        {
            return true;
        }
    }
}
