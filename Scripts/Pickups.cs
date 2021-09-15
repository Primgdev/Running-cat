using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickups : MonoBehaviour
{


   
    public string reciever;
    
    

    private void Update()
    {
        transform.Rotate(new Vector3(0, 5, 0));
        

       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage(reciever);
          
            Destroy(gameObject);

        }
        
    }


    
}
