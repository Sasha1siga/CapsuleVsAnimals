using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuBurron;
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private MonoBehaviour[] _componentsToDisable; 
    private void Start()
    {
        _menuWindow.SetActive(false);
    }
    public void OpenMenuWindow()
    {
        _menuBurron.SetActive(false);
        _menuWindow.SetActive(true);
        foreach (var item in _componentsToDisable)
        {
            item.enabled = false;
        }
        Time.timeScale = 0.001f;
    }

    public void CloseMenuWindow()
    {
        _menuBurron.SetActive(true);
        _menuWindow.SetActive(false);
        foreach (var item in _componentsToDisable)
        {
            item.enabled = true;
        }
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
