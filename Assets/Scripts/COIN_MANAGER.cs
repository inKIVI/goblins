using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class COIN_MANAGER : MonoBehaviour
{

    
    public int COIN;

    public static Action OnUpdateCoin;
   

    [SerializeField] TextMeshProUGUI COINText;

    public string LastDate;

    public GameObject TimeWindows;
    public TextMeshProUGUI TextLastTime;

    private int Gold;

    private void Awake()
    {
        /*
        if (PlayerPrefs.HasKey("CoinWallet"))
        {
            COIN = PlayerPrefs.GetInt("CoinWallet");
        }
        else
        {
            COIN = 80000;
        }
        */

        if (PlayerPrefs.HasKey("LastSession"))
        {
            CheckOfflinetime();
        }
    }


    void Update() // был старт
    {

        UPDATE_COIN_TEXT();
    }

   
    public void UPDATE_COIN_TEXT()
    {
        if (PlayerPrefs.HasKey("CoinWallet"))
        {
            COIN = PlayerPrefs.GetInt("CoinWallet");
        }
        else
        {
            COIN = 80000;
        }
        OnUpdateCoin?.Invoke();
        COINText.text = COIN.ToString();
        SaveCoin();
    }


    public void BuyHex(int Price)
    {
        COIN -= Price;
        UPDATE_COIN_TEXT();
    }

    public void Payment(int _Coin)
    {
        COIN += _Coin;
        UPDATE_COIN_TEXT();

    }


    
    

    //private void OnApplicationPause(bool pause)
    //{
    //    if (pause)
    //    {
    //        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
           
    //    }
        
    //    PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    //}

    private void OnApplicationFocus(bool focus)// проверка на сворачивание экрана 
    {
        if (!focus)
        {
            Debug.Log("Pause Game");
            SAVEALL();
        }
        else
        {
            Debug.Log("Start Game");
            SAVEALL();
        }
    }

    void SaveCoin()
    {
        PlayerPrefs.SetInt("CoinWallet", COIN);
        //Debug.Log("SAVE.....Coin: " + COIN);


    }
    void SaveLastTime()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        Debug.Log("SAVE_Time: " + DateTime.Now);

        //PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }

    void CheckOfflinetime()
    {

        TimeSpan TS;


        TS = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));

        LastDate = TS.ToString();

        //if (TS.Hours>0||TS.Minutes>1)
        //{
        //    TimeWindows.SetActive(true);
        //    Gold = TS.Minutes * 2;
        //    TextLastTime.text = "Вы отсутствовали Д:" + TS.Days + " Ч:" + TS.Hours + " М:" + TS.Minutes + "\n" + " +" + Gold.ToString();
        //}

        if (TS.Hours > 0 || TS.Minutes > 1)
        {
            TimeWindows.SetActive(true);
            if (TS.Days>0)
            {
                Gold += TS.Days * 288;
            }
            if (TS.Hours>0)
            {
                Gold += TS.Hours * 60;
            }
            if (TS.Minutes>0)
            {
                Gold += TS.Minutes;
            }
            Gold*= 2;
            TextLastTime.text = "Добро пожаловать " + "\n" + "Накоплено " + Gold.ToString() + " монет";

        }
    }

    public void ButtonCoinLastTime()
    {
        Payment(Gold);
        SaveLastTime();

    }


    void SAVEALL()
    {

        PlayerPrefs.SetInt("CoinWallet", COIN);
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        PlayerPrefs.Save();
    
    }

}
