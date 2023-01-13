using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Kilosoft.Tools;


[ExecuteAlways]
public class PointCreateHex : MonoBehaviour
{
#if UNITY_EDITOR


    

    
    public GameObject Father;
    /*public*/ Vector3 pos_father;
    /*public */GameObject clone;
    

    public bool _1,_2,_3,_4, _5, _6;

    void Start()
    {
        if (Application.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    [EditorButton("CreateHex")]
    [ContextMenu(itemName: "CreateHEX")]
    public void Spawn()
    {
        Father=(GameObject)Resources.Load("HEX");
        if (clone == null)
        {
            clone = Instantiate(Father);

            //GetComponent<MeshRenderer>().material = (Material)Resources.Load("PointActive");
            pos_father = transform.parent.transform.position;
            for (int i = 0; i < clone.transform.childCount; i++)
            {
                //clone.transform.GetChild(i).GetComponent<PointCreateHex>().Hex = false;
                clone.transform.GetChild(i).GetComponent<PointCreateHex>().Father = Father;



            }
            clone.SetActive(true);

            if (_1)
            {
                clone.transform.position = new Vector3((pos_father.x + 0.753f), (pos_father.y), (pos_father.z - 0.87f / 2));
                //clone.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (_2)
            {
                clone.transform.position = new Vector3(pos_father.x, pos_father.y, (pos_father.z - 0.87f));

                //clone.transform.GetChild(4).gameObject.SetActive(false);
            }
            else if (_3)
            {
                clone.transform.position = new Vector3((pos_father.x - 0.753f), (pos_father.y), (pos_father.z - 0.87f / 2));
                //clone.transform.GetChild(5).gameObject.SetActive(false);
            }
            else if (_4)
            {
                clone.transform.position = new Vector3((pos_father.x - 0.753f), (pos_father.y), (pos_father.z + 0.87f / 2));
                //clone.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (_5)
            {
                clone.transform.position = new Vector3(pos_father.x, pos_father.y, (pos_father.z + 0.87f));
                //clone.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (_6)
            {
                clone.transform.position = new Vector3((pos_father.x + 0.753f), (pos_father.y), (pos_father.z + 0.87f / 2));
                //clone.transform.GetChild(2).gameObject.SetActive(false);
            }


        }

    }

    [ContextMenu(itemName: "DeleteHEX")]
    public void DeleteClone()
    {

        if (clone != null)
        {
            DestroyImmediate(clone);
            GetComponent<MeshRenderer>().material = (Material)Resources.Load("PointOFF");
        }

    }

#endif
#if UNITY_ANDROID

    private void Awake()
    {
       
                //Destroy(gameObject);
            
        
    }
#endif
}
