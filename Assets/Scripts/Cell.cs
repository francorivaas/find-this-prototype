using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image image;
    private bool isCorrect;
    private bool isClickable = true;

    public void Setup(Sprite sprite, bool correct)
    {
        image.sprite = sprite;
        isCorrect = correct;
        isClickable = true;
    }

    public void OnClick()
    {
        if (GameManager.Instance.IsGameOver()) return;
        if (!isClickable) return;

        isClickable = false;

        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            RoundManager.Instance.CorrectClick();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            GameManager.Instance.LoseLife();
        }
    }

}
