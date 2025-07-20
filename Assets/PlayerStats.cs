using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public int maxMana = 50;
    public int currentMana;

    public Text gameOverText;
    public float restartDelay = 5f;

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


    private void Die()
    {
        if (isDead) return;
        isDead = true;

        if (gameOverText != null)
        {
            gameOverText.enabled = true;
            gameOverText.text = "GAME OVER";
        }

        Time.timeScale = 0f;
        StartCoroutine(RestartAfterDelayRealtime());
    }

    private IEnumerator RestartAfterDelayRealtime()
    {
        float timer = 0f;
        while (timer < restartDelay)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;
        currentMana = Mathf.Max(currentMana, 0);
    }



    public void RestoreMana(int amount)
    {
        currentMana += amount;
        currentMana = Mathf.Min(currentMana, maxMana);
    }

}
