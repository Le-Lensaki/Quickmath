using UnityEngine;

public class MathStatus : MonoBehaviour
{
    protected static MathController controller;

    protected int currentResult = 0;
    public int CurrentResult { get { return currentResult; } }

    protected string currentMath;

    private void Awake()
    {
        controller = GetComponent<MathController>();
        ClearMath();
    }


    public string CreateMath()
    {
        string math = "";
        string calculation = "";
        int rd = Random.Range(1, 3);
        switch (rd)
        {
            case 1:
                calculation = "-";
                break;
            case 2:
                calculation = "+";
                break;
            

        }
        int a = Random.Range(1, 9999);
        int b = Random.Range(1, 9999);
        if (calculation == "-")
        {

            while (a < b)
            {
                a = Random.Range(1, 9999);
                b = Random.Range(1, 9999);
            }

        }
        math = a+" "+calculation+" "+b+" =";
        currentMath = math;
        if (calculation == "-")
            currentResult = a - b;
        else currentResult = a + b;
        
        

        return currentMath;
    }
    
    public void ClearMath()
    {
        currentMath = null;
        currentResult = 0;
    }
}
