using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    MobileHealthController healthController;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();//Looking for Text Field
    }

    // Update is called once per frame
    void Update()
    {//Updating score to the Canvas menu at top of scene
        score.text = "Score: "+scoreValue;
    }

    
}
