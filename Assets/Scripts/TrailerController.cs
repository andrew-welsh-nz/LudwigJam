using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrailerController : MonoBehaviour
{
    [SerializeField]
    GameObject cam1;

    [SerializeField]
    GameObject frog1;

    [SerializeField]
    GameObject cam2;

    [SerializeField]
    GameObject cam3;

    [SerializeField]
    GameObject cam4;

    [SerializeField]
    GameObject cam5;

    [SerializeField]
    GameObject cam6;

    [SerializeField]
    GameObject cam7;

    [SerializeField]
    GameObject cam8;

    [SerializeField]
    GameObject targetPos8;

    [SerializeField]
    GameObject frog8;

    [SerializeField]
    GameObject cam9;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.SetActive(true);
            frog1.SetActive(true);

            cam2.SetActive(false);

            cam3.SetActive(false);

            cam4.SetActive(false);

            cam5.SetActive(false);

            cam6.SetActive(false);

            cam7.SetActive(false);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(true);

            cam3.SetActive(false);

            cam4.SetActive(false);

            cam5.SetActive(false);

            cam6.SetActive(false);

            cam7.SetActive(false);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(false);

            cam3.SetActive(true);

            cam4.SetActive(false);

            cam5.SetActive(false);

            cam6.SetActive(false);

            cam7.SetActive(false);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(false);

            cam3.SetActive(false);

            cam4.SetActive(true);

            cam5.SetActive(false);

            cam6.SetActive(false);

            cam7.SetActive(false);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(false);

            cam3.SetActive(false);

            cam4.SetActive(false);

            cam5.SetActive(true);

            cam6.SetActive(false);

            cam7.SetActive(false);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(false);

            cam3.SetActive(false);

            cam4.SetActive(false);

            cam5.SetActive(false);

            cam6.SetActive(true);

            cam7.SetActive(false);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(false);

            cam3.SetActive(false);

            cam4.SetActive(false);

            cam5.SetActive(false);

            cam6.SetActive(false);

            cam7.SetActive(true);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(false);

            cam3.SetActive(false);

            cam4.SetActive(false);

            cam5.SetActive(false);

            cam6.SetActive(false);

            cam7.SetActive(false);

            cam8.SetActive(true);
            frog8.SetActive(true);

            cam8.transform.DOMove(targetPos8.transform.position, 10.0f).SetLoops(-1, LoopType.Restart);

            cam9.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            cam1.SetActive(false);
            frog1.SetActive(false);

            cam2.SetActive(false);

            cam3.SetActive(false);

            cam4.SetActive(false);

            cam5.SetActive(false);

            cam6.SetActive(false);

            cam7.SetActive(false);

            cam8.SetActive(false);
            frog8.SetActive(false);

            cam9.SetActive(true);
        }
    }
}
