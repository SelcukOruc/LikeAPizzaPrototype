using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int Money;
    public int p_Speed;

    [SerializeField] private TextMeshProUGUI MoneyText;
    private void Awake()
    {
        if (instance !=null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            instance = this;
        
        }
   
    }

    private void Update()
    {
        MoneyText.text = Money.ToString();
    }
   
}
