using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Kilosoft.Tools;

[ExecuteAlways]
public class HEX_create : MonoBehaviour
{


   


    [ContextMenu(itemName: "NameHex")]
    public void RenameHex()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Area>())
            {
                transform.GetChild(i).name = "HEX_WORLD" + i;
            }
        }
    }
    [EditorButton("DeletePoint")]
    [ContextMenu(itemName: "Delete_point")]
    public void DeletePoint()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Area>())
            {
                GameObject hex = transform.GetChild(i).gameObject;

                for (int z = 0; z < hex.transform.childCount; z++)
                {
                    if (hex.transform.GetChild(z).name=="Point")
                    {
                        DestroyImmediate(hex.transform.GetChild(z).gameObject);
                    }
                    
                }
               
            }
        }
    }


}
