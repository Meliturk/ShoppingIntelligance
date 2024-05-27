using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingsBtnManager : MonoBehaviour
{
    public RectTransform settingsBtn;
    public RectTransform infoBtn;
    public RectTransform soundBtn;
    public RectTransform shareBtn;

    private Vector2 offScreenPos = new Vector2(-1110, 1227);
    private Vector2 onScreenBasePos = new Vector2(503, 1227);

    private bool isOpen = false;

    void Start()
    {
        infoBtn.anchoredPosition = offScreenPos;
        soundBtn.anchoredPosition = offScreenPos;
        shareBtn.anchoredPosition = offScreenPos;

        settingsBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ToggleMenu);
    }

    void ToggleMenu()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            OpenButtons();
        }
        else
        {
            CloseButtons();
        }
    }

    void OpenButtons()
    {
        infoBtn.DOAnchorPos(new Vector2(onScreenBasePos.x - 240, onScreenBasePos.y), 0.5f).SetDelay(0.1f);
        soundBtn.DOAnchorPos(new Vector2(onScreenBasePos.x - 480, onScreenBasePos.y), 0.5f).SetDelay(0.2f);
        shareBtn.DOAnchorPos(new Vector2(onScreenBasePos.x - 720, onScreenBasePos.y), 0.5f).SetDelay(0.3f);
    }

    void CloseButtons()
    {
        infoBtn.DOAnchorPos(offScreenPos, 0.5f);
        soundBtn.DOAnchorPos(offScreenPos, 0.5f);
        shareBtn.DOAnchorPos(offScreenPos, 0.5f);
    }
}
