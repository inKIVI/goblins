using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    private bool isInZoom;

    public LayerMask whatclick;

    public GameObject TownHallObj;
    public GameObject Enemy;
    public GameObject Target;
    public GameObject clickUP;

    public Material smenamattest;

    public bool Tutorial;

    [SerializeField] Camera Cam;

    [SerializeField] Camera CamBuid;

    Vector3 PosEnd, PosSmoth;

    //Стрелка
    private LineRenderer LineRenderComponent;

    public GameObject origin; //начало
    public GameObject end; //конец

    private bool camMove; //блокировка движения камеры

    [SerializeField] private LayerMask layer;

    public bool lineCheck;

    public GameObject endObj; // конец стрелки
    private void Start()
    {
        LineRenderComponent = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && camMove)
        {
            if (!isInZoom)
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchStart = Cam.ScreenToWorldPoint(Input.mousePosition);

            Ray myRay = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
            {

                //clickDown = hitinfo.collider.gameObject;

                clickUP = hitinfo.collider.gameObject;


               

                clickUP.GetComponent<Area>().SALEHEX();

            }
        }
        if (Input.touchCount == 2)
        {
            isInZoom = true;
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0) && camMove)
        {
            if (!isInZoom)
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Cam.transform.position += direction;
            }
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.touchCount == 0)
            isInZoom = false;

        // все что связано со стрелкой
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(myRay, out hitinfo, 30f))
            {
                if (hitinfo.collider.gameObject.tag == "Line")
                {
                    lineCheck = true;
                    origin.transform.position = new Vector3(hitinfo.transform.position.x, 0.25f, hitinfo.transform.position.z);

                    TownHallObj = hitinfo.collider.gameObject;
                    Debug.Log("Ратуша выбрана");
                }

               

            }
        }
       
        else if (Input.GetMouseButtonUp(0))
        {
            if (lineCheck)
            {
               

                if (Enemy!=null)
                {

                    TownHallObj.GetComponent<TownHall>().EnemyEnter(Enemy);


                    //clickDown.GetComponent<TownHall>().EnemyEnter(Enemy);

                    Debug.Log("Attack");

                    TownHallObj = null;
                    Enemy = null;
                }
                else if (Target!=null&&Target!=TownHallObj)
                {
                    
                    TownHallObj.GetComponent<TownHall>().EnemyEnter(Target);

                    TownHallObj = null;
                    Target = null;
                }

            }


            LineRenderComponent.enabled = false;
            camMove = true;
            lineCheck = false;
            endObj.SetActive(false);
            end.transform.position = origin.transform.position;

           

        }

        if (lineCheck)
        {
            showLine();
        }
    }

    private void LateUpdate()
    {
        
    }

    void zoom(float increment)
    {
        Cam.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);

        CamBuid.orthographicSize= Cam.orthographicSize;
    }

    public void showLine()
    {
        //end.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        LineRenderComponent.enabled = true;
        camMove = false;
        LineRenderComponent.SetPosition(0, origin.transform.position);
        LineRenderComponent.SetPosition(1, end.transform.position);

        endObj.SetActive(true);


        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layer))
        {
            end.transform.position = new Vector3(raycastHit.point.x, 0.25f, raycastHit.point.z);
        }
        Ray rayEnemy = Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHitEnemy))
        {
            if (raycastHitEnemy.collider.tag == "Enemy")
            {
                
                Enemy = raycastHitEnemy.collider.gameObject;
            }
            else if (raycastHitEnemy.collider.tag =="Line")
            {
                Target= raycastHitEnemy.collider.gameObject;
            }
            else 
            {
                Enemy = null;
                Target = null;
            }
        }

    }
}

