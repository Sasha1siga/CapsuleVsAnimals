using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _playerRenderers;
    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }    

    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t+= Time.deltaTime)
        {
            foreach (var playerRenderer in _playerRenderers)
            {
                for (int j = 0; j < playerRenderer.materials.Length; j++)
                {
                    playerRenderer.materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30)*0.5f +0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
    }
}
