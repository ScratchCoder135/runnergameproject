using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int levelTotal;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null){
            Destroy(gameObject);
        }
        instance=this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class DataStructure{
        public int level;
    }
    public void StoreLevelProgress(int level){
        DataStructure data=new DataStructure();
        data.level=level;
        string json=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/storage.json",json);

    }
    public int LoadLevelProgress(){
        string path=Application.persistentDataPath + "/storage.json";
        if(File.Exists(path)){
        string json=File.ReadAllText(path);
        DataStructure data=JsonUtility.FromJson<DataStructure>(json);
        if(data.level >= levelTotal){
            return 0;
        }else{
        return data.level;
        }
        }else{
            return 0;
        }
    }
}
