using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
    protected static ChestController controller;

    
    private void Awake()
    {
        controller = GetComponent<ChestController>();
    }


    public void OpenChest()
    {
        this.GetComponent<Animator>().SetBool("Open", true);
        this.GetComponent<Animator>().SetBool("Close", false);
    }

    public void IdleOpenChest()
    {
        this.GetComponent<Animator>().SetBool("Open", false);
        this.GetComponent<Animator>().SetBool("Close", false);
    }
    public void CloseChest()
    {
        this.GetComponent<Animator>().SetBool("Open", false);
        this.GetComponent<Animator>().SetBool("Close", true);
    }
    public void IdleChest()
    {
        this.GetComponent<Animator>().SetBool("Open", false);
        this.GetComponent<Animator>().SetBool("Close", false);
    }

}
