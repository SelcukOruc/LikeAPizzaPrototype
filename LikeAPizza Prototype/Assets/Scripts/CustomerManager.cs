using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<GameObject> customer_List = new List<GameObject>();


    private void Start()
    {

        StartCoroutine(Spawner());

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Customer")
        {
            customer_List.Add(other.gameObject);
           
        }

    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            if (customer_List.Count-1>=0)
            {
                customer_List[customer_List.Count - 1].SetActive(true);
                customer_List.RemoveAt(customer_List.Count - 1);

                yield return new WaitForSeconds(2);
            }

            yield return new WaitForSeconds(1);
        }


    }




}







