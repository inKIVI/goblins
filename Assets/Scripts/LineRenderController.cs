using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderController : MonoBehaviour
{
    [SerializeField] private LineRenderer LR;
    public Transform[] points;
    void Start()
    {
        
    }

    public void setUpline(Transform[] points)
    {
        LR.positionCount = points.Length;
        this.points = points;

        ride_line();
    }
    private void LateUpdate()
    {
       
    }

    void ride_line()
    {
        for (int i = 0; i < points.Length; i++)
        {
            LR.SetPosition(i, points[i].position);
        }

    }
}
