using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MobileHealthController : MonoBehaviour
{
    public GameObject menuPanel;
    public float playerHealth;
    public Text messageText;
    [SerializeField]private Text healthText;

    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("0");

        if(playerHealth <= 0)
        {
            Debug.Log("GAME OVER");
            BeginButton();
        }
    }
    public void BeginButton(){
        menuPanel.SetActive(true);
        messageText.text= "Game Over";
        Time.timeScale = 0f;
    }
    public static MobileHealthController FindHealthController()
        {
            MobileHealthController sc = FindObjectOfType<MobileHealthController>();
            if(!sc)
            {
                Debug.LogWarning("Missing Health controller");
            }
            return sc;
    }
}
