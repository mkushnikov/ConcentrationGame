using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Text _pairsLabel;

    public string ScoreLabel {set => _scoreLabel.text = value; }
    public string PairsLabel {set => _pairsLabel.text = value; }
}
