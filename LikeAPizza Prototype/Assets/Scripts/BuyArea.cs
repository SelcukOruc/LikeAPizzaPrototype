using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuyArea : MonoBehaviour
{
    public Image progressImage;
    public GameObject deskObject,buyObject;
    public float cost, currentMoney, progress;
    public TextMeshProUGUI costScurrent;
    public GameObject Customer;
    public bool is_Table;
    private void Start()
    {
        costScurrent.text = cost + "/" + currentMoney;
    }

    public void Buy(int goldAmount)
    {
        currentMoney += goldAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;
        costScurrent.text = cost + "/" + currentMoney;
        if (progress >= 1)
        {
            buyObject.SetActive(false);
            deskObject.SetActive(true);
          
            if (is_Table)
            {
                Customer.SetActive(true);
            }

            
            this.enabled = false;
        }
    
    
    }



}
