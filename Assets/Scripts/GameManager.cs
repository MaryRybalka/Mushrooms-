using UnityEngine;
using MushroomNocturne.Player;

namespace MushroomNocturne.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameState startState = GameState.Menu;
        [SerializeField] private GameObject menuRoot;
        [SerializeField] private GameObject gameplayHudRoot;
        [SerializeField] private GameObject pauseRoot;
        [SerializeField] private GameObject gameOverRoot;
        [SerializeField] private PlayerStats playerStats;

        public GameState CurrentState { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void OnEnable()
        {
            if (playerStats != null)
            {
                playerStats.OnPlayerDied += HandlePlayerDied;
            }
        }

        private void Start()
        {
            SetState(startState);
        }

        private void OnDisable()
        {
            if (playerStats != null)
            {
                playerStats.OnPlayerDied -= HandlePlayerDied;
            }
        }

        private void Update()
        {
            if (CurrentState == GameState.Gameplay && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
            else if (CurrentState == GameState.Pause && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeGame();
            }
        }

        public void StartGame()
        {
            SetState(GameState.Gameplay);
        }

        public void OpenMenu()
        {
            SetState(GameState.Menu);
        }

        public void PauseGame()
        {
            if (CurrentState == GameState.Gameplay)
            {
                SetState(GameState.Pause);
            }
        }

        public void ResumeGame()
        {
            if (CurrentState == GameState.Pause)
            {
                SetState(GameState.Gameplay);
            }
        }

        public void TriggerGameOver()
        {
            SetState(GameState.GameOver);
        }

        private void HandlePlayerDied()
        {
            TriggerGameOver();
        }

        private void SetState(GameState nextState)
        {
            CurrentState = nextState;
            Time.timeScale = nextState == GameState.Pause || nextState == GameState.Menu || nextState == GameState.GameOver ? 0f : 1f;

            if (menuRoot != null) menuRoot.SetActive(nextState == GameState.Menu);
            if (gameplayHudRoot != null) gameplayHudRoot.SetActive(nextState == GameState.Gameplay || nextState == GameState.Pause);
            if (pauseRoot != null) pauseRoot.SetActive(nextState == GameState.Pause);
            if (gameOverRoot != null) gameOverRoot.SetActive(nextState == GameState.GameOver);
        }
    }
}
