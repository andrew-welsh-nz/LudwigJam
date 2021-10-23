using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CanvasGroup>().DOFade(0, 0.5f).SetDelay(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
