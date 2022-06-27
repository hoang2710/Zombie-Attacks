using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject WorldSpaceUI;


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

    void Start(){
        WorldSpaceUI = GameObject.FindGameObjectWithTag("World Space UI");
    }

    public GameObject SetHealthBar(string tag, Transform trans){
        HealthBar healthBar = Instantiate(PrefabManager.Instance.HealthPrefab, trans.position, Quaternion.identity, WorldSpaceUI.transform).GetComponent<HealthBar>();
        healthBar.SetObjectTag(tag);
        return healthBar.gameObject;
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnClickBackButton(){
        SceneManager.LoadScene(0);
    }

    public void OnClickQuitButton(){
        Application.Quit();
    }
}
