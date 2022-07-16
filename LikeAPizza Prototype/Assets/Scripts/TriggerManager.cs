using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    StackManager OvenStacker, TableStacker, MoneyStacker, PlayerStacker; // Stack Managers in defined objects.
    BuyArea area_To_Buy;
    public bool is_AI;

    public GameObject BuyWaitressUI;
    private void Start() { PlayerStacker = GetComponent<StackManager>(); }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MarketArea")
        {
            BuyWaitressUI.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        // Common Actions     

        // OVEN { WE TAKE PIZZA }
        if (other.gameObject.tag == "OvenArea")
        {
           
            OvenStacker = other.gameObject.GetComponent<StackManager>();
           
            if(PlayerStacker.current_Count < PlayerStacker.carry_Limit && OvenStacker.current_Count>0)
            {
                TakePizzaOven(true);
            }
            else
            {
                TakePizzaOven(false);
            }

        }
       
        // PIZZA GIVE (TABLE)
        if (other.gameObject.tag == "TableArea")
        {
           
            TableStacker = other.gameObject.GetComponent<StackManager>();
           
            if(TableStacker.current_Count < TableStacker.carry_Limit && PlayerStacker.current_Count > 0)
            {
                GivePizzaTable(true);
            }
            else
            {
                GivePizzaTable(false);
            }
       
        
        }
        
        //////////////////////////////////////////////////
        
        // Only Player Actions
       
        if (!is_AI)
        {
            // MONEY TAKE
            if (other.gameObject.tag == "MoneyArea")
            {
                MoneyStacker = other.gameObject.GetComponent<StackManager>();
                if (MoneyStacker.current_Count > 0)
                {

                    GetMoney(true);

                }
                else
                {

                    GetMoney(false);

                }


            }
            // BUY AREA
            if (other.gameObject.tag == "BuyArea")
            {
                area_To_Buy = other.gameObject.GetComponent<BuyArea>();

                if (PlayerStats.instance.Money > 0)
                {
                    area_To_Buy.Buy(1);
                    PlayerStats.instance.Money--;
                }


            }
      
        }
       


    }

    private void OnTriggerExit(Collider other)
    {
        // OVEN
        if (other.gameObject.tag == "OvenArea")
        {

            if (OvenStacker != null) 
            {

                TakePizzaOven(false);

            }


        }
        // PIZZA GIVE (TABLE)
        if (other.gameObject.tag == "TableArea")
        {
            
            if (TableStacker != null) 
            {

                GivePizzaTable(false);


            }


        }
        // MONEY TAKE
        if (other.gameObject.tag == "MoneyArea")
        {
            if (MoneyStacker != null) 
            {

                GetMoney(false);


            }
       
        
        }


        // MARKET 
        if (other.gameObject.tag == "MarketArea")
        {
            BuyWaitressUI.SetActive(false);
        }

    }

   
    
    void TakePizzaOven(bool is_Taking)
    {
        if (is_Taking)
        {
            OvenStacker.disable = true;
            PlayerStacker.enable = true;
        }
        else
        {
            OvenStacker.disable = false;
            PlayerStacker.enable = false;
        }
    }

    void GivePizzaTable(bool is_Giving)
    {
        if (is_Giving)
        {
            TableStacker.enable = true;
            PlayerStacker.disable = true;
        }
        else
        {
            TableStacker.enable = false;
            PlayerStacker.disable = false;

        }
    
    }

    void GetMoney(bool is_Getting)
    {
        if (is_Getting)
        {
            MoneyStacker.disable = true;
      
        }


        else
        {
            MoneyStacker.disable = false;
       
        }

    }







}
