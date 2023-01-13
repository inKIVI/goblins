using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLine : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] LineRenderController line;
    void Start()
    {
        line.setUpline(points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
