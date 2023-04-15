using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject introPanel;
    
    public void StartGame()
    {
        introPanel.AddComponent<IntroPanel>();
        gameObject.SetActive(false);
    }
}