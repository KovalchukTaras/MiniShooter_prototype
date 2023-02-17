using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            if (_score == value) return;

            _score = value;

            GetComponent<Text>().text = _score.ToString();
        }
    }

    public static ScoreCounter Instance { get; private set; }
    private void Awake() => Instance = this;
}