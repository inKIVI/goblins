using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Area : MonoBehaviour
{
    [SerializeField] bool StartHex;// начальный хекс
    [SerializeField] string status;
    public bool OpenHex;
    public bool OpenZone;

   [SerializeField] private GameObject CanvasHex;
    private TextMeshProUGUI SaleText;
    /*public */COIN_MANAGER coin_M;
    private Zone ZoneFather;
    public int Price;

    private Material newColor;
    private Material LockSkin;
    private MeshRenderer MeshR;

    //private UnityEngine.Object CanvasPref;
    GameObject CanvasPrefab;

    private SphereCollider SosedCheck;

    [SerializeField] List<GameObject> SosedList;

    Vector3 StartPos;
    Vector3 FallPos;
    private string ClickHex;

    public GameObject[] ResoursesHex;

    public OpenBuildings[] Buildings;

    int payment = 20;

    //есть ли что-то в этом хексе
    public bool isSomething;
    public int idWay;
    public GameObject wayManager;

    private void Awake()
    {
        //CanvasPref = Resources.Load("CanvasHex");

        MeshR = GetComponent<MeshRenderer>();

        //подгрузка материалов из папки
        CanvasPrefab = (GameObject)Resources.Load("CanvasHex");

        newColor = (Material)Resources.Load("Material/HexMaterial/HexGrass");
        LockSkin= (Material)Resources.Load("Material/HexMaterial/HexLock");
        ///////////////////////////////////////////////////////////////////////////
        ///
        coin_M = GameObject.Find("UI").GetComponent<COIN_MANAGER>();// заменить !!!! ест много
        ZoneFather = GetComponentInParent<Zone>();
        //Load SAVE
        if (PlayerPrefs.HasKey(transform.name) && PlayerPrefs.GetString(transform.name) == "Sale")
        {
            //Debug.Log("Load");
            status = "Sale";
            OpenHex = true;
            MeshR.material = newColor;
            //OnBuiding();


           
        }
        else if (PlayerPrefs.HasKey(transform.name) && PlayerPrefs.GetString(transform.name) == "OnSale")
        {
            //Debug.Log("Load");
            status = "OnSale";
            CanvasHexCreate();
        }
        else if (StartHex)
        {
            status = "OnSale";


            CanvasHexCreate();
        }
        else
        {
            status = "Close";
        }
    }
    void Start()
    {
        transform.localScale = new Vector3(1.02f, 1, 1.02f);

        if (status=="Sale")
        {
            OnBuiding();
        }

    }

    void Update()
    {
        //if (status == "Sale")
        //    getWay();
    }

    private void LateUpdate()
    {
        if (status == "Sale")
            getWay();


        if (ClickHex == "Down")
        {
            if (transform.position.y == FallPos.y)
            {
                
                Invoke("ReturtStartPos", 0.2f);
            }

            transform.position = Vector3.MoveTowards(transform.position, FallPos, 8f * Time.deltaTime);
        }
        else if (ClickHex == "Up")
        {
            if (transform.position.y == StartPos.y)
            {

                ClickHex = null;
            }

            transform.position = Vector3.MoveTowards(transform.position, StartPos, 6f * Time.deltaTime);
        }
    }

    public void SALEHEX()  //SALE Hex
    {

        if (status== "OnSale"&&OpenZone)
        {


            if (coin_M.COIN>=Price)
            {
                StartPos = gameObject.transform.position;
                FallPos = new Vector3(gameObject.transform.position.x,-1.3f, gameObject.transform.position.z);
                
                ClickHex = "Down";

                coin_M.BuyHex(Price);// покупка 
               


                status = "Sale";// присвоение статуса 
                OpenHex = true;
                ZoneFather._OpenHex();
                ZoneFather.SoundPlay();
                CanvasHexDelete();

                



                Save();


                Debug.Log(gameObject.name + " SALE!!!");

                
                Rigidbody rb= gameObject.AddComponent<Rigidbody>();

                rb.useGravity = false;
                rb.isKinematic=true;

                SosedCheck = gameObject.AddComponent<SphereCollider>();
                SosedCheck.isTrigger = true;

                Invoke("updateSosedListExit", 0.3f);
                

            }
            else
            {
                //Debug.Log("Не хватает монет");
            }

        }
        else if (status == "Sale")
        {
            //Debug.Log("Продано");
        }
        else
        {
            //Debug.Log("!!!!НЕ ПРОДАЕТСЯ!!!");
        }

       
    }
    
    public void CanvasHexCreate()
    {
        if (OpenZone==true)
        {
            CanvasHex = (GameObject)Instantiate(CanvasPrefab, gameObject.transform);// Create HexCanvas


            if (Buildings.Length>0)//position Canvas
            {
                CanvasHex.transform.localPosition = new Vector3(-0.31f, 0.58f, 0);
                CanvasHex.transform.localEulerAngles = new Vector3(45, 90, 0);
            }
            else
            {
                CanvasHex.transform.localPosition = new Vector3(0, 0.108f, 0); 
                CanvasHex.transform.localEulerAngles = new Vector3(90, 90, 0);
            }

            


            if (GetComponentInChildren<TextMeshProUGUI>())
            {

                SaleText = CanvasHex.GetComponentInChildren<TextMeshProUGUI>();
                SaleText.text = Price.ToString();
            }

            COIN_MANAGER.OnUpdateCoin += ColorCanvas;
            ColorCanvas();
            //Save();
        }
        Save();

    }//Создание канваса

    public void CanvasHexDelete()
    {
        COIN_MANAGER.OnUpdateCoin -= ColorCanvas;
        Destroy(CanvasHex);

    }//Удаление канваса

    private void OnTriggerEnter(Collider other)
    {
        if (other!=null)
        {
            if (other.gameObject.name != gameObject.name)
            {
                if (other.gameObject.GetComponent<Area>())
                {

                    Area SosedTrig = other.gameObject.GetComponent<Area>();

                    if (SosedTrig.status == "Close")
                    {
                        SosedTrig.status = "OnSale";
                        SosedTrig.CanvasHexCreate();
                    }

                }


                

            }
        }

       
    }

    void updateSosedListExit()
    {
        CancelInvoke("updateSosedListExit");
        Destroy(SosedCheck);

    }

    void ReturtStartPos()
    {
        CancelInvoke("ReturtStartPos");
        ClickHex = "Up";

        //for (int i = 0; i < ResoursesHex.Length; i++)
        //{
        //    ResoursesHex[i].SetActive(true);
        //}

        OnBuiding();
        //for (int i = 0; i < Buildings.Length; i++) //changeColor
        //{
        //    Buildings[i].Open();
        //}
    }


    [ContextMenu(itemName: "OnBuiding")]
    public void OnBuiding()
    {
        //MeshR.material = newColor;

        for (int i = 0; i < Buildings.Length; i++) //changeColor
        {
            Buildings[i].Open();
        }
        MeshR.material = newColor;
    }

    [ContextMenu(itemName: "OFFBuiding")]
    public void OffBuiding()
    {
        for (int i = 0; i < ResoursesHex.Length; i++)
        {
            ResoursesHex[i].SetActive(false);
        }

    }


    void Save()
    {
        if (status=="Sale"|| status == "OnSale")
        {
            PlayerPrefs.SetString(transform.name, status);
            //Debug.Log("SAVE....."+ status);
        }
       

    }//сохранение



    public void _OpenZone()
    {
        OpenZone = true;
        if (status=="OnSale"&&!StartHex)
        {
            CanvasHexCreate();
        }
    }
    void ColorCanvas()
    {
        if (coin_M.COIN <Price)
        {
            SaleText.color = Color.red;
        }
        else
        {
            SaleText.color = Color.yellow;
        }
    }

    //Новое
    void getWay()
    {
        if (isSomething)
        {
            wayManager.GetComponent<WayManager>().isActiveHex[idWay] = true;
        }
    }
}
