using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ListePanel : MonoBehaviour
{
    public TextMeshProUGUI listeTxt;
    public GameObject listePanel;
    public float timerS�resi = 15f; // Timer s�resi (saniye)
    public TextMeshProUGUI timerTxt;

    private float timer;
    private bool timerBasla;

    public Meyve[] meyveler;

    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI endTimerTxt;
    [SerializeField] private Button endButton;
    public float endTimerS�resi = 60f; // Oyun bitti paneli i�in s�re (saniye)

    private float endTimer;
    private bool endTimerBasla;

    private Dictionary<string, int> shoppingList = new Dictionary<string, int>();

    void Start()
    {
        if (listeTxt == null) Debug.LogError("listeTxt is not assigned!");
        if (timerTxt == null) Debug.LogError("timerTxt is not assigned!");
        if (endButton == null) Debug.LogError("endButton is not assigned!");
        if (meyveler == null || meyveler.Length == 0) Debug.LogError("meyveler array is not assigned or empty!");
        if (GameManager.Instance == null) Debug.LogError("GameManager.Instance is null!");
        // Oyuncuya al��veri� listesi olu�tur
        CreateShoppingList();

        // Zamanlay�c�y� ba�lat
        StartTimer(timerS�resi);

        // End button click listener
        endButton.onClick.AddListener(() => SceneManager.LoadScene("EndScene"));
    }

    void CreateShoppingList()
    {
        List<string> shoppingListDisplay = new List<string>();
        HashSet<int> usedIndices = new HashSet<int>();
        int numberOfItems = 9; // Al��veri� listesinde olacak meyve say�s�
        System.Random random = new System.Random();

        for (int i = 0; i < numberOfItems; i++)
        {
            int index;
            do
            {
                index = random.Next(0, meyveler.Length);
            } while (usedIndices.Contains(index));

            usedIndices.Add(index);

            string meyveAd = meyveler[index].isim;
            int kilo = random.Next(1, 6); // 1 ile 5 aras�nda rastgele kilo
            shoppingListDisplay.Add($"{meyveAd}: {kilo} kg");
            shoppingList[meyveAd] = kilo; // Meyve ad�n� ve kilo bilgisini dictionary'e ekle
        }

        GameManager.Instance.SetShoppingList(shoppingList); // GameManager'a al��veri� listesini kaydet

        listeTxt.text = string.Join("\n", shoppingListDisplay);
    }

    void StartTimer(float duration)
    {
        timer = duration;
        timerBasla = true;
    }

    void StartEndTimer(float duration)
    {
        endTimer = duration;
        endTimerBasla = true;
    }

    void Update()
    {
        if (timerBasla)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerDisplay(timer, timerTxt);
            }
            else
            {
                timer = 0;
                timerBasla = false;
                listePanel.SetActive(false); // Timer bitti�inde paneli kapat
                StartEndTimer(endTimerS�resi); // Liste paneli kapand�ktan sonra end timer'� ba�lat
            }
        }

        if (endTimerBasla)
        {
            if (endTimer > 0)
            {
                endTimer -= Time.deltaTime;
                UpdateTimerDisplay(endTimer, endTimerTxt);
            }
            else
            {
                endTimer = 0;
                endTimerBasla = false;
                // Oyun bitti i�lemleri buraya eklenebilir
                endPanel.SetActive(true);
            }
        }
    }

    void UpdateTimerDisplay(float time, TextMeshProUGUI timerText)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

}