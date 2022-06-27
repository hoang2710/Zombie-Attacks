using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject WorldSpaceUI;
    public GameObject PausePanel;


    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        WorldSpaceUI = GameObject.FindGameObjectWithTag("World Space UI");
    }

    public GameObject SetHealthBar(Transform trans)
    {
        HealthBar healthBar = Instantiate(PrefabManager.Instance.HealthPrefab, trans.position, Quaternion.identity, WorldSpaceUI.transform).GetComponent<HealthBar>();
        healthBar.SetObjectTransform(trans);
        return healthBar.gameObject;
    }

    public void SpawnDamagePopUp(Transform trans, int damage)
    {
        DamagePopUp item = Instantiate(PrefabManager.Instance.DamagePopUpPrefabs, trans.position, Quaternion.identity, WorldSpaceUI.transform).GetComponent<DamagePopUp>();
        item.SetDamageText(damage);
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickResumeButton(){
        PausePanel.SetActive(false);
        GameManager.Instance.ChangeGameState(GameManager.Instance.lastState);
    }

    public void OnClickPauseButton(){
        PausePanel.SetActive(true);
        GameManager.Instance.ChangeGameState(GameManager.GameState.Pause);
    }
}
