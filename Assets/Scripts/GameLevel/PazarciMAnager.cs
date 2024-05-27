using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;




    public class PazarciMAnager : MonoBehaviour
    {
        public Pazarci[] pazarcilar;
        private int aktifPazarciIndex = -1;
        private int aktifMeyveIndex = -1;

        [SerializeField]
        public GameObject satisPaneli;
        [SerializeField]
        public TextMeshProUGUI SatisBilgiTxt;
        [SerializeField]
        public TMP_InputField kginput;
        [SerializeField]
        public TextMeshProUGUI meyveBilgiTxt;
        [SerializeField]
        public Image SatisBilgiimg;
        [SerializeField]
        public Button satinAlButton;

        void Start()
        {
            for (int i = 0; i < pazarcilar.Length; i++)
            {
                int index = i;
                pazarcilar[i].pazarciButton.onClick.AddListener(() => PazarciClick(index));
                pazarcilar[i].Bilgiimg.gameObject.SetActive(false); // Baþlangýçta meyve bilgisi gizli
            }

            satinAlButton.onClick.AddListener(SatinAlButtonClick); // Satýn al butonuna týklama iþlemi
        }

        void PazarciClick(int pazarciIndex)
        {
            // Eðer ayný pazarcýya tekrar týklanýrsa meyveleri ve bilgileri kapat
            if (aktifPazarciIndex == pazarciIndex)
            {
                ToggleMeyveler(pazarcilar[pazarciIndex], false);
                aktifPazarciIndex = -1;
                satisPaneli.SetActive(false);
            }
            else
            {
                // Diðer tüm meyveleri ve bilgileri kapat
                if (aktifPazarciIndex != -1)
                {
                    ToggleMeyveler(pazarcilar[aktifPazarciIndex], false);
                    satisPaneli.gameObject.SetActive(false);
                }

                // Yeni týklanan pazarcýnýn meyve grubunu ve bilgilerini aç
                ToggleMeyveler(pazarcilar[pazarciIndex], true);
                aktifPazarciIndex = pazarciIndex;
            }
        }

        void ToggleMeyveler(Pazarci pazarci, bool active)
        {
            foreach (var meyve in pazarci.meyveler)
            {
                meyve.meyveButton.gameObject.SetActive(active);
                if (active)
                {
                    meyve.meyveButton.transform.localScale = Vector3.zero;
                    meyve.meyveButton.transform.DOScale(Vector3.one, 0.3f);
                    meyve.meyveButton.onClick.AddListener(() => MeyveClick(meyve));
                }
                else
                {
                    meyve.meyveButton.onClick.RemoveAllListeners();
                }
            }
            pazarci.Bilgiimg.gameObject.SetActive(active);
            pazarci.BilgiTxt.gameObject.SetActive(active);

            // Tüm meyve bilgilerini birleþtirerek göster
            if (active)
            {
                string meyveBilgileri = "";
                foreach (var meyve in pazarci.meyveler)
                {
                    meyveBilgileri += $"{meyve.isim}: {meyve.fiyat:C}\n";
                }
                pazarci.BilgiTxt.text = meyveBilgileri;
            }
        }

        void MeyveClick(Meyve meyve)
        {
            satisPaneli.SetActive(true);
            meyveBilgiTxt.text = $"{meyve.isim}: {meyve.fiyat:C}";
            aktifMeyveIndex = System.Array.IndexOf(pazarcilar[aktifPazarciIndex].meyveler, meyve);
        }

        void SatinAlButtonClick()
        {
            // Satýn alma iþlemini gerçekleþtir ve bilgileri göster
            SatinAl();

            // Paneli kapat
            satisPaneli.SetActive(false);

            // Satýn alma bilgilerini belirli bir süre sonra temizle
            StartCoroutine(TemizleSatisBilgisi());
        }

        void SatinAl()
        {
            if (aktifPazarciIndex != -1 && aktifMeyveIndex != -1 && float.TryParse(kginput.text, out float girilenKilo))
            {
                Meyve aktifMeyve = pazarcilar[aktifPazarciIndex].meyveler[aktifMeyveIndex];
                float fiyat = aktifMeyve.fiyat * girilenKilo;
                HarcananDeger.toplamHarcananPara += fiyat;

                SatisBilgiTxt.text = $"-{fiyat:C}\n {aktifMeyve.isim}\n {girilenKilo} kg ";
                SatisBilgiimg.gameObject.SetActive(true);

                satisPaneli.SetActive(false);

                GameManager.Instance.AddPlayerPurchase(aktifMeyve.isim, (int)girilenKilo);

                StartCoroutine(GizleSatisBilgiTxt(2f));
            }
        }

        IEnumerator GizleSatisBilgiTxt(float delay)
        {
            yield return new WaitForSeconds(delay);
            SatisBilgiimg.gameObject.SetActive(false);
        }

        IEnumerator TemizleSatisBilgisi()
        {
            yield return new WaitForSeconds(2f);
            meyveBilgiTxt.text = "";
        }

        public void XButon()
        {
            satisPaneli.gameObject.SetActive(false);
        }
    }





//public Button[] meyveler;
//bool meyveAcikmi = false;
//public Button[] pazarcilar;


//private void Start()
//{
//    foreach (Button pazarci in pazarcilar)
//    {
//        pazarci.onClick.AddListener(() => OnButtonClick(pazarci));
//    }

//}
//void MeyveleriKapat()
//{
//    for (int i = 0; i < meyveler.Length; i++)
//    {
//        meyveler[i].gameObject.SetActive(false);
//    }
//}

//void OnButtonClick(Button clickedButton)
//{
//    MeyveleriKapat();
//    clickedButton.gameObject.SetActive(true);
//}



//public void PazarciClick()
//{
//    if (!meyveAcikmi)
//    {
//        for (int i = 0; i < meyveler.Length; i++)
//        {
//            meyveler[i].gameObject.SetActive(true);

//        }
//        meyveAcikmi = true;
//    }



//    else
//    {
//        for (int i = 0; i < meyveler.Length; i++)
//        {
//            meyveler[i].gameObject.SetActive(false);

//        }
//        meyveAcikmi = false;
//    }


//}



// meyveBtn.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero).SetEase(Ease.OutBounce);

