using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelsButtons;
    private void Awake()
    {
        ButtonstoArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i=0;i<buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenLevel(int level)
    {
        string LevelName = "Level " + level;
        SceneManager.LoadScene(LevelName);
    } 
    void ButtonstoArray()
    {
        int childCount = levelsButtons.transform.childCount;
        buttons = new Button[childCount];
        for(int i=0; i < childCount; i++)
        {
            buttons[i] = levelsButtons.transform.GetChild(i).GetComponent<Button>();
        }
    }
        
}
