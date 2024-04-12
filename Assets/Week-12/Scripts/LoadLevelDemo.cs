using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelDemo : MonoBehaviour
{
    public string levelToLoadName;
    public int levelToLoadIndex;
    public bool loadLevelByName;

    // Start is called before the first frame update
    void Start()
    {
        if (loadLevelByName)
        {
            // loads by name
            SceneManager.LoadScene(levelToLoadName);
        }
        else
        {
            // loads by index
            SceneManager.LoadScene(levelToLoadIndex);
        }
    }
}
