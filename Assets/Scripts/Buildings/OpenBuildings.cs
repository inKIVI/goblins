using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuildings : MonoBehaviour
{
    [SerializeField] MeshRenderer render;
    [SerializeField] Material MaterialLock;
    [SerializeField] Material MaterialOpen;
    public bool statusOpen;
    [SerializeField] TownHall Th;

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
        if (gameObject.GetComponent<TownHall>())
        {
            Th = GetComponent<TownHall>();
        }
    }
    public void Lock()
    {
        if (MaterialLock)
        {
            render.material = MaterialLock;
        }

        
    }

    public void Open()
    {
        statusOpen = true;

        
        if (MaterialOpen)
        {
            render.material = MaterialOpen;
        }

        if (Th)
        {
            Th.StartSpawn();
        }
       
    }
}
