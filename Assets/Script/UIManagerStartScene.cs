
using UnityEngine;

public class UIManagerStartScene : MonoBehaviour
{
    protected static UIManagerStartScene instance;
    public static UIManagerStartScene Instance { get { return instance; } }

    protected GameObject btnPlay;
    protected GameObject btnRate;
    protected GameObject btnClassic;
    protected GameObject btnSurvival;
    protected GameObject term;

    private void Awake()
    {
        UIManagerStartScene.instance = this;
        SetBtn();
        HideBtnGamePlay();
        CheckTerm();
    }
    protected void SetBtn()
    {
        btnPlay = GameObject.Find("BtnPlay");
        btnRate = GameObject.Find("BtnRate");
        btnClassic = GameObject.Find("BtnClassic");
        btnSurvival = GameObject.Find("BtnSurvival");
        term = GameObject.Find("Terms");
    }

    public void CheckTerm()
    {
        if(GameManager.Instance.Player.accept) HideTerm();
        else term.SetActive(true);
    }
    public void HideTerm()
    {
        term.SetActive(false);
    }    

       



    public void HideBtnGamePlay()
    {
        btnClassic.SetActive(false);
        btnSurvival.SetActive(false);
    }
    public void ChooseStyle()
    {
        btnPlay.SetActive(false);
        btnRate.SetActive(false);
        btnClassic.SetActive(true);
        btnSurvival.SetActive(true);
    }
}
