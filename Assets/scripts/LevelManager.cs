using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        //unlock the current level for selection
        UnlockLevel(SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
    public void QuitApp()
    {
        Application.Quit();
    }

    public void LoadLevels()
    {
        foreach (LevelInfo level in FindObjectsOfType<LevelInfo>())
        {
            if (PlayerPrefs.GetInt(level.LevelName) == 1)
            {
                {
                    level.locked = true;
                }
            }
            else
            {
                level.locked = false;
            }

        }
    }
    public void UnlockLevel(string level)
    {
        PlayerPrefs.SetInt(level, 1);
    }
}
