using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OpenedCardsCollector))]
[RequireComponent(typeof(OpenedCardsHandler))]
public class Deck : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private int _deckSize;

    [SerializeField] private GameObject _ui;

    public int PairsCount { get; set; }
    public int GameScore { get; set; }

    private void Awake()
    {
        GetComponent<Spawner>().SpawnCards(_cardPrefab, _deckSize);
        UpdatePairsCount(_deckSize / 2);
        UpdateGameScore(0);
    }

    private void Start()
    {
        StartCoroutine(DisableGridLayout());
    }

    private void Update()
    {
        if (PairsCount == 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("All pairs found!!!");
#else
            Application.Quit();
#endif
        }
    }

    private IEnumerator DisableGridLayout()
    {
        yield return new WaitForEndOfFrame();

        GetComponent<GridLayoutGroup>().enabled = false;
    }

    public void SetBlockerState(bool state)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = !state;
    }


    public void UpdatePairsCount(int value)
    {
        PairsCount += value;

        _ui.GetComponent<UI>().PairsLabel = PairsCount.ToString();
    }

    public void UpdateGameScore(int value)
    {
        GameScore += value;

        _ui.GetComponent<UI>().ScoreLabel = GameScore.ToString();
    }
}

