using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG;
using DG.Tweening;
public class StackManager : MonoBehaviour
{
    public List<GameObject> s_objs = new List<GameObject>();
    public bool enable;
    public bool disable;

    public int current_Count; //
    public int carry_Limit; //  max value = child.count - 1  || min value = 0
    public float disable_Delay, enable_Delay;

    public bool is_MoneyGenerator;

    public TextMeshProUGUI FullText;

    public AudioSource pickup_SFX;
    void Start()
    {

        StartCoroutine(GenerateStack());
        StartCoroutine(DeGenerateStack());
      
      
    }





    IEnumerator GenerateStack() 
    {
        while (true)
        {

          

           
         
            if (enable)
            {
                for (current_Count= 0; current_Count < transform.childCount - 1; current_Count++)
                {
                 
                   
                    if (transform.GetChild(current_Count).gameObject.activeInHierarchy == false)
                    {
                        if (!enable) { break; }
                        s_objs.Add(transform.GetChild(current_Count).gameObject);
                       
                        transform.GetChild(current_Count).gameObject.SetActive(true);
                      
                        if (!is_MoneyGenerator) { PlaySound(); }
                       
                        
                        yield return new WaitForSeconds(enable_Delay); //Activate Delay
                   
                    }

                   
                }


                if (current_Count >= transform.childCount - 1&&FullText!=null)
                {
                    FullText.gameObject.SetActive(true);
                }
                // FULL UI
            
            
            }








            yield return new WaitForSeconds(0.1f); 


        }
       

    }


    IEnumerator DeGenerateStack()
    {
        while (true)
        {
            if (disable)
            {
                if (FullText != null) { FullText.gameObject.SetActive(false); }
              
                if (s_objs.Count > 0)
                {
                    if (transform.GetChild(s_objs.Count - 1).gameObject.activeInHierarchy == true)
                    {
                       
                        current_Count--;
                        transform.GetChild(s_objs.Count - 1).gameObject.SetActive(false);
                        s_objs.RemoveAt(s_objs.Count - 1);

                        PlaySound();

                        if (is_MoneyGenerator) { PlayerStats.instance.Money++; PlaySound(); }


                    }

               
                }
            }

            yield return new WaitForSeconds(disable_Delay); // Remove Delay
        }
       
    }

    void PlaySound()
    {
        if (pickup_SFX != null) { pickup_SFX.Play(); }
    }
  
}
