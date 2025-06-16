using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    public int startingCoins = 100; // Starting amount of coins
    public Text coinText; // Reference to the UI text element displaying the coin count

    private int currentCoins;

    void Start()
    {
        currentCoins = startingCoins;
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinText();
    }

    public bool SpendCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            UpdateCoinText();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + currentCoins;
    }
}
