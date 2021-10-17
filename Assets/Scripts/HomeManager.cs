using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    int numFrogs = 0;
    int numFlies = 0;

    public void DepositFlies(float _numToDeposit)
    {
        Debug.Log("Deposited " + _numToDeposit + " flies!");
    }

    void ConvertFliesToFrogs()
    {

    }
}
