using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gate : MonoBehaviour
{
    public float addValue;
    public TextMeshPro text;
    public bool isRandom;
    public bool isFixed=true;
    // Start is called before the first frame update
    void Start()
    {
        if(!isRandom){
        DisplayValue();
        }else{
            InvokeRepeating("DisplayRandomValue",0,0.05f);
            addValue=Random.Range(-30,50);
        }
    }

    public void DisplayValue(){
        if(isFixed){
        transform.position=new Vector3(transform.position.x,1,transform.position.z);
        }
        string display;
        if(addValue>0){
            display="+"+addValue;
        }else{
            display=addValue.ToString();
        }
        text.text=display;
    }
    void DisplayRandomValue(){
        transform.position=new Vector3(transform.position.x,1,transform.position.z);
        string display;
        int value=Random.Range(-100,100);
        if(value>0){
            display="+"+value;
        }else{
            display=value.ToString();
        }
        text.text=display;
    }
}
