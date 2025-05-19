using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    public Button button;
    // public GameObject lockIcon;

    void Start()
    {
        int unlocked = PlayerPrefs.GetInt("HighestLevelUnlocked", 1);
        if (levelIndex <= unlocked)
        {
            button.interactable = true;
            // lockIcon.SetActive(false);
        }
        else
        {
            button.interactable = false;
            // lockIcon.SetActive(true);
        }
    }

    // public void OnClick()
    // {
    //     FindObjectOfType<LevelManager>().LoadLevel(levelIndex);
    // }
}
