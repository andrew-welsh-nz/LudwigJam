using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject menuObject;

    [SerializeField]
    GameObject settingsObject;

    [SerializeField]
    GameObject creditsObject;

    [SerializeField]
    Image staticImage;

    [SerializeField]
    Sprite[] staticSprites;

    [SerializeField]
    CanvasGroup loadingGroup;

    public void StartGame()
    {
        loadingGroup.gameObject.SetActive(true);
        loadingGroup.DOFade(1, 0.5f).OnComplete(() => SceneManager.LoadScene(1));
    }

    public void SwapVisibleScreen(int _newScreen)
    {
        StartCoroutine(SwapScreen(_newScreen));
    }

    IEnumerator SwapScreen(int _newScreen)
    {
        staticImage.sprite = staticSprites[0];
        staticImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        staticImage.sprite = staticSprites[1];
        yield return new WaitForSeconds(0.1f);

        switch(_newScreen)
        {
            // Menu
            case 0:
                menuObject.SetActive(true);
                settingsObject.SetActive(false);
                creditsObject.SetActive(false);
                break;
            // Settings
            case 1:
                menuObject.SetActive(false);
                settingsObject.SetActive(true);
                creditsObject.SetActive(false);
                break;
            // Credits
            case 2:
                menuObject.SetActive(false);
                settingsObject.SetActive(false);
                creditsObject.SetActive(true);
                break;
        }

        staticImage.sprite = staticSprites[2];
        yield return new WaitForSeconds(0.1f);

        staticImage.sprite = staticSprites[3];
        yield return new WaitForSeconds(0.1f);

        staticImage.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
