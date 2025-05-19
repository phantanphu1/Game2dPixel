using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public int currentLevelIndex;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // CompleteLevel();
            LoadLevel(2);
        }
    }
    public void CompleteLevel()
    {
        int highestUnlocked = PlayerPrefs.GetInt("HighestLevelUnlocked", 1);
        if (currentLevelIndex >= highestUnlocked)
        {
            PlayerPrefs.SetInt("HighestLevelUnlocked", currentLevelIndex + 1);
        }
    }

    public void LoadLevel(int levelIndex)
    {
        int unlocked = PlayerPrefs.GetInt("HighestLevelUnlocked", 1);
        if (levelIndex <= unlocked)
        {
            SceneManager.LoadScene("Level " + levelIndex);
        }
        else
        {
            Debug.Log("Level chưa được mở!");
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("HighestLevelUnlocked");
    }
}
