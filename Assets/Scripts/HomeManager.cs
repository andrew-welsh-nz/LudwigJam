using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    int numFlies = 0;

    [SerializeField]
    int targetFlies = 10;

    [SerializeField]
    GameObject[] frogGroups;

    [SerializeField]
    ParticleSystem[] emoteParticles;

    public void DepositFlies(float _numToDeposit)
    {
        Debug.Log("Deposited " + _numToDeposit + " flies!");

        // add 1 group of frogs for each fly
        // Enable 1 random particle each time - two on frog groups 2 and 8

        for(int i = 0; i < _numToDeposit; i++)
        {
            numFlies++;
            EnableFrogs();
            EnableEmotes();

            if(numFlies == 2 || numFlies == 8)
            {
                EnableEmotes();
            }
        }

        if(numFlies == targetFlies)
        {
            // Game finished!
        }
    }

    void EnableFrogs()
    {
        int randomFrogGroup = 0;

        do
        {
            randomFrogGroup = Random.Range(0, frogGroups.Length - 1);
        }
        while (frogGroups[randomFrogGroup].activeSelf);

        frogGroups[randomFrogGroup].SetActive(true);
    }

    void EnableEmotes()
    {
        int randomParticles = 0;

        do
        {
            randomParticles = Random.Range(0, emoteParticles.Length - 1);
        }
        while (emoteParticles[randomParticles].isPlaying);

        emoteParticles[randomParticles].Play();
    }
}
