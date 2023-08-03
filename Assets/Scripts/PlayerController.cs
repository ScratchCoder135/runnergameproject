using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private protected float speed=5f;
    private protected float xRange=2f;
    public bool isGameEnded;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] ParticleSystem explosionParticle;
    AudioSource playerAudio;
    [SerializeField] AudioClip explosionAudio;
    [SerializeField] AudioClip gateAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio=GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameEnded){
        KeepOnGround();
        Move();
       
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Gate")){
            BoxCollider collider=other.gameObject.GetComponent<BoxCollider>();
            collider.enabled=false;
            Gate gateScript=other.gameObject.GetComponent<Gate>();
            float add=gateScript.addValue/20;
            transform.localScale += new Vector3(0,add,0);
            playerAudio.PlayOneShot(gateAudio);
            
        }else if(other.gameObject.CompareTag("Finish")){
            isGameEnded=true;
            winScreen.SetActive(true);
            DataManager.instance.StoreLevelProgress(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void KeepOnGround(){
        transform.position=new Vector3(transform.position.x,0 + transform.localScale.y/2,transform.position.z);
        
    }
    public virtual void Move(){
        float horizontalInput;
        #if UNITY_EDITOR
        horizontalInput=Input.GetAxis("Mouse X Editor");
        #else
        horizontalInput=Input.GetAxis("Mouse X");
        #endif
        horizontalInput/=1175;
        horizontalInput*=Screen.width;
        if(!Input.GetMouseButton(0)){
            horizontalInput=0;
        }
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
            playerAudio.PlayOneShot(explosionAudio);
            Instantiate(explosionParticle,new Vector3(transform.position.x,0.5f,transform.position.z),explosionParticle.transform.rotation);
            explosionParticle.Play();
        }
    }
}
