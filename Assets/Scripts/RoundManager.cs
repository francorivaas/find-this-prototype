using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;

    public GridManager gridManager;
    public UIManager uiManager;
    public Sprite[] targetSprites;
    public int currentRound = 0;
    public int correctItemsPerRound = 5;

    private Sprite currentTarget;
    private int foundCorrect = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartFirstRound()
    {
        currentRound = 0;
        StartRound();
    }

    public void NextRound()
    {
        currentRound++;
        StartRound();
    }

    void StartRound()
    {
        foundCorrect = 0;
        currentTarget = targetSprites[Random.Range(0, targetSprites.Length)];

        uiManager.SetTargetImage(currentTarget);

        // ✅ mostrar "faltan X" desde el inicio
        uiManager.UpdateRemaining(correctItemsPerRound);

        gridManager.GenerateGrid(currentTarget, correctItemsPerRound);
    }

    public void CorrectClick()
    {
        foundCorrect++;
        uiManager.UpdateRemaining(correctItemsPerRound - foundCorrect);

        if (foundCorrect >= correctItemsPerRound)
        {
            GameManager.Instance.WinRound();
        }
    }
}
