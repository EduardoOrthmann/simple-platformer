using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Presentation.Scripts.UI
{
    public class UIRoot : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject hudPanel;
        [SerializeField] private GameObject pauseMenuPanel;

        [Header("Main Menu Elements")]
        [SerializeField] private Button startButton;

        [Header("Pause Menu Elements")]
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitToMenuButton;

        [Inject]
        public void Construct(Camera mainCamera)
        {
            GetComponent<Canvas>().worldCamera = mainCamera;
        }

        public GameObject MainMenuPanel => mainMenuPanel;
        public GameObject HUDPanel => hudPanel;
        public GameObject PauseMenuPanel => pauseMenuPanel;

        public Button StartButton => startButton;
        public Button ResumeButton => resumeButton;
        public Button QuitToMenuButton => quitToMenuButton;
    }
}