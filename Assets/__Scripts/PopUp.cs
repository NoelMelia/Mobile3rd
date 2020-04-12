using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopUp : MonoBehaviour
{
    public Text messageText;
    public GameObject menuPanel;
    // Start is called before the first frame update
    private void Start() {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
        
    
    }

    // Update is called once per frame
    public void BeginButton(){
        menuPanel.SetActive(true);
        messageText.text= "Press Continue to Continue Game";
        Time.timeScale = 0f;
    }
    public void Congrats(){
        menuPanel.SetActive(true);
        messageText.text= "Congratulation on Completing the Game";
        Time.timeScale = 0f;
    }
    public void BackButton(){
        menuPanel.SetActive(false);
        //messageText.text= "Press Start to Begin";
        Time.timeScale = 1f;
    }
    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
