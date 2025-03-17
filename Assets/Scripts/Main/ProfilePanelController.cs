using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ProfilePanelController : MonoBehaviour
{
    [SerializeField] private TMP_Text Username;
    [SerializeField] private TMP_Text Nickname;
    [SerializeField] private TMP_Text Level;
    [SerializeField] private TMP_Text Score;

    public void SettingProfile () 
    {
         // user info 받아서 텍스트 변경
    }

     public void OnClickCloseButton()
    {
        this.GetComponent<RectTransform>().DOLocalMoveX(-600f, 0.3f)
            .OnComplete(() => this.gameObject.SetActive(false)); 
    }
}
