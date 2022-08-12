using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemyTrigger : MonoBehaviour
{
    public bool Inrange;
    public UnityEvent interactAction;
    public UnityEvent unintercactAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Inrange)
        {
            interactAction.Invoke();
        }
        if (!Inrange)
            unintercactAction.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Inrange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Inrange = false;
    }
}
