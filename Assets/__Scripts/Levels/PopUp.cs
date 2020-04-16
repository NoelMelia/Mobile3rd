using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopUp : MonoBehaviour
{
    public Text messageText;//Message to display text
    public GameObject menuPanel;//Pop up frame
    // Start is called before the first frame update
    private void Start() {
        Time.timeScale = 1f;//Game playb will not be pause til someone presses button
        menuPanel.SetActive(false);//Menu panel is not visible
        
    
    }

    // Update is called once per frame
    public void BeginButton(){//Button at bottom corner of screen
        menuPanel.SetActive(true);//Menu panel appears and game is paused
        messageText.text= "Press Continue to Continue Game";
        Time.timeScale = 0f;
    }
    public void Congrats(){//Once game is completed
        menuPanel.SetActive(true);
        messageText.text= "Congratulation on Completing the Game";
        Time.timeScale = 0f;
    }
    public void BackButton(){//Back to continue game
        menuPanel.SetActive(false);
        //messageText.text= "Press Start to Begin";
        Time.timeScale = 1f;
    }
    public void SceneLoader(int SceneIndex)//Load the game scene
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
