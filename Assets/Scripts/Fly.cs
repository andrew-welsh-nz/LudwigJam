using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindRandomPos();
    }

    void FindRandomPos()
    {
        Vector3 randomPos = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        float randomRotation = Random.Range(0, 360);
        float randomTime = Random.Range(0.1f, 0.5f);

        transform.DOLocalMove(randomPos, randomTime).SetEase(Ease.Linear);
        transform.DOLocalRotate(new Vector3(0, randomRotation, 0), randomTime).SetEase(Ease.Linear).OnComplete(FindRandomPos);
    }
}
