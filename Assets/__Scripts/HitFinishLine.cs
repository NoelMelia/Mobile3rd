using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitFinishLine : MonoBehaviour
{
    [SerializeField] private string newLevel;
    void OnTriggerEnter2D(Collider2D other) {
        GameObject hitObj = other.gameObject;

        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}
