using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private int _deckSize;

    public int PairsCount { get; set; }


    private void Awake()
    {
        GetComponent<Spawner>().SpawnCards(_cardPrefab, _deckSize);
        PairsCount = _deckSize / 2;
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

    public void SetBlockerState(bool state)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = !state;
    }

    IEnumerator DisableGridLayout()
    {
        yield return new WaitForEndOfFrame();

        GetComponent<GridLayoutGroup>().enabled = false;
    }
}

