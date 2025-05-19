using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    private bool isGameOver = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void AddScore()
    {
        score++;
        UpdateScore();
        scoreText.text = score.ToString();

    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        RestartScore();
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        isGameOver = true;
    }
    public void RestartGame()
    {
        RestartScore();
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void RestartScore()
    {
        score = 0;
    }
    public void TakeDamage(int damge)
    {
        currentHealth -= damge;
        if (currentHealth <= 0)
        {
            GameOver();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);

    }
    public bool IsGameOver()
    {
        return isGameOver;
    }

}
