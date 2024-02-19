using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Shooter shooter;

    Vector2 rawInput;

    Vector2 minBounds;
    Vector2 maxBounds;
    void Update()
    {
        Move();
    }
    void Awake() {
        shooter = GetComponent<Shooter>();
    }

    void Start() {
        InitBounds();
    }

    void OnMove(InputValue value){
      rawInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value){
      if(shooter != null){
        shooter.isFiring = value.isPressed;
      }
    }

    void InitBounds(){
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2 (0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2 (1,1));
    }

    void Move(){
        Vector2 movement = rawInput * Time.deltaTime * moveSpeed;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + movement.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + movement.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }


}
