using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] Area[] Hex_in_the_Zone;
    [SerializeField] LineRenderer line;
    [SerializeField] Transform[] ZonaLinePoint;
    public bool StartZone;
    [SerializeField] string StatusZone;
    [SerializeField] int CloseHex;
    [SerializeField] Zone NextArea;
    [SerializeField] AudioSource SoundManager;
    [SerializeField] AudioClip PopSound;

    private void Awake()
    {
        if (StartZone)
        {
            StatusZone = "Open";
        }

        if (PlayerPrefs.HasKey(transform.name))
        {
            StatusZone = PlayerPrefs.GetString(transform.name);
        }
    }
    void Start()
    {
        CloseHex = Hex_in_the_Zone.Length;


        _OpenZone();


        line.positionCount = ZonaLinePoint.Length;

        for (int i = 0; i < ZonaLinePoint.Length; i++)
        {
            line.SetPosition(i, ZonaLinePoint[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void _OpenHex()
    {
        CloseHex = Hex_in_the_Zone.Length;
        for (int i = 0; i < Hex_in_the_Zone.Length; i++)
        {
            if (Hex_in_the_Zone[i].OpenHex)
            {
                CloseHex -= 1;
            }
        }

        if (CloseHex==0)
        {

            if (NextArea!=null)
            {
                NextArea.UnlockZone();
            }
            
        }
    }

    public void _OpenZone()
    {
        if (StatusZone=="Open")
        {
            
            for (int i = 0; i < Hex_in_the_Zone.Length; i++)
            {

                Hex_in_the_Zone[i]._OpenZone();
               
            }
        }
    
    }


    public void UnlockZone()
    {
        StatusZone = "Open";
        _OpenZone();
        Save();

    }

    void Save()
    {
        PlayerPrefs.SetString(transform.name, StatusZone);
    }

    public void SoundPlay()
    {
        SoundManager.PlayOneShot(PopSound);
    }

    [ContextMenu(itemName: "OrderNumberPoint")]
    public void OrderNumberPoint()
    {

        for (int i = 0; i < ZonaLinePoint.Length; i++)
        {
            if (ZonaLinePoint[i].name!=ZonaLinePoint[i].GetSiblingIndex().ToString())
            {
                int number = int.Parse(ZonaLinePoint[i].name);

                ZonaLinePoint[i].transform.SetSiblingIndex(number);
            }
        }

        

       
    }
}
