using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMasterController : MonoBehaviour
{
    public static SceneMasterController scenes;

    private Text hscore;

    public GameObject mainCamera;
    public AudioClip masterAudioClip;

    void Awake() {
        scenes = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(mainCamera);
    }

    public void LoadMenu() { SceneManager.LoadScene("menu"); }

    public void LoadScores() { SceneManager.LoadScene("gameover"); }

    public void LoadGame() { SceneManager.LoadScene("game"); }

    public void CloseGame() { Application.Quit(); }
}