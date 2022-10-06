using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Obstacle;
    public float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isgameOver;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isgameOver)
        {
            m_ui.isShowReplayPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnObtacle();
            m_spawnTime = spawnTime;
        }
    }

    void SpawnObtacle()
    {
        Vector3 obstaclePos = new Vector3(14, Random.Range(-3, -0.8f), 0);
        if (Obstacle)
        {
            Instantiate(Obstacle, obstaclePos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void IncrementScore()
    {
        m_score++;
        m_ui.setScoreText("Score: " + m_score);
    }
    public void SetGameOverState(bool state)
    {
        m_isgameOver = state;
    }
    public bool GetIsGameOver()
    {
        return m_isgameOver;
    }
}
