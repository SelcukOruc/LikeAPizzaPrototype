using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public StackManager stacker_Table;
    [SerializeField] private StackManager stacker_Money;
    public bool is_Customer_Entered;
    public bool is_occupied;

    public Transform CustomerPos;
    void Start()
    {
        stacker_Table = GetComponent<StackManager>();
    }

   
    void Update()
    {
        if (stacker_Table.current_Count > 0 && is_Customer_Entered) // Customer Sits || There is pizza
        {
            stacker_Table.disable = true;
            stacker_Money.enable = true;
        }
        else // Customer leaves || there is no pizza
        {
            stacker_Table.disable = false;
            stacker_Money.enable = false;
        }

    }



}
