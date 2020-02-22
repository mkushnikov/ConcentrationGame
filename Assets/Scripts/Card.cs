using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameObject _backSide;
    [SerializeField] private GameObject _frontSide;

    public bool IsTurned => _frontSide.activeSelf;

    public void setFace(Color color)
    {
        _frontSide.GetComponent<Image>().color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsTurned)
        {
            Open();
        }
    }

    public void Open()
    {
        GetComponentInParent<OpenedCardsCollector>().OnCardOpen(transform);
        _frontSide.SetActive(true);
    }
    public void Close()
    {
        _frontSide.SetActive(false);
    }

    public Color getFaceSlotvalue()
    {
        return _frontSide.GetComponent<Image>().color;
    }

    public void cardDisappearing()
    {
        gameObject.SetActive(false);
    }
}
