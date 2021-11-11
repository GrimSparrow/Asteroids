using AsteroidsKefir.Models;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Окно отображающее счет и дает возможность перезапустить игру.
/// </summary>
public class EndGameView : MonoBehaviour
{
    /// <summary>
    /// Поле счета за убийства.
    /// </summary>
    [SerializeField] private TextMeshProUGUI scoreField;
    
    /// <summary>
    /// Кнопка, по нажатии на которую произойдет перезапуск игры.
    /// </summary>
    [SerializeField] private Button restartGame;

    /// <summary>
    /// Текущий счет.
    /// </summary>
    private int _currentScore;

    private void Start()
    {
        Enemy.Killed += AddScore;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Enemy.Killed -= AddScore;
    }

    /// <summary>
    /// Начислить очки за убийство противника.
    /// </summary>
    private void AddScore(int score)
    {
        _currentScore += score;
    }

    /// <summary>
    /// Отобразить окно результата.
    /// </summary>
    public void ShowEndView()
    {
        scoreField.SetText($"Ваш счет: {_currentScore}");

        restartGame.onClick.RemoveAllListeners();
        restartGame.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        gameObject.SetActive(true);
    }
}
