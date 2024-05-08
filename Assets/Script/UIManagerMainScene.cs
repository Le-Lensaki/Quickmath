using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerMainScene : MonoBehaviour
{
    protected static UIManagerMainScene instance;
    public static UIManagerMainScene Instance { get { return instance; } }

    protected GameObject btnResult1;
    protected GameObject btnResult2;
    protected GameObject btnResult3;
    protected GameObject btnResult4;
    protected GameObject mathMain;
    protected GameObject mathEqual;
    protected GameObject correct;
    protected GameObject inCorrect;

    protected GameObject chest1;
    public GameObject Chest1 { get { return chest1; } }
    protected GameObject chest2;
    public GameObject Chest2 { get { return chest2; } }

    protected GameObject countTime;
    protected GameObject loseGameWin;
    protected GameObject loseGameFail;
    protected GameObject btnSoundOff;
    protected GameObject btnPause;
    protected GameObject btnRe;

    [SerializeField] protected Sprite defaultResult;
    [SerializeField] protected Sprite correctResult;
    [SerializeField] protected Sprite incorrectResult;



    private void Awake()
    {
        UIManagerMainScene.instance = this;
        SetBtn();
        HideObject();
        HideLoseGame();
        HoverButtonSoundOff(GameManager.Instance.Player.volume);
    }

    protected void HideObject()
    {
        correct.SetActive(false);
        inCorrect.SetActive(false);
        chest1.SetActive(false);
        if(GameManager.Instance.Player.classicStyle)
        {
            countTime.SetActive(false);
        }    
    }
    protected void HideLoseGame()
    {
        loseGameWin.SetActive(false);
        loseGameFail.SetActive(false);
    }
    protected void HideBtnResult()
    {
        chest2.SetActive(false);
        btnResult1.SetActive(false);
        btnResult2.SetActive(false);
        btnResult3.SetActive(false);
        btnResult4.SetActive(false);
    }

    public void ChangeEnabledBtn()
    {
        if(btnResult1.GetComponent<Button>().enabled)
        {
            btnResult1.GetComponent<Button>().enabled = false;
            btnResult2.GetComponent<Button>().enabled = false;
            btnResult3.GetComponent<Button>().enabled = false;
            btnResult4.GetComponent<Button>().enabled = false;
            btnRe.GetComponent<Button>().enabled = false;
        }
        else
        {
            btnResult1.GetComponent<Button>().enabled = true;
            btnResult2.GetComponent<Button>().enabled = true;
            btnResult3.GetComponent<Button>().enabled = true;
            btnResult4.GetComponent<Button>().enabled = true;
            btnRe.GetComponent<Button>().enabled = true;
        }    
        
    }  

    protected void HideMainGame()
    {
        HideBtnResult();
        HideObject();
        mathMain.SetActive(false);
        countTime.SetActive(false);
    }
    protected void SetBtn()
    {
        btnResult1 = GameObject.Find("Math1");
        btnResult2 = GameObject.Find("Math2");
        btnResult3 = GameObject.Find("Math3");
        btnResult4 = GameObject.Find("Math4");
        mathMain = GameObject.Find("MathMain");
        mathEqual = GameObject.Find("MathEqual");
        correct = GameObject.Find("Correct");
        inCorrect = GameObject.Find("Incorrect");
        chest1 = GameObject.Find("Chest1");
        chest2 = GameObject.Find("Chest2");
        countTime = GameObject.Find("BackgroundTiming");
        loseGameWin = GameObject.Find("LoseGameWin");
        loseGameFail = GameObject.Find("LoseGameFail");
        btnSoundOff = GameObject.Find("BtnSoundOff");
        btnPause = GameObject.Find("BtnPause");
        btnRe = GameObject.Find("BtnRe");
    }

    public void HoverButtonSoundOff(float volume)
    {
        if(volume == 0) btnSoundOff.GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,1);
        else btnSoundOff.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
    public void HoverButtonPause()
    {
        if (Time.timeScale == 0) btnPause.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        else btnPause.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public string GetTextBtnResult(string btnResult)
    {
        string result = "";
        if(btnResult == "1")
        {
            result = btnResult1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            
            return result;
        }
        if (btnResult == "2")
        {
            result = btnResult2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            return result;
        }
        if (btnResult == "3")
        {
            result = btnResult3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            return result;
        }
        if (btnResult == "4")
        {
            result = btnResult4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            return result;
        }
        return result;
    }
    public void SetEqual(string result)
    {
        mathEqual.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = result;
        mathEqual.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
        mathEqual.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    public void ClearEqual()
    {
        mathEqual.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "?";
        mathEqual.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0.5f);
        mathEqual.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void CheckWin(bool win)
    {
        HideBtnResult();
        chest1.SetActive(true);
        if (win)
        {
            correct.SetActive(true);
        }
        else {
            inCorrect.SetActive(true);
        }
        
    }

    protected void SetBestScore(bool win)
    {
        int current = PlayerController.Instance.Status.Score;
        if(GameManager.Instance.Player.survivalStyle)
        {
            int best = GameManager.Instance.Player.bestScoreSurvival;
            if(win)
            {
                loseGameWin.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "SCORE  " + current.ToString();
                loseGameWin.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "BEST " + current.ToString();
                AudioManager.Instance.PlaySFX("Win");
            }
            else
            {
                loseGameFail.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "SCORE  " + current.ToString();
                loseGameFail.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "BEST " + best.ToString();
                AudioManager.Instance.PlaySFX("Fail");
            }    
            
        }else if(GameManager.Instance.Player.classicStyle)
        {
            int best = GameManager.Instance.Player.bestScoreClassic;
            
            if (win)
            {
                loseGameWin.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "SCORE  " + current.ToString();
                loseGameWin.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "BEST " + current.ToString();
                AudioManager.Instance.PlaySFX("Win");
            }
            else
            {
                loseGameFail.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "SCORE  " + current.ToString();
                loseGameFail.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "BEST " + best.ToString();
                AudioManager.Instance.PlaySFX("Fail");
            }
        }    
        

    }
    public void SetTiming(string time)
    {
        countTime.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = time;
    }


    public void NewMath()
    {
        chest2.SetActive(true);
        btnResult1.SetActive(true);
        btnResult2.SetActive(true);
        btnResult3.SetActive(true);
        btnResult4.SetActive(true);
        ResetBtnResult();
        countTime.SetActive(true);
        mathMain.SetActive(true);
        ClearEqual();
        HideObject();
        loseGameWin.SetActive(false);
        loseGameFail.SetActive(false);
    }
    
    public void LoseGame(bool result)
    {
        if(result)
        {
            HideMainGame();
            loseGameWin.SetActive(true);
            SetBestScore(result);
        }
        else
        {
            HideMainGame();
            loseGameFail.SetActive(true);
            SetBestScore(result);
        }

    }

    protected void CheckCorrect(string result)
    {
        if(result == GetTextBtnResult("1"))
        {
            btnResult1.GetComponent<Image>().sprite = correctResult;
        }
        if (result == GetTextBtnResult("2"))
        {
            btnResult2.GetComponent<Image>().sprite = correctResult;
        }
        if (result == GetTextBtnResult("3"))
        {
            btnResult3.GetComponent<Image>().sprite = correctResult;
        }
        if (result == GetTextBtnResult("4"))
        {
            btnResult4.GetComponent<Image>().sprite = correctResult;
        }
    }    


    protected void ResetBtnResult()
    {
        btnResult1.GetComponent<Image>().sprite = defaultResult;
        btnResult2.GetComponent<Image>().sprite = defaultResult;
        btnResult3.GetComponent<Image>().sprite = defaultResult;
        btnResult4.GetComponent<Image>().sprite = defaultResult;
    }
    public void SwapCorrect(string buttonChoose, bool correct,string result)
    {
        if (correct)
        {
            switch (buttonChoose)
            {
                case "1":
                    btnResult1.GetComponent<Image>().sprite = correctResult;
                    break;
                case "2":
                    btnResult2.GetComponent<Image>().sprite = correctResult;
                    break;
                case "3":
                    btnResult3.GetComponent<Image>().sprite = correctResult;
                    break;
                case "4":
                    btnResult4.GetComponent<Image>().sprite = correctResult;
                    break;
            }
        }
        else
        {
            switch (buttonChoose)
            {
                case "1":
                    btnResult1.GetComponent<Image>().sprite = incorrectResult;
                    CheckCorrect(result);
                    break;
                case "2":
                    btnResult2.GetComponent<Image>().sprite = incorrectResult;
                    CheckCorrect(result);
                    break;
                case "3":
                    btnResult3.GetComponent<Image>().sprite = incorrectResult;
                    CheckCorrect(result);
                    break;
                case "4":
                    btnResult4.GetComponent<Image>().sprite = incorrectResult;
                    CheckCorrect(result);
                    break;
            }
        }

       
    }    

}
