using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]private GameObject player;
    public Vector3 offset;
    private PlayerController playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript=player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void LateUpdate() {
        if(!playerScript.isGameEnded){
        offset=new Vector3(0,1+player.transform.localScale.y/2,-2.9f);
        
        transform.position=player.transform.position + offset;
        }
    }
}
