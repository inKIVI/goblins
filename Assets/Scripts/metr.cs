using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class metr : MonoBehaviour
{
    public GameObject ob1,ob2;
    public float rast;
    public bool start;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (start)
        {
            rast = Vector3.Distance(ob1.transform.position, ob2.transform.position);
        }
       
    }
}
