using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;

public class LoginResult
{
    public int result;
}

public class MainManager : Singleton<MainManager>
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject SigninPanel;
    [SerializeField] private GameObject SignupPanel;
    [SerializeField] private Transform Canvas;
    [SerializeField] private GameObject ErrorPanel;

    private GameObject errorPanel;
    private RectTransform errorPanelRect;
    private GameObject signinPanel;
    private GameObject signupPanel;
    private float fadeDuration = 0.1f;
    private string filepath = "Assets/Data/UserInfo.csv";

    void Start()
    {
        ShowSigninPanel();
    }

    public void ShowSigninPanel()
    {
        if (signinPanel == null)
        {
            signinPanel = Instantiate(SigninPanel, Canvas);
        }
        if (!signinPanel.activeSelf)
        {
            signinPanel.SetActive(true);
            signinPanel.GetComponent<CanvasGroup>().DOFade(1, fadeDuration);
        }
    }

    public void ShowSignupPanel()
    {
        if (signupPanel == null)
        {
            signupPanel = Instantiate(SignupPanel, Canvas);
        }
        if (!signupPanel.activeSelf)
        {
            signupPanel.SetActive(true);
            signupPanel.GetComponent<CanvasGroup>().DOFade(1, fadeDuration);
        }
    }

    public void CloseSigninPanel()
    {
        if (signinPanel != null && signinPanel.activeSelf)
        {
            signinPanel.GetComponent<CanvasGroup>().DOFade(0, fadeDuration).OnComplete(() =>
            {
                signinPanel.SetActive(false);
            });
        }
    }

    public void CloseSignupPanel()
    {
        if (signupPanel != null && signupPanel.activeSelf)
        {
            signupPanel.GetComponent<CanvasGroup>().DOFade(0, fadeDuration).OnComplete(() =>
            {
                signupPanel.SetActive(false);
            });
        }
    }

    public void ShowMainPanel()
    {
        if (!MainPanel.activeSelf)
        {
            MainPanel.SetActive(true);
            MainPanel.GetComponent<CanvasGroup>().DOFade(1, fadeDuration);
        }
    }
    
    public void ShowErrorPanel(string message)
    {
        if (errorPanel == null)
        {
            errorPanel = Instantiate(ErrorPanel, Canvas);
            errorPanelRect = errorPanel.GetComponent<RectTransform>();
            errorPanelRect.anchoredPosition = new Vector2(-500f, 0f);
        }
        errorPanel.GetComponentInChildren<TMP_Text>().text = message;
        errorPanel.SetActive(true);
        errorPanelRect.DOLocalMoveX(0f, 0.3f);
    }

    public void AttemptLogin(string username, string password, Action<int> callback)
    {
        StartCoroutine(LoginCoroutine(username, password, callback));
    }

    private IEnumerator LoginCoroutine(string username, string password, Action<int> callback)
    {
        yield return new WaitForSeconds(0.5f); // 서버 요청 대기 시뮬레이션
        
        int result = CheckLogin(username, password);
        
        callback?.Invoke(result);
    }

    private int CheckLogin(string username, string password)
    {
        if (!File.Exists(filepath))
        {
            Debug.LogError("로그인 파일이 없습니다.");
            return 0;
        }

        string[] lines = File.ReadAllLines(filepath);

        foreach (string line in lines)
        {
            string[] userData = line.Split(',');

            if (userData.Length == 4)
            {
                string storedUsername = userData[1].Trim();
                string storedPassword = userData[2].Trim();

                if (storedUsername == username && storedPassword == password)
                {
                    return 1; // 로그인 성공
                }
            }
        }

        return 0; // 로그인 실패
    }    protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    
    }
}