using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public Behaviour[] disableOnDeath;
    float Health;
    public Slider healthSlider;
    GameObject[] enemies;
    public float MaxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
    }
    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (gameObject.tag == "Player")
            healthSlider.value = Health / MaxHealth;
        if (Health <= 0)
        {
            Health = 0;
            Die();

        }
    }

    public void Die()
    {
        //Disable all the components inside the disableOnDeath array that you will assign from the inspector
        foreach (Behaviour behaviour in disableOnDeath)
        {
            behaviour.enabled = false;

            if (gameObject.tag == "robot")
                destroyenemy();

        }
    }

    void destroyenemy()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(gameObject);
        }
    }

}
