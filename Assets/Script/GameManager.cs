using System.Collections;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] protected GameSO player;
    public GameSO Player { get { return player; } }

    private void Awake()
    {
        GameManager.instance = this;
        player.Initialize();
        GetData();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("AcceptTerms", player.accept ? 1 : 0);
        PlayerPrefs.SetInt("BestScoreClassic", player.bestScoreClassic);
        PlayerPrefs.SetInt("BestScoreSurvival", player.bestScoreSurvival);
        PlayerPrefs.SetFloat("Volume", player.volume);
    }
    public void GetData()
    {
        int accept = PlayerPrefs.GetInt("AcceptTerms");
        if (accept == 1) player.accept = true;
        else player.accept = false;

        if (player.accept)
        {
            player.volume = PlayerPrefs.GetFloat("Volume");
        }
        player.bestScoreClassic = PlayerPrefs.GetInt("BestScoreClassic");
        player.bestScoreSurvival = PlayerPrefs.GetInt("BestScoreSurvival");
       
    }
    IEnumerator LoadSceneMainGame()
    {
        yield return new WaitForSeconds(0.5f);
        Save();
        OpenScene("MainScene");
    }

    IEnumerator LoadSceneStart()
    {
        yield return new WaitForSeconds(0.5f);
        Save();
        OpenScene("Start");
    }


    public void ChooseStyle()
    {
        AudioManager.Instance.PlaySFX("Click");
        UIManagerStartScene.Instance.ChooseStyle();
    }

    void OnApplicationQuit()
    {
        Save();
    }    



    public void ChooseStyleClassic()
    {
        AudioManager.Instance.PlaySFX("Click");
        StartCoroutine(LoadSceneMainGame());
        
        player.classicStyle = true;
        player.survivalStyle = false;
        
    }
    public void ChooseStyleSurvival()
    {
        AudioManager.Instance.PlaySFX("Click");
        StartCoroutine(LoadSceneMainGame());
        player.classicStyle = false;
        player.survivalStyle = true;
    }

    public void BackMenu()
    {
        AudioManager.Instance.PlaySFX("Click");
        StartCoroutine(LoadSceneStart());

    }
    public void BtnPause()
    {
        AudioManager.Instance.PlaySFX("Click");
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            UIManagerMainScene.Instance.ChangeEnabledBtn();
            UIManagerMainScene.Instance.HoverButtonPause();
        }
        else
        {
            Time.timeScale = 1;
            UIManagerMainScene.Instance.ChangeEnabledBtn();
            UIManagerMainScene.Instance.HoverButtonPause();
        }
    }
    public void BtnSoundOff()
    {
        AudioManager.Instance.PlaySFX("Click");
        if (player.volume != 0) player.volume = 0;
        else player.volume = 0.5f;
        UIManagerMainScene.Instance.HoverButtonSoundOff(player.volume);
       
    }
    public void BtnAccept()
    {
        AudioManager.Instance.PlaySFX("Click");
        Player.accept = true;
        UIManagerStartScene.Instance.HideTerm();
    }

    public void BtnRe()
    {
        AudioManager.Instance.PlaySFX("Click");
        PlayerController.Instance.StartGame();
    }
    public void BtnReplay()
    {
        AudioManager.Instance.PlaySFX("Click");
        UIManagerMainScene.Instance.NewMath();
        PlayerController.Instance.StartGame();
    }
    public bool UpdateBestSCore(int newScore)
    {
        if(Player.classicStyle)
        {
            if (newScore > Player.bestScoreClassic)
            {
                Player.bestScoreClassic = newScore;
                return true;
            }
            else
            {
                return false;
            }
        }else if(Player.survivalStyle)
        {
            if(newScore > Player.bestScoreSurvival)
            {
                Player.bestScoreSurvival = newScore;
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    public static void OpenScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
