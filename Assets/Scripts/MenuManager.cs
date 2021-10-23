using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject menuObject;

    [SerializeField]
    GameObject creditsObject;

    [SerializeField]
    Image staticImage;

    [SerializeField]
    Sprite[] staticSprites;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SwapVisibleScreen()
    {
        StartCoroutine(SwapScreen());
    }

    IEnumerator SwapScreen()
    {
        staticImage.sprite = staticSprites[0];
        staticImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        staticImage.sprite = staticSprites[1];
        yield return new WaitForSeconds(0.1f);

        // Swap screen
        if(menuObject.activeSelf)
        {
            menuObject.SetActive(false);
            creditsObject.SetActive(true);
        }
        else
        {
            menuObject.SetActive(true);
            creditsObject.SetActive(false);
        }

        staticImage.sprite = staticSprites[2];
        yield return new WaitForSeconds(0.1f);

        staticImage.sprite = staticSprites[3];
        yield return new WaitForSeconds(0.1f);

        staticImage.gameObject.SetActive(false);
    }
}
