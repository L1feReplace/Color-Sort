using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    private const int InitialLevelIndex = 2;

    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.HasKey("levelAt") ? PlayerPrefs.GetInt("levelAt") : InitialLevelIndex;

        int levelCount = lvlButtons.Length;

        // Отключаем кнопки уровней, которые не достигнуты игроком
        for (int i = 0; i < levelCount; i++)
        {
            if (i + InitialLevelIndex > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
}
