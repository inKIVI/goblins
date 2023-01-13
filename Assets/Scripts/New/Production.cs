using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    public int COIN;
    public int getCoin;

    public float startTime;
    public float timer;

    public enum Manager
    {
        DefCoin,
        CoinFast, 
        CoinPlus, 
    }

    public Manager manager;

    void Start()
    {

    }

    void Update()
    {
        COIN = PlayerPrefs.GetInt("CoinWallet");

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            timer = startTime;
            Prod();
        }
    }

    void Prod()
    {
        if(manager == Manager.CoinFast)
        {
            COIN += getCoin;
            PlayerPrefs.SetInt("CoinWallet", COIN);
            startTime = 1;
        }
        else if (manager == Manager.CoinPlus)
        {
            COIN += getCoin + 100;
            PlayerPrefs.SetInt("CoinWallet", COIN);
        }
        else
        {
            COIN += getCoin;
            PlayerPrefs.SetInt("CoinWallet", COIN);
        }
    }

}
