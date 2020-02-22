using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDisappearController : MonoBehaviour
{
    [SerializeField] private float _disapperCountdown;

    private bool _isDisappearCoroutineRunning = false;

    public void initCardsDisappering(List<Transform> cards)
    {
        if (!_isDisappearCoroutineRunning)
        {
            StartCoroutine(DisappearCardsCoroutine(cards));
        }
    }

    IEnumerator DisappearCardsCoroutine(List<Transform> cards)
    {
        _isDisappearCoroutineRunning = true;

        GetComponent<Deck>().SetBlockerState(true);

        yield return new WaitForSeconds(_disapperCountdown);

        foreach (Transform child in cards)
        {
            child.GetComponent<Card>().cardDisappearing();
        }

        GetComponent<OpenedCardsCollector>().ClearOpenedCardsInfo();
        GetComponent<Deck>().PairsCount--;
        _isDisappearCoroutineRunning = false;
        GetComponent<Deck>().SetBlockerState(false);
    }

}
