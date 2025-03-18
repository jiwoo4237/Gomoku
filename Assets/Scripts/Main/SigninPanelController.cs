using System;
using TMPro;
using UnityEngine;
public struct SigninData
{
    public string username;
    public string password;
}

public struct SigninResult
{
    public int result;
}

public struct ScoreResult
{
    public string id;
    public string username;
    public string nickname;
    public int score;
}

[Serializable]
public struct ScoreInfo
{
    public string username;
    public string nickname;
    public int score;
}

[Serializable]
public struct Scores
{
    public ScoreInfo[] scores;
}

public class SigninPanelController : MonoBehaviour
{
    [SerializeField] private TMP_InputField Username;
    [SerializeField] private TMP_InputField Password;
    
    public void OnClickSigninButton()
    {
        string username = Username.text;
        string password = Password.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            // 입력창 오류 팝업
            return;
        }

        var signinData = new SigninData();
        signinData.username = username;
        signinData.password = password;

        // StartCoroutine(NetworkManage.Instance.Signin(signinData, () =>
        // {
        //     Destroy(gameObject);
        // }, result =>
        // {
        //     if (result == 0)
        //     {
        //         Username.text = "";
        //     }
        //     else if (result == 1)
        //     {
        //         Password.text = "";
        //     }
        // }));
    }

    public void OnClickSignupButton()
    {
        MainManager.Instance.CloseSigninPanel();
        MainManager.Instance.ShowSignupPanel();
    }

}
