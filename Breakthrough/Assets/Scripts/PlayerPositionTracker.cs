using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionTracker : MonoBehaviour
{

    private List<(Vector2 position, float duration)> positions = new List<(Vector2, float)>();
    private Vector2 lastPosition;
    private float timeInCurrentPosition;

    void Start()
    {
        lastPosition = transform.position;
        timeInCurrentPosition = 0f;
    }

    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

        if (currentPosition != lastPosition)
        {
            if (positions.Count == 0 || positions[positions.Count - 1].position != lastPosition)
            {
                if (timeInCurrentPosition > 0f)
                {
                    positions.Add((lastPosition, timeInCurrentPosition));
                }
            }

            lastPosition = currentPosition;
            timeInCurrentPosition = 0f;

        }
        else
        {
            timeInCurrentPosition += Time.deltaTime;
        }

        // Tak pobieramy dane o pozycjach
        //var testPrp = GetLastPosition();
        //Debug.Log(getPositionsListCount() + $" Last Position: {testPrp.position}, Duration: {testPrp.duration} seconds");

    }

    public (Vector2 position, float duration) GetLastPosition()
    {
        if (positions.Count > 0)
        {
            return positions[positions.Count - 1];
        }
        return (Vector2.zero, 0f);
    }

    public (Vector2 position, float duration) GetPositionAt(int index)
    {
        if (index >= 0 && index < positions.Count)
        {
            return positions[index];
        }
        else
        {
            Debug.LogWarning("Przekroczono zakres zapisanej tablicy pozycji");
            return (Vector2.zero, 0f);
        }
    }

    public int getPositionsListCount()
    {
        return positions.Count;
    }

    public List<(Vector2 position, float duration)> getPositionsList()
    {
        return positions;
    }
}
