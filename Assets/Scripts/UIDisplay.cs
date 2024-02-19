using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] GameObject slider;
    [SerializeField] GameObject scoreText;
   [SerializeField] Health health;
    ScoreKeeper scoreKeeper;

    void Start() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Update() {
          slider.GetComponent<Slider>().value = health.GetHealth();
          scoreText.GetComponent<TextMeshProUGUI>().text = scoreKeeper.GetScore().ToString("000000000");
    }
}
