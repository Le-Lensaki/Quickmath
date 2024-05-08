
using System.Collections.Generic;
using UnityEngine;

public class ResultStatus : MonoBehaviour
{
    protected static ResultController controller;

    private void Awake()
    {
        controller = GetComponent<ResultController>();
    }

    public List<string> RandomResult(string currentResult)
    {
        List<string> results = new List<string>();
        int current = int.Parse(currentResult);
        int resultfake1 = 0;
        int resultfake2 = 0;
        int resultfake3 = 0;
        if (current < 100)
        {
            resultfake1 = current - 10;
            resultfake2 = current - 1 * (Random.Range(1, 9));
            resultfake3 = current - 1;
        }
        else if (current < 1000)
        {

            resultfake1 = current - 100;
            resultfake2 = current - 10 * (Random.Range(1, 9));
            resultfake3 = current - 1 * (Random.Range(1, 9));
        }else if (current < 10000)
        {
            resultfake1 = current - 100*(Random.Range(1, 9));
            resultfake2 = current - 10 * (Random.Range(1, 9));
            resultfake3 = current - 1 * (Random.Range(1, 9));
        }else if (current < 100000)
        {
            resultfake1 = current - 1000 * (Random.Range(1, 9));
            resultfake2 = current - 100 * (Random.Range(1, 9));
            resultfake3 = current - 10 * (Random.Range(1, 9));
        }

        results.Add(current.ToString());
        results.Add(resultfake1.ToString());
        results.Add(resultfake2.ToString());
        results.Add(resultfake3.ToString());
        return results;
    }


}
