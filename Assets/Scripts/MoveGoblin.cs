using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoblin : MonoBehaviour
{
    public float speed;
    public int NumberPoint;
    public Transform[] pointMove;
    [SerializeField] float distance;

    public GameObject Log;
    bool to_home;
    void Start()
    {
        if (to_home==true)
        {
            Log.SetActive(true);
        }
        else
        {
            Log.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(pointMove[NumberPoint].position.x, transform.position.y, pointMove[NumberPoint].position.z),speed*Time.deltaTime);
    }

    private void LateUpdate()
    {
        distance = Vector3.Distance(transform.position, new Vector3(pointMove[NumberPoint].position.x, transform.position.y, pointMove[NumberPoint].position.z));
        
        if (distance <= 0.05f)
        {
            if (NumberPoint ==0)
            {
                to_home = false;
            }
            else if (NumberPoint+1 == pointMove.Length)
            {
                to_home = true;
            }
            smenaPoint();
        }
    }
    void smenaPoint()
    {

        if (to_home)
        {
            NumberPoint -= 1;
            Log.SetActive(true);
        }
        else
        {
            NumberPoint += 1;
            Log.SetActive(false);
        }

        transform.LookAt(pointMove[NumberPoint]);



    }
}
