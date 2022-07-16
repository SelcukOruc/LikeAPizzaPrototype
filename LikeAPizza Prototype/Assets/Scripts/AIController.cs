using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

   
    public GameObject[] Tables, Ovens;
    StackManager AIStackManager;

    int randomint;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // isWMoving
        AIStackManager = GetComponent<StackManager>();
    
    }

    private void Update()
    {
        LookForOven();
        LookForTable();
        SetAnimation();

    }






    private void LookForOven()
    {

        if (AIStackManager.current_Count <= 0)
        {
            if (Ovens[randomint].activeInHierarchy == true)
            {
                agent.SetDestination(Ovens[randomint].transform.position);
            }
            else
            {
                randomint = Random.Range(0, Ovens.Length);
            }

        }

    }

    private void LookForTable()
    {

        if (AIStackManager.current_Count == AIStackManager.carry_Limit)
        {
            if (Tables[randomint].activeInHierarchy == true)
            {

                if (Tables[randomint].GetComponent<StackManager>().current_Count < Tables[randomint].GetComponent<StackManager>().carry_Limit)
                {
                    agent.SetDestination(Tables[randomint].transform.position);
                }
                else
                {
                    randomint = Random.Range(0, Ovens.Length);
                }



            }
            else
            {
                randomint = Random.Range(0, Ovens.Length);
            }


          


        }

    }

    private void SetAnimation()
    {

        if (!AIStackManager.disable && !AIStackManager.enable)
        {
            animator.SetBool("isWMoving", true);
        }
        else if (AIStackManager.enable || AIStackManager.disable)
        {
            animator.SetBool("isWMoving", false);
        }

    }




    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "OvenArea"|| other.gameObject.tag == "TableArea")
        {
            randomint = Random.Range(0, Ovens.Length);
        
        }

    }





}
