using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public int rows = 5;
    public int cols = 5;
    public Sprite[] gridSprites;

    [HideInInspector] public Cell[] allCells;

    public void GenerateGrid(Sprite targetSprite, int correctAmount)
    {
        ClearGrid();

        int totalCells = rows * cols;
        allCells = new Cell[totalCells];

        // ✅ Elegimos índices aleatorios donde van a ir los correctos
        HashSet<int> correctIndexes = new HashSet<int>();
        while (correctIndexes.Count < correctAmount)
        {
            correctIndexes.Add(Random.Range(0, totalCells));
        }

        for (int i = 0; i < totalCells; i++)
        {
            GameObject newCell = Instantiate(cellPrefab, transform);
            Cell cell = newCell.GetComponent<Cell>();

            bool isCorrect = correctIndexes.Contains(i);
            Sprite sprite = isCorrect ? targetSprite : GetRandomSpriteExcluding(targetSprite);

            cell.Setup(sprite, isCorrect);
            allCells[i] = cell;
        }
    }

    void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    Sprite GetRandomSpriteExcluding(Sprite exclude)
    {
        Sprite random;
        do
        {
            random = gridSprites[Random.Range(0, gridSprites.Length)];
        } while (random == exclude);

        return random;
    }
}
