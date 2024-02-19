using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   [Header("Shooting")]
   [SerializeField] AudioClip shootingClip;
   [SerializeField] [Range(0f,1f)]float shootingVolume = 1f;
   [Header("Damage")]
   [SerializeField] AudioClip damageClip;
   [SerializeField] [Range(0f,1f)]float damageVolume = 1f;
    void Awake() {
        ManageSingleton();  
   } 
   void ManageSingleton(){
    int instanceCount = FindObjectsOfType(GetType()).Length;
    if(instanceCount > 1){
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    else{
        DontDestroyOnLoad(gameObject);
    }
   }
    public void PlayShootingClip(){
        if(shootingClip != null){
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }
    public void PlayDamageClip(){
        if(shootingClip != null){
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
        }
    }
    
}
