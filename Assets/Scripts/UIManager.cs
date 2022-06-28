using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject WorldSpaceUI;
    public GameObject PausePanel;
    public GameObject GameOverPanel;


    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChange;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameManager.GameState state){
        if(state == GameManager.GameState.GameOver){
            GameOverPanel.SetActive(true);
        }
    }

    public GameObject SetHealthBar(Transform trans, int type)
    {
        HealthBar healthBar = Instantiate(PrefabManager.Instance.HealthPrefab[type], trans.position, Quaternion.identity, WorldSpaceUI.transform).GetComponent<HealthBar>();
        healthBar.SetObjectTransform(trans);
        return healthBar.gameObject;
    }

    public void SpawnDamagePopUp(Transform trans, int damage, int type)
    {
        DamagePopUp item = Instantiate(PrefabManager.Instance.DamagePopUpPrefabs[type], trans.position, Quaternion.identity, WorldSpaceUI.transform).GetComponent<DamagePopUp>();
        item.SetDamageText(damage);
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.Instance.ChangeGameState(GameManager.GameState.Day);
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.ChangeGameState(GameManager.GameState.StartMenu);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickResumeButton(){
        PausePanel.SetActive(false);
        GameManager.Instance.ChangeGameState(GameManager.GameState.Resume);
    }

    public void OnClickPauseButton(){
        PausePanel.SetActive(true);
        GameManager.Instance.ChangeGameState(GameManager.GameState.Pause);
    }

}
