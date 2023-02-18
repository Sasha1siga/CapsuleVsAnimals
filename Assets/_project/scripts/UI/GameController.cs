using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text _winText;
    public void Win()
    {
        _winText.enabled = true;
    }
}
