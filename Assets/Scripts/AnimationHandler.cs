using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : PlayerController
{
    float horizontalInput=0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeScale",0,3);
    }

    // Update is called once per frame
    void Update()
    {
        KeepOnGround();
        Move();
    }
    //Generate random inputs for simulating player controls.
    void ChangeScale(){
        float yScale=Random.Range(1,4);
            transform.localScale = new Vector3(1,yScale,1);
                    horizontalInput=Random.Range(1f,-1f);
    }
    //Base Movement Script
    public override void Move(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.x > xRange){
            transform.position=new Vector3(xRange,transform.position.y,transform.position.z);
        }
                if(transform.position.x < -xRange){
            transform.position=new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        if(transform.position.z >24){
            transform.position=new Vector3(transform.position.x,0 + transform.localScale.y/2,0);
            
        }
    }
}
