
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    protected static PlayerController controller;

    [SerializeField] protected int score;
    public int Score { get { return score; } }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        score = 0;
    }

    public void PlusScore()
    {
        score++;
    }
    public void ClearScore()
    {
        score = 0;
    }
}
