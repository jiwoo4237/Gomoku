using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

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

        if (signinPanel.activeSelf) return; // 이미 활성화된 상태라면 실행하지 않음

        signinPanel.SetActive(true);
        CanvasGroup signInCanvasGroup = signinPanel.GetComponent<CanvasGroup>();

        signInCanvasGroup.DOFade(1, fadeDuration);
    }

    public void ShowSignupPanel()
    {
        if (signupPanel == null)
        {
            signupPanel = Instantiate(SignupPanel, Canvas);
        }

        if (signupPanel.activeSelf) return; // 이미 활성화된 상태라면 실행하지 않음

        signupPanel.SetActive(true);
        CanvasGroup signupCanvasGroup = signupPanel.GetComponent<CanvasGroup>();

        signupCanvasGroup.DOFade(1, fadeDuration);
    }

    public void CloseSigninPanel()
    {
        if (signinPanel != null)
        {
            CanvasGroup signinCanvasGroup = signinPanel.GetComponent<CanvasGroup>();

            signinCanvasGroup.DOFade(0, fadeDuration).OnComplete(() =>
            {
                signinPanel.SetActive(false);
            });
        }
    }

    public void CloseSignupPanel()
    {
        if (signupPanel != null)
        {
            CanvasGroup signupCanvasGroup = signupPanel.GetComponent<CanvasGroup>();

            signupCanvasGroup.DOFade(0, fadeDuration).OnComplete(() =>
            {
                signupPanel.SetActive(false);
            });
        }
    }

    public void ShowErrorPanel(string message)
    {
        if (errorPanel == null)
        {
            errorPanel = Instantiate(ErrorPanel, Canvas);
            errorPanel.GetComponentInChildren<TMP_Text>().text = message;
            errorPanel.gameObject.SetActive(true);
            errorPanelRect = errorPanel.GetComponent<RectTransform>();
            errorPanelRect.anchoredPosition = new Vector2(-500f, 0f);
        }
        else
        {
            errorPanel.SetActive(true);
        }
        errorPanelRect.DOLocalMoveX(0f, 0.3f);
    }

    protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }
}
