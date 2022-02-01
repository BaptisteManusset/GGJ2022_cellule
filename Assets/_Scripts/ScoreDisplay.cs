using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    private TMP_Text _text;

    private void OnEnable() {
        _text = GetComponent<TMP_Text>();

        _text.text =
            @$"You have acquired
<size=200%>{Manager.Instance.Score} DNA</size>";
    }
}