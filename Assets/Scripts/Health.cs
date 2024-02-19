using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    
    CameraShake cameraShake;
    DamageDealer damageDealer;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public int GetHealth(){
        return health;
    }
    void PlayHitEffect(){
    if(hitEffect != null){
        ParticleSystem instance = Instantiate(hitEffect, transform.position,transform.rotation);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }
    }
    void OnTriggerEnter2D(Collider2D other) {
        damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null){

            TakeDamage();
            audioPlayer.PlayDamageClip();
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    
    void TakeDamage(){
        int damage = damageDealer.GetDamage();
        health = health - damage;
        if(health == 0 && gameObject.tag == "Enemy"){
            
            scoreKeeper.ModifyScore(10);
            Destroy(gameObject);
            
        }
        else if(health == 0 && gameObject.tag == "player" ){
            Destroy(gameObject);
            levelManager.LoadGameOver();
        }

    
    }
    void ShakeCamera(){
        if(cameraShake != null && applyCameraShake){
            cameraShake.Play();
        }
    }
}
