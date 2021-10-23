using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    CanvasGroup loader;

    [SerializeField]
    CanvasGroup introInfo;

    [SerializeField]
    GameObject playerFrog;

    [SerializeField]
    CanvasGroup finishedScreen;

    // Start is called before the first frame update
    void Start()
    {
        introInfo.DOFade(1, 0.5f).SetDelay(0.5f);
    }

    public void PlayGame()
    {
        loader.DOFade(0, 0.5f);
        introInfo.DOFade(0, 0.5f);
        playerFrog.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        loader.alpha = 0;
        this.gameObject.SetActive(true);
        finishedScreen.DOFade(0, 0.5f);
        loader.DOFade(1, 0.5f).OnComplete(() => SceneManager.LoadScene(0));
    }
}
