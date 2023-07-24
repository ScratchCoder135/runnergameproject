using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : CameraBehavior
{

    
    // Start is called before the first frame update
    void Start()
    {
        playerScript=player.GetComponent<AnimationHandler>();
    }

    // Update is called once per frame
    private void LateUpdate() {
        FollowPlayer();
    }
}
