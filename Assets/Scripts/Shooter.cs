
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] bool useAI;

    public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(useAI){
            isFiring = true;
        }
    }

    
    void Update()
    {
        Fire();
    }

     void Fire()
    {
        if(isFiring && firingCoroutine == null){
       firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }
     float GetRandomFiringRate(){
        float randomFiringRate = Random.Range(10, 100);
        randomFiringRate /= 100;

        return randomFiringRate;
    }

    IEnumerator FireContinuously()
    {
        while(true){
            GameObject instance = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Destroy(instance, projectileLifetime);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

            if(rb != null){
                rb.velocity = transform.up * projectileSpeed;
            }
            if(useAI){
                firingRate = GetRandomFiringRate();
            }
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(firingRate);
        }
       
    }
}
