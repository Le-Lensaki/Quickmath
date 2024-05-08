using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class GameSO : ScriptableObject
{
    [SerializeField] public bool classicStyle;
    [SerializeField] public bool survivalStyle;
    [SerializeField] public bool accept;
    [SerializeField] public int bestScoreClassic;
    [SerializeField] public int bestScoreSurvival;
    [SerializeField] public float volume;


    public void Initialize()
    {
        accept = false;
        bestScoreSurvival = 0;
        bestScoreClassic = 0;
        volume = 0.5f;
    }    
}
