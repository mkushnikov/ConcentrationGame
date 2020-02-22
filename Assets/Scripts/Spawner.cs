using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnCards(GameObject cardPrefab, int count)
    {
        if (cardPrefab is null)
        {
            throw new System.ArgumentNullException(nameof(cardPrefab));
        }

        List<GameObject> cards = new List<GameObject>();
        Color faceColor = getNewColor();

        while (count > 0)
        {
            GameObject card = Instantiate(cardPrefab);

            if (count % 2 == 0)
            {
                faceColor = getNewColor();
            }

            card.GetComponent<Card>().setFace(faceColor);

            count--;

            cards.Add(card);
        }

        ShuffleCards(cards);

        foreach (GameObject card in cards)
        {
            card.transform.SetParent(transform, false);
        }

    }

    private void ShuffleCards(List<GameObject> cards)
    {
        int count = cards.Count;
        int last = count - 1;

        for (int i = 0; i < last; ++i)
        {
            int pos = Random.Range(i, count);
            GameObject temp = cards[i];
            cards[i] = cards[pos];
            cards[pos] = temp;
        }
    }
    private Color getNewColor()
    {
        return new Color
        {
            r = Random.Range(0f, 1f),
            g = Random.Range(0f, 1f),
            b = Random.Range(0f, 1f),
            a = 1
        };
    }
}
