using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    private const int LastLevelIndex = 7;
    public int nextSceneLoad;

    public void NextLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        nextSceneLoad = activeSceneIndex + 1;

        if (activeSceneIndex == LastLevelIndex)
        {
            Debug.Log("You Completed ALL Levels");
        }
        else
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
}
