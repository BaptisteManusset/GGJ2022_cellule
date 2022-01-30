using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    private TMP_Text text;

    private void OnEnable() {
        text = GetComponent<TMP_Text>();

        text.text = $"You have acquired {Manager.Instance.Score} DNA";
    }
}