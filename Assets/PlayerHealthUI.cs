using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        if (playerStats == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < playerStats.currentHealth ? fullHeart : emptyHeart;
            hearts[i].enabled = i < playerStats.maxHealth;
        }
    }
}
