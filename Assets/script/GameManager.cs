using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private List<GameObject> _trash; // Lista de elementos de objetivos
    private int _score = 0;
    private float timer = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject ResetPanel;
    public TextMeshProUGUI finalTime;
    public TextMeshProUGUI finalScore;
    private bool stopTimer = false;
    public AudioSource audioWin;
    void Start()
    {
        _trash = new List<GameObject>(GameObject.FindGameObjectsWithTag("Trash"));
    }
    private void Update()
    {
        if (stopTimer == false)
        {
            timer += Time.deltaTime;
        }

        timerText.text = timer.ToString("F0");
        if (_trash.Count == 0)
        {
            stopTimer = true;
            ResetPanel.SetActive(true);
            finalTime.text = "Time " + timer;
            finalScore.text = "Score " + _score;
            audioWin.Play();
        }
    }
    public void TargetHit(GameObject go)
    {
        Debug.Log("Score: " + _score);
        if (_trash.Contains(go))
        {
            _score += 10;
            _trash.Remove(go);
            Debug.Log("Score " + _score);
            Destroy(go, 2);
            scoreText.text = "Score " + _score;
        }
    }
    public void ResetScene()
    {
        _score = 0;
        timer = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

