using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalLives = 3;
    private int currentLives;

    public RoundManager roundManager;
    public UIManager uiManager;

    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentLives = totalLives;
        uiManager.UpdateLives(currentLives);
        roundManager.StartFirstRound();
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void LoseLife()
    {
        if (isGameOver) return; // ✅ no seguir restando si ya perdió

        currentLives--;
        if (currentLives < 0) currentLives = 0; // ✅ clamp a 0

        uiManager.UpdateLives(currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
        // TODO: mostrar UI derrota y bloquear input global si querés
    }

    public void WinRound()
    {
        if (isGameOver) return;
        roundManager.NextRound();
    }
}
