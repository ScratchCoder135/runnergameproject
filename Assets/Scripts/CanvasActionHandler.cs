using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CanvasActionHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    void Start(){
        buttonText.text="Start Level "+(DataManager.instance.LoadLevelProgress()+1).ToString();
    }
public void WatchPreview(){
    Application.OpenURL("https://www.youtube.com/watch?v=jcWV29hsuVQ");
}
public void StartNewestLevel(){
    int level=DataManager.instance.LoadLevelProgress();
    SceneManager.LoadScene(level +1 );
}
}
