using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damageImage;
   
    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }
    private IEnumerator ShowEffect()
    {
        _damageImage.enabled = true;
        for (float t = 1f; t > 0; t-=Time.deltaTime)
        {
            _damageImage.color = new Color(1, 0, 0, t);
            yield return null;
        }
        _damageImage.enabled = false;
    }
}
