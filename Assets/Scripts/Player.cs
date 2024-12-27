using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 100;
    public float playerResource = 100;

    public HealthBar healthBar;
    public ResourceBar resourceBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            hit(20);
        if (Input.GetKeyDown(KeyCode.R))
            useResource(20);
        
    }

    public void hit(int damage)
    {
        Debug.Log("Hit for " + damage + " Damage");
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
        if (playerHealth <= 0) //If the Player is Dead Set Bool and Disable External Control Scripts
        {
            //Player Dies
            //transform.GetChild(1).GetComponent<WeaponHandler>().enabled = false;
            //isDead = true;
            // DeathScreen.SetActive(true);
            //Debug.Log("isDead = " + isDead); //Testing Only
            Debug.Log("Player is Dead at " + playerHealth + " Health. The Final Hit Dealt " + damage + " Damage."); //Testing Only
            
            //Bring up Death Screen - Not Currently Implemented

        }
    }
    public void useResource(float usedResource)
    {
        Debug.Log("Used " + usedResource + " Resource");
        playerResource -= usedResource;
        resourceBar.SetResource(playerResource);
        if (playerResource <= 0) //If the Player is Dead Set Bool and Disable External Control Scripts
        {
            Debug.Log("You are out of resources!");

        }
    }


}
