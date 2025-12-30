using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameUIManager : MonoBehaviour
{
    [Header("Hearts")]
    public Image[] hearts;

    [Header("Score")]
    public TextMeshProUGUI scoreText;

    private int currentHearts = 3;
    private int currentScore = 0;

    void Start()
    {
        UpdateHeartsDisplay();
        UpdateScoreDisplay();
    }

    public void RemoveHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            UpdateHeartsDisplay();

            if (currentHearts <= 0)
            {
                Debug.Log("Game Over! No hearts left!");
                // game over logic
            }
        }
    }

    public void AddHeart()
    {
        if (currentHearts < hearts.Length)
        {
            currentHearts++;
            UpdateHeartsDisplay();
        }
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreDisplay();
    }

    private void UpdateHeartsDisplay()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].enabled = true;
                Color c = hearts[i].color;
                c.a = 1;
                hearts[i].color = c;
            }
            else
            {
                StartCoroutine(SmoothHeartOpacityReduction(i));
            }
        }
    }

    IEnumerator SmoothHeartOpacityReduction(int index)
    {
        Color c = hearts[index].color;
        float time = 0f;
        float duration = 0.3f;

        while (time < duration)
        {
            time += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, time / duration);
            hearts[index].color = c;
            yield return null;
        }
        
        hearts[index].enabled = false;
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + currentScore;
    }
}