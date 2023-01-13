using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public LayerMask whatclick;

    public GameObject clickDown;
    public GameObject clickUP;

    public Material smenamattest;

    public bool Tutorial;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
            {
                //Debug.Log(hitinfo.collider.name);
                clickDown = hitinfo.collider.gameObject;
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
            {
                //Debug.Log(hitinfo.collider.name);
                clickUP = hitinfo.collider.gameObject;


                if (clickUP == clickDown)
                {
                    clickDown.GetComponent<MeshRenderer>().material = smenamattest;


                }

            }
        }
    }
}
