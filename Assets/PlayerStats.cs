using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public int maxMana = 3;
    public int currentMana;

    public Text gameOverText;
    public float restartDelay = 3f;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        if (gameOverText != null)
            gameOverText.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void RestoreHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void UseMana(int amount)
    {
        currentMana = Mathf.Max(currentMana - amount, 0);
    }

    public void RestoreMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Gracz umar³");

        if (gameOverText != null)
        {
            gameOverText.enabled = true;
            gameOverText.text = "GAME OVER";
        }

        Invoke("RestartScene", restartDelay);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
