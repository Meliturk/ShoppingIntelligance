using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using System;

public class TheEnd : MonoBehaviour
{

    public GameObject bilgiPanel;
    public GameObject hesapPanel;
    public GameObject dikkatPanel;
    public GameObject sonucPanel;

    public Button bilgiBtn;
    public Button hesapBtn;
    public Button dikkatBtn;
    public Button retryBtn;
    public Button homeBtn;
    

    public TMP_InputField hesapInput;
    public TMP_InputField meyveInput;
    public TMP_InputField sebzeInput;
    

    public TextMeshProUGUI hesapTxt;
    public TextMeshProUGUI dikkatTxt;
    public TextMeshProUGUI hafizaTxt;


    float toplamharcanandeger = HarcananDeger.toplamHarcananPara;

    // public float toplamHarcananPara = 0;
    PazarciMAnager pazarciMAnager;
   

    void Start()
    {
        

        // Baþlangýçta sadece arka plan paneli açýk olsun
        //bilgiPanel.SetActive(false);
        //hesapPanel.SetActive(false);
        //dikkatPanel.SetActive(false);
        //sonucPanel.SetActive(false);

        // Bilgi paneli animasyonlu açýlýyor
        bilgiPanel.SetActive(true);
        bilgiPanel.transform.localScale = Vector3.zero;
        bilgiPanel.transform.DOScale(Vector3.one, 0.2f);

        // Butonlar için listener ekleniyor
        bilgiBtn.onClick.AddListener(OnBilgiBtnClicked);
        hesapBtn.onClick.AddListener(OnHesapBtnClicked);
        dikkatBtn.onClick.AddListener(OnDikkatBtnClicked);
        retryBtn.onClick.AddListener(RetryButonClicked);
        Debug.Log("tekrar oyna butonu çalýþtý");
        homeBtn.onClick.AddListener(HomeButonClicked);

    }

    void OnBilgiBtnClicked()
    {
        // Bilgi paneli kapatýlýyor ve hesap paneli açýlýyor
        bilgiPanel.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
        {
            bilgiPanel.SetActive(false);
            hesapPanel.SetActive(true);
            hesapPanel.transform.localScale = Vector3.zero;
            hesapPanel.transform.DOScale(Vector3.one, 0.5f);
        });
    }

    void OnHesapBtnClicked()
    {

        // Hesaplama iþlemleri
        float hesapInputValue;
        if (float.TryParse(hesapInput.text, out hesapInputValue))
        {
            float hesapSonuc =  Math.Abs(hesapInputValue - toplamharcanandeger);
            if (hesapSonuc == 0)
            {
                hesapSonuc = 100;
                hesapTxt.text = $"Hesap: {hesapSonuc}";
            }
            else if (hesapSonuc <= 25)
            {
                hesapSonuc = 75;
                hesapTxt.text = $"Hesap: {hesapSonuc}";
            }
            else if (hesapSonuc <= 50)
            {
                hesapSonuc = 50;
                hesapTxt.text = $"Hesap: {hesapSonuc}";
            }
            else if (hesapSonuc < 100)
            {
                hesapSonuc = 25;
                hesapTxt.text = $"Hesap: {hesapSonuc}";
            }
            else
            {
                hesapSonuc = 0;
                Debug.Log("hesap yazdýrýldý" + " " + toplamharcanandeger);
                hesapTxt.text = $"Hesap: {hesapSonuc}";
            }
        }

        // Hesap paneli kapatýlýyor ve dikkat paneli açýlýyor
        hesapPanel.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
        {
            hesapPanel.SetActive(false);
            dikkatPanel.SetActive(true);
            dikkatPanel.transform.localScale = Vector3.zero;
            dikkatPanel.transform.DOScale(Vector3.one, 0.5f);
        });
    }

    void OnDikkatBtnClicked()
    {
        // Dikkat hesaplamalarý
        int meyveSayisi;
        int sebzeSayisi ;

        if (int.TryParse(meyveInput.text, out meyveSayisi) && int.TryParse(sebzeInput.text, out sebzeSayisi))
        {
            int meyveFark = Math.Abs(10 - meyveSayisi);
            int sebzeFark = Math.Abs(10 - sebzeSayisi);
            int dikkatSonuc = Math.Abs(100 - ((meyveFark * 5) + (sebzeFark * 5)));
            Debug.Log("dikkat yazdýrýdý"+" "+ dikkatSonuc);
            dikkatTxt.text = $"Dikkat: {dikkatSonuc}";
        }

        GameManager.Instance.CalculateScore();
        hafizaTxt.text = $"Hafýza: {GameManager.Instance.PlayerScore}";

        // Dikkat paneli kapatýlýyor ve hafiza paneli açýlýyor
        dikkatPanel.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
        {
            dikkatPanel.SetActive(false);
            sonucPanel.SetActive(true);
            sonucPanel.transform.localScale = Vector3.zero;
            sonucPanel.transform.DOScale(Vector3.one, 0.5f);
        });
        
    }

    void HomeButonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void RetryButonClicked()
    {
        SceneManager.LoadScene("GameScene");

    }
}
