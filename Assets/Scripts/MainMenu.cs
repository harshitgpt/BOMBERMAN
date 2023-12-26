using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject levelPanel;

    public void PlayGame()
    {
        levelPanel.SetActive(true);
        this.gameObject.SetActive(false);

    }

    public void QuitGame()
    {
        ///Quit the game
        Application.Quit();

    }

    



}
