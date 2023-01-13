using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLineRender : MonoBehaviour
{
    private LineRenderer LineRenderComponent;

    public GameObject origin;
    public GameObject end;

    public CameraMove2 camMove;

    [SerializeField] private Camera Cam;
    [SerializeField] private LayerMask layer;
    public LayerMask whatclick;

    public bool lineCheck;

    public GameObject endObj;


    void Start()
    {
        LineRenderComponent = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(myRay, out hitinfo, 30f, whatclick))
            {
                if (hitinfo.collider.gameObject.tag == "Line")
                {
                    lineCheck = true;
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            LineRenderComponent.enabled = false;
            camMove.enabled = true;
            lineCheck = false;
            endObj.SetActive(false);
            end.transform.position = new Vector3(0, 0.25f, 0);

        }

        if (lineCheck)
        {
            showLine();
        }

    }

    public void showLine()
    {
        //end.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        LineRenderComponent.enabled = true;
        camMove.enabled = false;
        LineRenderComponent.SetPosition(0, origin.transform.position);
        LineRenderComponent.SetPosition(1, end.transform.position);

        endObj.SetActive(true);


        Ray ray = Cam.ScreenPointToRay(Input.mousePosition); 
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layer))
        {
            end.transform.position = new Vector3(raycastHit.point.x, 0.25f, raycastHit.point.z); 
        }
    }
}
