using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialogPanel;
    public GameObject menuPanel;
    public GameObject levelPanel;
    public GameObject optionPanel;
    public Text dialogText;
    public Button yesButton;
    public Button noButton;

    private System.Action onYesAction;

    void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void OnPlayButtonClicked()
    {
        ShowDialog("Bạn có muốn bắt đầu trò chơi không?", () =>
        {
            SceneManager.LoadScene("Level 1");
        });
    }

    public void OnQuitButtonClicked()
    {
        ShowDialog("Bạn có chắc chắn muốn thoát không?", () =>
        {
            Application.Quit();
        });
    }

    void ShowDialog(string message, System.Action yesAction)
    {
        dialogPanel.SetActive(true);
        menuPanel.SetActive(false);
        dialogText.text = message;
        onYesAction = yesAction;

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() =>
        {
            onYesAction?.Invoke();
            dialogPanel.SetActive(false);
        });

        noButton.onClick.AddListener(() =>
        {
            dialogPanel.SetActive(false);
            menuPanel.SetActive(true);
        });
    }
    public void OpenLevel()
    {
        levelPanel.SetActive(true);
        dialogPanel.SetActive(false);
        menuPanel.SetActive(false);
    }
    public void OpenSetting()
    {
        levelPanel.SetActive(false);
        dialogPanel.SetActive(false);
        menuPanel.SetActive(false);
        optionPanel.SetActive(true);
    }
    public void ClosSetting()
    {
        levelPanel.SetActive(false);
        dialogPanel.SetActive(false);
        menuPanel.SetActive(true);
        optionPanel.SetActive(false);
    }
}
