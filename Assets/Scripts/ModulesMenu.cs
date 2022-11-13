using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModulesMenu : MonoBehaviour
{
    [SerializeField] private Button _toFlags;
    [SerializeField] private Button _toSubway;
    [SerializeField] private Button _toShips;
    [SerializeField] private Button _quit;

    private void Start()
    {
        _toFlags.onClick.AddListener(() => LoadModule("Flags"));
        _toSubway.onClick.AddListener(() => LoadModule("Subway"));
        _toShips.onClick.AddListener(() => LoadModule("ShipsMain"));
        _quit.onClick.AddListener(() => Application.Quit());
    }

    private void LoadModule(string name)
    {
        SceneManager.LoadScene(name);
    }
}
