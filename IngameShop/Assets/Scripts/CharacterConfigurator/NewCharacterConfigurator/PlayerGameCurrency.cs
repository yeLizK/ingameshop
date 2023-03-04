using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameCurrency : MonoBehaviour
{
    private static PlayerGameCurrency _instance;
    public static PlayerGameCurrency Instance { get { return _instance; } }

    private int currentCoin;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        currentCoin = 50;
    }

    public void UpdatePlayerCurrency(int price)
    {
        currentCoin -= price;
        ConfiguratorUIManager.Instance.UpdateCoinText(currentCoin.ToString());
    }

    public int GetCurrentCoin()
    {
        return currentCoin;
    }
}
