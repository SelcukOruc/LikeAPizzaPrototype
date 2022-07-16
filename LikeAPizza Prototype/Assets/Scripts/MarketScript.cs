using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MarketScript : MonoBehaviour
{
    [SerializeField] private Button WaitressBuyButton;
    public List<GameObject> WaitressList = new List<GameObject>();
    [SerializeField] private int WaitressCost = 150;
   

    public void BuyWaitress()
    {

        if (PlayerStats.instance.Money > WaitressCost&&WaitressList.Count>0)
        {
           
            PlayerStats.instance.Money -= WaitressCost;
            WaitressList[WaitressList.Count - 1].SetActive(true);
            WaitressList.RemoveAt(WaitressList.Count - 1);


            if (WaitressList.Count <= 0) { WaitressBuyButton.interactable = false; }
        }
       
       
        

    }

}
