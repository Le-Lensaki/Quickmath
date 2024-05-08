
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    protected static PlayerController controller;

    protected TMP_Text score;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        score = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    public void SetScore(string point)
    {
        score.text = point;
    }    

    public void ClearScore()
    {
        score.text = "0";
    }
}
