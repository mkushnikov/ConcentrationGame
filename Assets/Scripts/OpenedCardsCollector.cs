using System.Collections.Generic;
using UnityEngine;

public class OpenedCardsCollector : MonoBehaviour
{
    private List<Transform> _openedCards = new List<Transform>();
    private int OpenedCardsCount = 0;

    public void OnCardOpen(Transform card)
    {
        _openedCards.Add(card);
        OpenedCardsCount++;

        if (OpenedCardsCount == 2)
        {
            Transform[] cardsArray = _openedCards.ToArray();

            if (cardsArray[0].GetComponent<Card>().getFaceSlotvalue() == cardsArray[1].GetComponent<Card>().getFaceSlotvalue())
            {
                GetComponent<CardsDisappearController>().initCardsDisappering(_openedCards);
            }
            else
            {
                GetComponent<CardsClosingController>().initCardsClosing(_openedCards);
            }
        }
    }

    public void ClearOpenedCardsInfo()
    {
        _openedCards.Clear();
        OpenedCardsCount = 0;
    }
}
