using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MobileHealthController : MonoBehaviour
{
    //Menu To appear if the players health drops to 0
    public GameObject menuPanel;
    //Game Over Pop Up Message
    public Text messageText;
    public float currentHealth = 100;
    public Text healthText;
    public void UpdateHealth()//Displaying the health on screen and updating when impacted
    {
        healthText.text = currentHealth.ToString("0");
        //Once players health is at 0 then pop up message starts
        if(currentHealth <= 0)
        {
            //Debug.Log("GAME OVER");
            BeginButton();
        }
        //Debug.Log("Health Controller"+healthText.text);
    }
    public void BeginButton(){
        //Method to Pop up message and pause the movement of game
        menuPanel.SetActive(true);
        messageText.text= "Game Over";
        Time.timeScale = 0f;
    }
    public static MobileHealthController FindHealthController()
    {
        //Method to Finding the Controller if there is one
        MobileHealthController sc = FindObjectOfType<MobileHealthController>();
        if(!sc)
        {
            Debug.LogWarning("Missing Health controller");
        }
        return sc;
    }
}
