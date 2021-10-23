using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HomeManager : MonoBehaviour
{
    int numFlies = 0;
    int displayedFlies = 0;

    [Header("Gameplay")]
    [SerializeField]
    int targetFlies = 100;

    [SerializeField]
    Frogy playerFrog;

    [Header("Frogs")]
    [SerializeField]
    GameObject[] frogGroups;

    [SerializeField]
    float frogDisplayDelay = 0.5f;

    [Header("Particles")]
    [SerializeField]
    GameObject[] emoteParticles;

    [SerializeField]
    ParticleSystem[] smokeParticles;

    [Header("UI")]
    [SerializeField]
    TextMeshProUGUI viewerText;

    AudioSource spawnAudio;

    bool finishedGame = false;

    private void Awake()
    {
        spawnAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        viewerText.text = displayedFlies.ToString();

        if (displayedFlies == targetFlies && !finishedGame)
        {
            // Game finished!
            finishedGame = true;
            Debug.Log("Finished game!");
            playerFrog.FinishGame();
        }
    }

    public void DepositFlies(float _numToDeposit)
    {
        if (_numToDeposit > 0)
        {
            Debug.Log("Deposited " + _numToDeposit + " flies!");

            // add 2 grous of frogs for each fly
            // Enable 2 random particles each time - 3 for flies 1 and 3

            for (int i = 0; i < _numToDeposit; i++)
            {
                numFlies++;
                StartCoroutine(WaitToEnableFrogs(numFlies));
                EnableEmotes(numFlies);
            }

            DOTween.To(() => displayedFlies, x => displayedFlies = x, numFlies * 20, 2).SetEase(Ease.OutQuart);

            // Smoke particles
            foreach (ParticleSystem smoke in smokeParticles)
            {
                Debug.Log("playing smoke");
                smoke.Play();
            }

            spawnAudio.Play();
        }
    }

    IEnumerator WaitToEnableFrogs(int _frogIndex)
    {
        yield return new WaitForSeconds(frogDisplayDelay);

        EnableFrogs(_frogIndex);
    }

    void EnableFrogs(int _frogIndex)
    {
        frogGroups[_frogIndex - 1].SetActive(true);
    }

    void EnableEmotes(int _emoteIndex)
    {
        foreach(ParticleSystem particleChild in emoteParticles[_emoteIndex - 1].GetComponentsInChildren<ParticleSystem>())
        {
            particleChild.Play();
        }
    }
}
