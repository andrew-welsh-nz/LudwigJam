using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    CanvasGroup loader;

    [SerializeField]
    CanvasGroup introInfo;

    [SerializeField]
    GameObject playerFrog;

    // Start is called before the first frame update
    void Start()
    {
        introInfo.DOFade(1, 0.5f).SetDelay(0.5f);
    }

    public void PlayGame()
    {
        loader.DOFade(0, 0.5f);
        playerFrog.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
