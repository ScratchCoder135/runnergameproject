using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField]private GameObject player;
    public Vector3 offset;
    private AnimationHandler playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript=player.GetComponent<AnimationHandler>();
    }

    // Update is called once per frame
    private void LateUpdate() {
        offset=new Vector3(0,1+player.transform.localScale.y/2,-2.9f);
        
        transform.position=player.transform.position + offset;
    }
}
