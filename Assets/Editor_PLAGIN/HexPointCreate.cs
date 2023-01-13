using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kilosoft.Tools;
[ExecuteAlways]
public class HexPointCreate : MonoBehaviour
{
#if UNITY_EDITOR


    private GameObject Point;

   public GameObject[] _PointCreateHex;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [EditorButton("CreatePoint")]
    //[ContextMenu(itemName: "SpawnPoint")]
    public void SPAWN_POINT()
    {
       Point = (GameObject)Resources.Load("point");
        for (int i = 0; i < 6; i++)
        {
            PointCreateHex point_clone = Instantiate(Point, gameObject.transform).GetComponent<PointCreateHex>();
            if (i==0)
            {
                
                point_clone.transform.localPosition = new Vector3(0.359999985f, 0.0799999982f, -0.179999799f);
                point_clone._1 = true;
                Debug.Log(i);
            }
            else if (i == 1)
            {
                point_clone.transform.localPosition = new Vector3(0f, 0.0799999982f, -0.420000076f);
                point_clone._2 = true;
            }
            else if (i == 2)
            {
                point_clone.transform.localPosition = new Vector3(-0.379999995f, 0.0799999982f, -0.179999799f);
                point_clone._3 = true;
            }
            else if (i == 3)
            {
                point_clone.transform.localPosition = new Vector3(-0.379999995f, 0.0799999982f, 0.179999799f);
                point_clone._4 = true;
            }
            else if (i == 4)
            {
                point_clone.transform.localPosition = new Vector3(0f, 0.0799999982f, 0.399999857f);
                point_clone._5 = true;
            }
            else if (i == 5)
            {
                point_clone.transform.localPosition = new Vector3(0.359999985f, 0.0799999982f, 0.179999828f);
                point_clone._6 = true;
            }
            point_clone.gameObject.name = "Point";

        }
    
    }




    //[EditorButton("CreateLineRenderPoint")]
    [ContextMenu(itemName: "Create_LineRender_Point")]
    public void SpawnRenderPoint()
    {
        Point = (GameObject)Resources.Load("LinePoint");
        for (int i = 0; i < 6; i++)
        {
           GameObject pointLine_Clone = Instantiate(Point, gameObject.transform);
            if (i == 0)
            {

                pointLine_Clone.transform.localPosition = new Vector3(-0.5f, 0.1f, 0);
               
            }
            else if (i == 1)
            {
                pointLine_Clone.transform.localPosition = new Vector3(-0.25f, 0.1f, -0.43f);

            }
            else if (i == 2)
            {
                pointLine_Clone.transform.localPosition = new Vector3(0.5f, 0.1f, 0);

            }
            else if (i == 3)
            {
                pointLine_Clone.transform.localPosition = new Vector3(0.25f, 0.1f, -0.43f);

            }
            else if (i == 4)
            {
                pointLine_Clone.transform.localPosition = new Vector3(0.25f, 0.1f, 0.43f);

            }
            else if (i == 5)
            {
                pointLine_Clone.transform.localPosition = new Vector3(-0.25f, 0.1f, 0.43f);

            }
            pointLine_Clone.gameObject.name = "PointLine";

        }

    }
    [ContextMenu(itemName: "Delete_Line_Point")]
    public void LinePointEnter()
    {
        
        _PointCreateHex = new GameObject[6];
        int P=0;
        for (int i = 0; i < transform.childCount; i++)
        {


            if (transform.GetChild(i).name == "PointLine")
            {
                _PointCreateHex[P] = transform.GetChild(i).gameObject;
                P++;
                
            }
        }


        for (int i = 0; i < _PointCreateHex.Length; i++)
        {
            if (_PointCreateHex[i].tag != "LineRenderZone")
            {
                DestroyImmediate(_PointCreateHex[i]);
            }


        }
        _PointCreateHex = new GameObject[0];



    }




    [ContextMenu(itemName: "Delete_Create_Point")]
    public void DelCreatePoint()
    {
        _PointCreateHex = new GameObject[6];
        int P = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            

            if (transform.GetChild(i).name == "Point")
            {
                _PointCreateHex[P] = transform.GetChild(i).gameObject;
                //DestroyImmediate(test[i]);
                P++;
            }
        }


        for (int i = 0; i < _PointCreateHex.Length; i++)
        {


            DestroyImmediate(_PointCreateHex[i]);
        }
        _PointCreateHex = new GameObject[0];
    }


    //[ContextMenu(itemName: "Delete_Line_Point")]
    //public void DelLinePoint()
    //{
    //    _PointCreateHex = new GameObject[6];
    //    for (int i = 0; i < transform.childCount; i++)
    //    {


    //        if (transform.GetChild(i).name == "Point")
    //        {
    //            _PointCreateHex[i] = transform.GetChild(i).gameObject;
    //            //DestroyImmediate(test[i]);
    //        }
    //    }


    //    for (int i = 0; i < _PointCreateHex.Length; i++)
    //    {


    //        DestroyImmediate(_PointCreateHex[i]);
    //    }

    //}


#endif
}
