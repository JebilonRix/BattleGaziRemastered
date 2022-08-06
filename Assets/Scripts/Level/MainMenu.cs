using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;

    private void Start()
    {
        ChangePanel(0);
    }

    public void ChangePanel(int index)
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(index == i);
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}