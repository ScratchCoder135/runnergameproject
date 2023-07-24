using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gate : MonoBehaviour
{
    public float addValue;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=new Vector3(transform.position.x,1,transform.position.z);
        string display;
        if(addValue>0){
            display="+"+addValue;
        }else{
            display=addValue.ToString();
        }
        text.text=display;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
