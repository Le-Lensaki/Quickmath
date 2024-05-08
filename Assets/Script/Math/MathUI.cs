using TMPro;
using UnityEngine;

public class MathUI : MonoBehaviour
{
    protected static MathController controller;

    protected TMP_Text mathMain;

    private void Awake()
    {
        controller = GetComponent<MathController>();
        mathMain = GameObject.Find("TextMathMain").GetComponent<TMP_Text>();
    }

    public void SetUIMath(string math)
    {
        mathMain.text = math;
    }

    public void ClearUIMath()
    {
        mathMain.text = "";
    }
    
}
