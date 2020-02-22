using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsClosingController : MonoBehaviour
{
    [SerializeField] private float _closingCountdown;

    private bool _isClosingCoroutineRunning = false;

    public void initCardsClosing(List<Transform> cards)
    {
        if (!_isClosingCoroutineRunning)
        {
            StartCoroutine(CloseOpenedCardsCoroutine(cards));
        }
    }

    IEnumerator CloseOpenedCardsCoroutine(List<Transform> cards)
    {
        _isClosingCoroutineRunning = true;

        GetComponent<Deck>().SetBlockerState(true);

        yield return new WaitForSeconds(_closingCountdown);

        foreach (Transform child in cards)
        {
            child.GetComponent<Card>().Close();
        }

        GetComponent<OpenedCardsCollector>().ClearOpenedCardsInfo();
        _isClosingCoroutineRunning = false;
        GetComponent<Deck>().SetBlockerState(false);
    }
}
