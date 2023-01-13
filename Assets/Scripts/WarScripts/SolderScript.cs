using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderScript : MonoBehaviour
{
    public float speed;
    public int NumberPoint;
    public Transform[] pointMove;
    public int solders;
    public Transform Cell;
    private TownHall Enem;
    [SerializeField] float distance;
    [SerializeField] string Side;
    
    
    void Start()
    {
        smenaPoint();
    }

    // Update is called once per frame
    void Update()
    {

        if (pointMove!=null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Cell.position.x, transform.position.y, Cell.position.z), speed * Time.deltaTime);

            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(pointMove[NumberPoint].position.x, transform.position.y, pointMove[NumberPoint].position.z), speed * Time.deltaTime);
        }
        
    }

    //private void LateUpdate()
    //{
    //    distance = Vector3.Distance(transform.position, new Vector3(pointMove[NumberPoint].position.x, transform.position.y, pointMove[NumberPoint].position.z));

    //    if (distance <= 0.05f)
    //    {
            
    //        smenaPoint();
    //    }
    //}
    void smenaPoint()
    {

       

        //transform.LookAt(pointMove[NumberPoint]);
        transform.LookAt(Cell);


    }

    public void Enemy_enter(int sol,TownHall en,string st)
    {
        solders =sol;
        Enem = en;
        Side = st;
        //pointMove = new Transform[0];
        //pointMove[0]=Enem.transform;
        Cell = Enem.transform;
        smenaPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<TownHall>() == Enem)
        {
           
            
            if (Side=="Attack")
            {
                Enem.Uron(solders);
            }
            else if (Side == "Help")
            {
                Enem.Help(solders);
            }
            Destroy(gameObject);
        }

    }

   
}
