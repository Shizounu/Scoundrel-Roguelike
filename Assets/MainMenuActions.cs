using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuActions : MonoBehaviour
{
    public GameObject SettingsParent;
    public GameObject MainMenuParent;
    public int sceneIndex = 1;
    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void ToggleSettings()
    {
        SettingsParent.SetActive(!SettingsParent.activeSelf);
        MainMenuParent.SetActive(!MainMenuParent.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
        
    }
}
