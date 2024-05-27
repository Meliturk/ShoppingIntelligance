using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform startBtn;
    [SerializeField]
    private Transform BaslangicAd1;
    [SerializeField]
    private Transform BaslangicAd2;
    [SerializeField]
    private Transform settingsBtn, soundBtn, infoBtn;



    void Start()
    {
        startBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-215, 1f).SetEase(Ease.OutBack);
        BaslangicAd1.transform.GetComponent<RectTransform>().DOLocalMoveX(133, 1f).SetEase(Ease.OutBack);
        BaslangicAd2.transform.GetComponent<RectTransform>().DOLocalMoveX(244, 1f).SetEase(Ease.OutBack);
        settingsBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(1227, 1f).SetEase(Ease.OutBack);
        
    }

    public void OyunaBasla()
    {
        SceneManager.LoadScene("GameScene");
    }
}
