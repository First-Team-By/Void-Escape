using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingRotateStar : MonoBehaviour
{
    [Header("Обьект для вращения по z")]
    public GameObject shootingStar_1;

    public void RandomRotateStar()
    {
        shootingStar_1.transform.rotation = Random.rotation;

        //shootingStar_1.transform.Rotate(0f, 0f, Random.Range(-180f, 180f));
    }
}
