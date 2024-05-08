using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    protected static ChestController instance;
    public static ChestController Instance { get { return instance; } }

    [SerializeField] protected ChestUI uI;
    public ChestUI UI { get { return uI; } }

    private void Awake()
    {
        ChestController.instance = this;
        this.uI = GetComponent<ChestUI>();
    }


    public void Open()
    {
        uI.OpenChest();
    }

    public void Close()
    {
        uI.CloseChest();
        Debug.Log("Close");
    }

}
