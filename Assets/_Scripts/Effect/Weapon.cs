using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    TrailRenderer trailEffect;


    public void Use()
    {
        StopCoroutine("Swing");
        StartCoroutine("Swing");
    }

    IEnumerator Swing()
    {
        trailEffect.enabled = true;
        yield return new WaitForSeconds(0.1f);
        trailEffect.enabled = false;
    }
}
