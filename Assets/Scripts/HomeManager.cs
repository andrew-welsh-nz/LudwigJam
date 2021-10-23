using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HomeManager : MonoBehaviour
{
    int numFlies = 0;
    int displayedFlies = 0;

    [SerializeField]
    int targetFlies = 10;

    [SerializeField]
    GameObject[] frogGroups;

    [SerializeField]
    float frogDisplayDelay = 0.5f;

    [SerializeField]
    ParticleSystem[] emoteParticles;

    [SerializeField]
    ParticleSystem[] smokeParticles;

    [SerializeField]
    TextMeshProUGUI viewerText;

    AudioSource spawnAudio;

    private void Awake()
    {
        spawnAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        viewerText.text = displayedFlies.ToString();
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
                StartCoroutine(WaitToEnableFrogs());
                StartCoroutine(WaitToEnableFrogs());
                EnableEmotes();
                EnableEmotes();

                if (numFlies == 1 || numFlies == 3)
                {
                    EnableEmotes();
                }
            }

            DOTween.To(() => displayedFlies, x => displayedFlies = x, numFlies * 20, 2).SetEase(Ease.OutQuart);

            // Smoke particles
            foreach (ParticleSystem smoke in smokeParticles)
            {
                Debug.Log("playing smoke");
                smoke.Play();
            }

            spawnAudio.Play();

            if (numFlies == targetFlies)
            {
                // Game finished!
            }
        }
    }

    IEnumerator WaitToEnableFrogs()
    {
        yield return new WaitForSeconds(frogDisplayDelay);

        EnableFrogs();
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
