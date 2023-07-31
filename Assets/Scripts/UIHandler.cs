using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviour
{
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevelLoader(){
        if(SceneManager.GetActiveScene().buildIndex==DataManager.instance.levelTotal){
            DataManager.instance.StoreLevelProgress(0);
            SceneManager.LoadScene(0);
            
        }else{
        SceneManager.LoadScene(DataManager.instance.LoadLevelProgress()+1);
        //This Code is to ensure that the json file can get the correct level index.
        }
    }
}
