using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField]
    CanvasGroup uiGroup;

    // Start is called before the first frame update
    void Start()
    {
        uiGroup.alpha = 0;
    }

    void EnableUI()
    {
        uiGroup.DOFade(1.0f, 0.5f);
    }
}
