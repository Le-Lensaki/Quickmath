
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    protected static ResultController controller;

    protected TMP_Text result1;
    protected TMP_Text result2;
    protected TMP_Text result3;
    protected TMP_Text result4;

    private void Awake()
    {
        controller = GetComponent<ResultController>();
        result1 = GameObject.Find("Result1").GetComponent<TMP_Text>();
        result2 = GameObject.Find("Result2").GetComponent<TMP_Text>();
        result3 = GameObject.Find("Result3").GetComponent<TMP_Text>();
        result4 = GameObject.Find("Result4").GetComponent<TMP_Text>();
        ClearUIResult();
    }

    public void SetUIResult(string rs1, string rs2, string rs3, string rs4)
    {
        result1.text = rs1;
        result2.text = rs2;
        result3.text = rs3;
        result4.text = rs4;
    }

    public void ClearUIResult()
    {
        result1.text = ""; 
        result2.text = "";
        result3.text = "";
        result4.text = "";
    }
}
