using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text livesText;
    public Image targetImage;
    public Text remainingText;

    public void UpdateLives(int lives)
    {
        livesText.text = $"Vidas: {lives}";
    }

    public void SetTargetImage(Sprite sprite)
    {
        targetImage.sprite = sprite;
    }

    public void UpdateRemaining(int remaining)
    {
        remainingText.text = $"Faltan: {remaining}";
    }
}
