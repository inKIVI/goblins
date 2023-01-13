using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public enum Side
{
    Goblin,
    Enemy,
}
public class TownHall : MonoBehaviour
{
    [SerializeField] Side _Side;
    [SerializeField] int Solder=5;
    [SerializeField] TownHall EnemyTownHall;
    [SerializeField] GameObject army;
    private OpenBuildings _OpenBuildings;

    [SerializeField] Material c1;
    [SerializeField] Material c2;

    [SerializeField] TextMeshProUGUI textsolder;

    private void Awake()
    {

        _OpenBuildings = GetComponent<OpenBuildings>();


        if (_Side == Side.Enemy)
        {
            textsolder.gameObject.SetActive(true);
            tag = "Line";
        }
        else
        {
            tag = "Untagged";
            textsolder.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
       
            NewColor();
            
            canvasUpdate();


        if (_Side==Side.Enemy)
        {
            
            spawn();
        }
        
            

            
            textsolder.transform.localEulerAngles = new Vector3(45, 0, 0);

            //spawn();

           
        

        
    }

    public void Uron(int sol)
    {
        Solder -= sol;
        if (Solder<0)
        {
            SmenaOwner();


        }
        canvasUpdate();
    }
    public void Help(int sol)
    {
        Solder += sol;
        
        canvasUpdate();
    }

    public void EnemyEnter(GameObject en)
    {
        
        if (en.GetComponent<TownHall>()._Side!=_Side)
        {
            EnemyTownHall = en.GetComponent<TownHall>();
            Debug.Log("Враг обнаружен");

          
            if (Solder!=0)
            {
               
                SpawnArmy();
            }


        }
        else
        {
            EnemyTownHall = en.GetComponent<TownHall>();
            Debug.Log("Союзник обнаружен");
            if (Solder != 0)
            {

                
                SpawnArmy();
            }
        }


    }


    void SpawnArmy()
    {
        string status;

        GameObject clone= Instantiate(army, new Vector3(1.665f, 0.276f, -4.35f), gameObject.transform.rotation);

       
       

        clone.transform.position = new Vector3(transform.position.x, 0.276f, transform.position.z);
        clone.SetActive(true);

        if (EnemyTownHall._Side==_Side)
        {
            status = "Help";
        }
        else
        {
            status = "Attack";
        }
        
        clone.GetComponent<SolderScript>().Enemy_enter(Solder,EnemyTownHall,status);
        Solder = 0;
        canvasUpdate();
    }

    void canvasUpdate()
    {
        textsolder.text = Solder.ToString();
        //textsolder.transform.LookAt(Camera.main.transform);

       
    }

    public void StartSpawn()
    {
        tag = "Line";
        spawn();

        textsolder.gameObject.SetActive(true);
    }
    void spawn()
    {
        Solder++;
        Invoke("spawn", 5f);
        canvasUpdate();
    }

    void NewColor()
    {
        MeshRenderer m = GetComponentInChildren<MeshRenderer>();
        if (_Side == Side.Goblin)
        {
            
            m.material = c1;
        }
        else
        {
            m.material = c2;
        }
    }

    void SmenaOwner()
    {

        if (_Side==Side.Enemy)
        {
            gameObject.tag = "Line";
            Solder = 0;
            _Side = Side.Goblin;
            NewColor();
        }
        else
        {
            gameObject.tag = "Enemy";
            Solder = 0;
            _Side = Side.Enemy;
            NewColor();
        }
    }
}
