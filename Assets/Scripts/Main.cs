using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private float coins;
    [SerializeField] private float countCoinsClick = 1;

    [SerializeField] private float[] priceUp;
    [SerializeField] private float[] levelUp;

    [SerializeField] private Text[] priceUpText;
    [SerializeField] private Text[] levelUpText;

    [SerializeField] private Text coinsText;

    [SerializeField] private GameObject shopPanel;

    public void Start()
    {
        GenerateUpPricesOnStart(10);
        UpdateCoinsText();
        UpdatePriceText();
    }

    public void AddCoins()
    {
        coins += countCoinsClick;
        UpdateCoinsText();
    }

    public void BuyUp(int index)
    {
        if (coins >= priceUp[index])
        {
            coins -= priceUp[index];
            UpdateCoinsText();
            countCoinsClick *= 1.2f;
            priceUp[index] *= 3;
            levelUp[index]++;

            priceUpText[index].text = priceUp[index].ToString();
            levelUpText[index].text = levelUp[index].ToString();
        }
    }

    public void ShowPanel()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    public void UpdateCoinsText()
    {
        coinsText.text = coins.ToString("F2") + "$";
    }

    public void GenerateUpPricesOnStart(int price)
    {
        for (int i = 0; i < priceUp.Length ; i++)
        {
            priceUp[i] += price * (i + 1);
        }
    }

    public void UpdatePriceText()
    {
        for (int i = 0; i < priceUp.Length; i++)
        {
            priceUpText[i].text = priceUp[i].ToString();
        }
    }
}
