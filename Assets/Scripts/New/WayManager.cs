using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayManager : MonoBehaviour
{
    public bool[] isActiveHex;
    public GameObject[] ways;


    void Update()
    {
        for(int i = 0; i < isActiveHex.Length; i++)
        {
            if (isActiveHex[i])
            {
                ways[i].SetActive(true);
            }
        }
    }
}
