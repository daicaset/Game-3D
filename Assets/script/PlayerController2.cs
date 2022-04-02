using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private float speed = 5f;
    private CharacterController controller;
    private float verticalVelocity =0.0f;
    private float gravity = 10.0f;
    Vector3 moveVector;
    private float animationDuration = 3.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        if(Time.time < animationDuration){
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector=Vector3.zero;
        if(controller.isGrounded){
            verticalVelocity=0.5f;
        }else{
            verticalVelocity=gravity*Time.deltaTime;
        }
        moveVector.x=Input.GetAxisRaw("Horizontal") *speed;
        moveVector.y=0;
        moveVector.z=speed;
        controller.Move(moveVector*Time.deltaTime);
    }

    public void SetSpeed(float difficultLevel)
    {
        speed=difficultLevel + 5.0f;
    }
}
