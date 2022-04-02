using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform looAt;//nhan vat
    private Vector3 startOffset;//khoang cach offset
    private Vector3 moveVector;//vector di chuyen
    private float transiton=0.0f;//khoang bien doi
    private float animationDuration = 3.0f;//thoi gian animation
    private Vector3 animationOffset = new Vector3(0,5,5);//khoi tao vector
    void Start()
    {
        looAt=GameObject.FindGameObjectWithTag("player").transform;
        startOffset=transform.position-looAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector=looAt.position+startOffset;
        //theo truc x
        moveVector.x=0;
        //theo truc y
        moveVector.y=Mathf.Clamp(moveVector.y,3,5);
        if(transiton>1.0f){
            transform.position=moveVector;//cap nhatvi tri cua camera theo nhan vat
        }else{
            transform.position=Vector3.Lerp(moveVector+animationOffset,moveVector,transiton);
            transiton+=Time.deltaTime*(1/animationDuration);
            transform.LookAt(looAt.position+Vector3.up);
        }
    }
}
