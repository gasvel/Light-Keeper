using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour {

    [SerializeField]
    private GameObject helpScreen;

	public void StartNewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenHelpScreen()
    {
        helpScreen.SetActive(true);
    }

    public void CloseHelpScreen()
    {
        helpScreen.SetActive(false);
    }
}
