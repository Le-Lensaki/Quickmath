using UnityEngine;

public class MathController : MonoBehaviour
{
    protected static MathController instance;
    public static MathController Instance { get { return instance; } }

    [SerializeField] protected MathStatus status;
    public MathStatus Status { get { return status; } }

    [SerializeField] protected MathUI uI;
    public MathUI Action { get { return uI; } }

    private void Awake()
    {
        MathController.instance = this;
        this.status = GetComponent<MathStatus>();
        this.uI = GetComponent<MathUI>();
       
    }

    public void CreateMathGame()
    {
        uI.SetUIMath(status.CreateMath());
        ResultController.Instance.SetResult();
    }

    public int GetResultWin()
    {
        return status.CurrentResult;
    }

}
