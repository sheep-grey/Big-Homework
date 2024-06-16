using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    public GameObject StartBtn;
    public GameObject QuitBtn;
    public GameObject LookUI;
    public GameObject LoadUI;
    public GameObject LoadProcess;
    public GameObject userName;
    public GameObject ID;
    public GameObject RedText;

    void Start()
    {
        StartBtn = GameObject.Find("StartBtn");
        QuitBtn = GameObject.Find("QuitBtn");
        LookUI = GameObject.Find("LookUI");
        LoadUI = GameObject.Find("LoadUI");
        LoadProcess = GameObject.Find("LoadProcess");
        userName = GameObject.Find("userName");
        ID = GameObject.Find("ID");
        RedText = GameObject.Find("RedText");

        RedText.SetActive(false);
        LoadUI.SetActive(false);

        StartBtn.GetComponent<Button>().onClick.AddListener(StartGame);
        QuitBtn.GetComponent<Button>().onClick.AddListener(QuitGame);

        Cursor.lockState = CursorLockMode.Confined;
    }

    void StartGame()
    {
        if (ID.GetComponent<InputField>().text == "" || userName.GetComponent<InputField>().text == "")
        {
            StartCoroutine(RedTextPlay());
        }
        else
        {
            GameManager.Instance.userName = userName.GetComponent<InputField>().text;
            GameManager.Instance.ID = ID.GetComponent<InputField>().text;

            StartCoroutine(ToOnGame());
        }

    }

    void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator ToOnGame()
    {
        LookUI.SetActive(false);
        LoadUI.SetActive(true);

        Cursor.visible = false;

        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScence");

        while (!operation.isDone)
        {
            LoadProcess.GetComponent<Slider>().value = operation.progress;
            yield return null;
        }

    }

    IEnumerator RedTextPlay()
    {
        RedText.SetActive(true);
        yield return new WaitForSeconds(2f);
        RedText.SetActive(false);
    }
}
