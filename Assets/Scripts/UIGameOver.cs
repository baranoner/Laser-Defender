using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField]TextMeshProUGUI scoreTitle;

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start() {
        scoreTitle.text = "You Scored:\n" + scoreKeeper.GetScore();
    }
   
}
