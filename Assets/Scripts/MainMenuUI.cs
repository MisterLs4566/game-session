using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Toggle vsyncToggle;

    private bool isInSettings = false;
    private bool vsyncActive = false;
    private bool isFullscreen = false;

    private void Start()
    {
        fullscreenToggle.isOn = QualitySettings.vSyncCount == 1;
        vsyncToggle.isOn = Screen.fullScreen;
        isFullscreen = fullscreenToggle.isOn;
        vsyncActive = vsyncToggle.isOn;
    }

    public void SwitchToSettings()
    {
        if (isInSettings)
        {
            isInSettings = false;
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
        else
        {
            isInSettings = true;
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
    }

    public void SwitchVSync()
    {
        if (vsyncActive)
        {
            vsyncActive = false;
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            vsyncActive = true;
            QualitySettings.vSyncCount = 1;
        }
    }

    public void SwitchFullscreen()
    {
        if (isFullscreen)
        {
            isFullscreen = false;
            Screen.fullScreen = false;
        }
        else
        {
            isFullscreen = true;
            Screen.fullScreen = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
