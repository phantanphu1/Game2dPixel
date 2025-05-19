using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameManager.AddScore();
            AudioManager.instance.HandleCoinAudio();

        }
        else if (other.CompareTag("DeathZone"))
        {
            gameManager.GameOver();
        }
        else if (other.CompareTag("Enemy"))
        {
            gameManager.TakeDamage(10);
        }
    }

}
