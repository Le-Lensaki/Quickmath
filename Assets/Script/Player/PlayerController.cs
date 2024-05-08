using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

    protected PlayerStatus status;
    public PlayerStatus Status { get { return status; } }

    protected PlayerUI uI;
    public PlayerUI UI { get { return uI; } }

    protected float timeLeft = 10f;
    protected bool stopCount = false;
    
    private void Awake()
    {
        PlayerController.instance = this;
        this.status = GetComponent<PlayerStatus>();
        this.uI = GetComponent<PlayerUI>();
    }

    IEnumerator CoroutineNewMath()
    {
        stopCount = true;
        yield return new WaitForSeconds(2);
        UIManagerMainScene.Instance.Chest2.GetComponent<ChestController>().Close();
        NewMath();
    }

    IEnumerator CoroutineLoseGame()
    {
        stopCount = true;
        yield return new WaitForSeconds(2);
        UIManagerMainScene.Instance.LoseGame(GameManager.Instance.UpdateBestSCore(status.Score));
    }


    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        status.ClearScore();
        uI.ClearScore();
        MathController.Instance.CreateMathGame();
        timeLeft = 10f;
        stopCount = false;
    }

    public void NewMath()
    {
        MathController.Instance.CreateMathGame();
        UIManagerMainScene.Instance.ClearEqual();
        UIManagerMainScene.Instance.NewMath();
        stopCount = false;
    }    

    public void LoseGame()
    {

    }    



    private void Update()
    {
        uI.SetScore(status.Score.ToString());
        if (!stopCount && GameManager.Instance.Player.survivalStyle)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                StartCoroutine(CoroutineLoseGame());
            }
            else
            {
                UIManagerMainScene.Instance.SetTiming(timeLeft.ToString());
            }
        }
    }

    public void ChoseResult1()
    {
        AudioManager.Instance.PlaySFX("Click");
        string btnResult = UIManagerMainScene.Instance.GetTextBtnResult("1");
        AudioManager.Instance.PlaySFX("Click");
        if(btnResult == MathController.Instance.Status.CurrentResult.ToString())
        {
            status.PlusScore();
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("1", true, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                timeLeft = 10f;
                UIManagerMainScene.Instance.Chest2.GetComponent<ChestController>().Open();
            }
            else if(GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(true);
                UIManagerMainScene.Instance.Chest1.GetComponent<ChestController>().Open();
            }
           
            StartCoroutine(CoroutineNewMath());
        }
        else
        {
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("1", false, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
            }
            else if (GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(false);
            }
            StartCoroutine(CoroutineLoseGame());
        }

        

    }
    public void ChoseResult2()
    {
        AudioManager.Instance.PlaySFX("Click");
        string btnResult = UIManagerMainScene.Instance.GetTextBtnResult("2");
        if (btnResult == MathController.Instance.Status.CurrentResult.ToString())
        {
            status.PlusScore();
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("2", true, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                timeLeft = 10f;
                UIManagerMainScene.Instance.Chest2.GetComponent<ChestController>().Open();
            }
            else if (GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(true);
                UIManagerMainScene.Instance.Chest1.GetComponent<ChestController>().Open();
            }
            
            StartCoroutine(CoroutineNewMath());
        }
        else
        {
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("2", false, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
            }
            else if (GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(false);
            }
            StartCoroutine(CoroutineLoseGame());
        }
        
    }
    public void ChoseResult3()
    {
        AudioManager.Instance.PlaySFX("Click");
        string btnResult = UIManagerMainScene.Instance.GetTextBtnResult("3");
        if (btnResult == MathController.Instance.GetResultWin().ToString())
        {
            status.PlusScore();
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("3", true, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                timeLeft = 10f;
                UIManagerMainScene.Instance.Chest2.GetComponent<ChestController>().Open();
            }
            else if (GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(true);
                UIManagerMainScene.Instance.Chest1.GetComponent<ChestController>().Open();
            }
            
            StartCoroutine(CoroutineNewMath());
        }
        else
        {
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("3", false, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
            }
            else if (GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(false);
            }
            StartCoroutine(CoroutineLoseGame());
        }
        
    }
    public void ChoseResult4()
    {
        AudioManager.Instance.PlaySFX("Click");
        string btnResult = UIManagerMainScene.Instance.GetTextBtnResult("4");
        if (btnResult == MathController.Instance.Status.CurrentResult.ToString())
        {
            status.PlusScore();
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("4", true, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                timeLeft = 10f;
                UIManagerMainScene.Instance.Chest2.GetComponent<ChestController>().Open();
            }
            else if (GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(true);
                UIManagerMainScene.Instance.Chest1.GetComponent<ChestController>().Open();
            }
            
            StartCoroutine(CoroutineNewMath());
        }
        else
        {
            if (GameManager.Instance.Player.survivalStyle)
            {
                UIManagerMainScene.Instance.SwapCorrect("4", false, MathController.Instance.Status.CurrentResult.ToString());
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
            }
            else if (GameManager.Instance.Player.classicStyle)
            {
                UIManagerMainScene.Instance.SetEqual(MathController.Instance.GetResultWin().ToString());
                UIManagerMainScene.Instance.CheckWin(false);
            }
            StartCoroutine(CoroutineLoseGame());
        }

        
    }

}
