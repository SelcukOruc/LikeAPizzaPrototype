using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CustomerAIController : MonoBehaviour
{
  
    public GameObject[] Tables;
    GameObject myTable;
  
    NavMeshAgent agent;
    TableController t_controller;

    public float contentvalue;
    public bool contentstart;

    public Transform exit_Point, start_Point;


    Animator animator;
   Transform CustomerPos;



    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < Tables.Length; i++)
        {
            if (Tables[i].GetComponent<TableController>().is_occupied == false&& Tables[i].GetComponent<TableController>().is_Customer_Entered==false&&Tables[i].activeInHierarchy==true)
            {
                Tables[i].GetComponent<TableController>().is_occupied = true;
               
                CustomerPos = Tables[i].GetComponent<TableController>().CustomerPos;
              
                agent = GetComponent<NavMeshAgent>();
             

                agent.SetDestination(Tables[i].transform.position);

                myTable = Tables[i];

               

                break;

               
            }
         

        }
       
        StartCoroutine(ContentIE());
        Debug.Log(myTable.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        //reach to the TableController which player hits and check if is_Customer_Entered != true
        // if is_Customer_Entered==false -->> is_Customer_Entered==true;

        if (other.gameObject.tag == "TableArea")
        {
            t_controller = other.gameObject.GetComponent<TableController>();
         
            myTable.GetComponent<TableController>().is_Customer_Entered = true;
           
            if (t_controller.is_Customer_Entered == true)
            {
                // PLACE SITTING ANIM HERE

                Sit();



                // satisfaction value;
                contentstart = true;

          
            }

        }



        if (other.gameObject.tag == "ExitPoint")
        {

            LoopFinished();

        }


    }

    IEnumerator ContentIE()
    {

        while (true)
        {
           
            if (contentstart && myTable.GetComponent<StackManager>().current_Count <= 0) // there is no pizza on table, customer dislikes
            {
                contentvalue -= 0.1f;

            }

            if (contentvalue <= -2) // Customer decide to leave
            {
              
                myTable.GetComponent<TableController>().is_Customer_Entered = false;
                myTable.GetComponent<TableController>().is_occupied = false;

                // PLACE WALKING BACK TO EXIT POINT HERE


                stand_Up();

            }


            yield return new WaitForSeconds(1);




        }


    }

    void LoopFinished()
    {
        transform.position = start_Point.position;
        contentstart = false;
        contentvalue = 0;
        this.gameObject.SetActive(false);
    }



    void Sit()
    {
        agent.enabled = false;

        transform.position = CustomerPos.position;
        transform.rotation = CustomerPos.rotation;

        animator.SetBool("isSat", true);
    }

    void stand_Up()
    {
        agent.enabled = true;
        animator.SetBool("isSat", false);
        agent.SetDestination(exit_Point.transform.position);
    }











}
