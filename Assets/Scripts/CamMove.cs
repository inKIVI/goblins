using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMove : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;



    public LayerMask whatclick;

    public GameObject clickDown;
    public GameObject clickUP;

    public Material smenamattest;

    public bool Tutorial;

    [SerializeField] Camera Cam;

    Vector3 PosEnd, PosSmoth;

    public bool _Drag;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchStart = Cam.ScreenToWorldPoint(Input.mousePosition);


            //Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray myRay = Cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitinfo;
            if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
            {

                //clickDown = hitinfo.collider.gameObject;

                clickUP = hitinfo.collider.gameObject;


                //if (clickUP == clickDown)
                //{


                //    clickUP.GetComponent<Area>().SALEHEX();
                //}

                clickUP.GetComponent<Area>().SALEHEX();

            }

        }


        
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0)&& Input.touchCount ==1&&_Drag==true)
        {
           

            Vector3 direction = touchStart - Cam.ScreenToWorldPoint(Input.mousePosition);

            PosEnd = Cam.transform.position += direction;
            PosSmoth = Vector3.Lerp(Cam.transform.position, PosEnd,0.05f);

            //Cam.transform.position += direction;

            Cam.transform.position = PosSmoth;
            //Debug.Log("Drag!!!!!!!!!");
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
















        //if (Input.touchCount == 2)
        //{
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //    float difference = currentMagnitude - prevMagnitude;

        //    zoom(difference * 0.01f);
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Camera.main.transform.position += direction;
        //    //Debug.Log("Drag!!!!!!!!!");
        //}
        //zoom(Input.GetAxis("Mouse ScrollWheel"));











        //if (Input.GetMouseButtonUp(0))
        //{


        //    //Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    Ray myRay = Cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitinfo;
        //    if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
        //    {

        //        clickUP = hitinfo.collider.gameObject;

        //        Debug.Log("UP");
        //        if (clickUP == clickDown)
        //        {


        //            clickUP.GetComponent<Area>().SALEHEX();
        //        }

        //    }

        //}














        //if (Input.GetMouseButtonDown(0))
        //{
        //    //touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    touchStart = Cam.ScreenToWorldPoint(Input.mousePosition);


        //    //Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Ray myRay = Cam.ScreenPointToRay(Input.mousePosition);

        //    RaycastHit hitinfo;
        //    if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
        //    {

        //        clickDown = hitinfo.collider.gameObject;

        //        //Debug.Log("CLICK");
        //    }

        //}
        //if (Input.touchCount == 2)
        //{
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //    float difference = currentMagnitude - prevMagnitude;

        //    zoom(difference * 0.01f);
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Camera.main.transform.position += direction;
        //    //Debug.Log("Drag!!!!!!!!!");
        //}
        //zoom(Input.GetAxis("Mouse ScrollWheel"));



        //if (Input.GetMouseButtonUp(0))
        //{


        //    //Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    Ray myRay = Cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitinfo;
        //    if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
        //    {

        //        clickUP = hitinfo.collider.gameObject;

        //        Debug.Log("UP");
        //        if (clickUP == clickDown)
        //        {


        //            clickUP.GetComponent<Area>().SALEHEX();
        //        }

        //    }

        //}
    }

    void zoom(float increment)
    {
        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);

        Cam.orthographicSize = Mathf.Clamp(Cam.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    public void Dr()
    {
        _Drag = true;
    
    }
    public void Dr2()
    {
        _Drag = false;

    }
}
