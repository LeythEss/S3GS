using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class button : MonoBehaviour
{
    public GameObject wonderwall;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void activating()
    {

        wonderwall.GetComponent<NewBehaviourScript>().increment();
        Destroy(gameObject, 0.5f);


    }
    
}
