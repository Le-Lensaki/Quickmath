
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    protected static ResultController instance;
    public static ResultController Instance { get { return instance; } }

    [SerializeField] protected ResultStatus status;
    public ResultStatus Status { get { return status; } }

    [SerializeField] protected ResultUI uI;
    public ResultUI Action { get { return uI; } }

    private void Awake()
    {
        ResultController.instance = this;
        this.status = GetComponent<ResultStatus>();
        this.uI = GetComponent<ResultUI>();
    }


    public void SetResult()
    {
        List<string> listResult = status.RandomResult(MathController.Instance.GetResultWin().ToString());
        
        string a = listResult[Random.Range(0, 4)];
        listResult.Remove(a);
        string b = listResult[Random.Range(0, 3)];
        listResult.Remove(b);
        string c = listResult[Random.Range(0, 2)];
        listResult.Remove(c);
        string d = listResult[Random.Range(0, 1)];

        

        uI.SetUIResult(a, b, c, d);
        

    }
}
