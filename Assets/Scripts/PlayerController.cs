using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed=5f;
    private float xRange=2f;
    public bool isGameEnded;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameEnded){
        transform.position=new Vector3(transform.position.x,0 + transform.localScale.y/2,transform.position.z);
        float horizontalInput=Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.x > xRange){
            transform.position=new Vector3(xRange,transform.position.y,transform.position.z);
        }
                if(transform.position.x < -xRange){
            transform.position=new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
                if(transform.localScale.y <1){
            isGameEnded=true;
            gameOverScreen.SetActive(true);
            explosionParticle.Play();
        }
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Gate")){
            BoxCollider collider=other.gameObject.GetComponent<BoxCollider>();
            collider.enabled=false;
            Gate gateScript=other.gameObject.GetComponent<Gate>();
            float add=gateScript.addValue/20;
            transform.localScale += new Vector3(0,add,0);
            
        }else if(other.gameObject.CompareTag("Finish")){
            isGameEnded=true;
            winScreen.SetActive(true);
        }
    }
}
