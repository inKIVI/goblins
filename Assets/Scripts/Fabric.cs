using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fabric : MonoBehaviour
{
    public COIN_MANAGER Wallet;
    public GameObject fabric_canvas;
    [SerializeField] GameObject TextCoin;
    int payment=20;
    public bool _visible;
    private Camera Cam;

    private void Awake()
    {
        TextCoin = (GameObject)Resources.Load("BuildingTextCoin");
        Cam = Camera.main;
    }

    void Start()
    {
        fabric_canvas.transform.LookAt(Cam.transform);
        
        Invoke("Coin_mining", 2f);
    }

   
    public void Coin_mining()
    {
        SpawnText();
        Wallet.Payment(payment);
        
        Invoke("Coin_mining", 2f);
    }

    void SpawnText()
    {
        if (_visible)
        {
            Debug.Log("Sp");
            GameObject Clone = Instantiate(TextCoin, fabric_canvas.transform);
            Clone.transform.localPosition = new Vector2(0f, 0f);
        }
       
    }

    private void OnBecameVisible()
    {
        _visible = true;

    }
    private void OnBecameInvisible()
    {
        _visible = false;
    }


}
