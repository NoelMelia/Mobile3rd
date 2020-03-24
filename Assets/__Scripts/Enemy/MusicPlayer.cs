using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetupSingleton();
    }

    // add a method to setup as a singleton
    private void SetupSingleton(){
        //this method gets called on creation
        //check for any other music player objects
        //if there is one, then use that one
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);//persist across scenes
        }
    }
    
}
