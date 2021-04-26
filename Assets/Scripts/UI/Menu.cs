using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _gameOverPannel;

    public event UnityAction<bool> MouseCoversButton;
    public event UnityAction<bool> MouseLeftButton;

    private IEnumerator SetClosingDelay(float delayTime, GameObject closedPanel)
    {
        var delay = new WaitForSeconds(delayTime);
        yield return delay;
        closedPanel.SetActive(false);
    }

    public void OpenGameOverPannel(bool playerDied)
    {
        _gameOverPannel.SetActive(playerDied);
        Time.timeScale = 0;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePannel(GameObject panel)
    {
        StartCoroutine(SetClosingDelay(0.2f, panel));
        Time.timeScale = 1;
    }

    public void RestartGame(GameObject panel)
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseCoversButton?.Invoke(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseLeftButton?.Invoke(false);
    }
}
