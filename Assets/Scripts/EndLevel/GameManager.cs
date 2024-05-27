using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Dictionary<string, int> ShoppingList { get; private set; }
    public Dictionary<string, int> PlayerPurchases { get; private set; } = new Dictionary<string, int>();
    public int PlayerScore { get; private set; } = 0; // Baþlangýç puanýný 0 olarak ayarla

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetShoppingList(Dictionary<string, int> shoppingList)
    {
        ShoppingList = shoppingList;
    }

    public void AddPlayerPurchase(string meyveAdi, int kilo)
    {
        if (PlayerPurchases.ContainsKey(meyveAdi))
        {
            PlayerPurchases[meyveAdi] += kilo;
        }
        else
        {
            PlayerPurchases[meyveAdi] = kilo;
        }
    }

    public void CalculateScore()
    {
        if (ShoppingList == null) return;

        // Listedeki ürünler için puanlama
        foreach (var item in ShoppingList)
        {
            string meyveAdi = item.Key;
            int gerekenKilo = item.Value;

            if (PlayerPurchases.ContainsKey(meyveAdi))
            {
                PlayerScore += 5; // Doðru meyveyi aldýysa 5 puan ekle

                int satinAlinanKilo = PlayerPurchases[meyveAdi];
                if (satinAlinanKilo == gerekenKilo)
                {
                    PlayerScore += 5; // Doðru kiloda aldýysa ekstra 5 puan daha ekle
                }
            }
        }

        // Listedeki olmayan meyveler için ceza puaný
        foreach (var purchase in PlayerPurchases)
        {
            string meyveAdi = purchase.Key;
            if (!ShoppingList.ContainsKey(meyveAdi))
            {
                PlayerScore -= 5; // Listedeki olmayan bir meyve aldýysa 5 puan azalt
            }
        }
    }
}



