using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon",menuName = "Weapon")]
public class Weapon : ScriptableObject
//https://www.youtube.com/watch?v=q85gG0GLyG0
//Find this youtube video to store many weapons using scripts
{
    public Sprite currentWeaponSpt;

    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int bulletForce = 0;

    private void Start() {
        
    }


}
