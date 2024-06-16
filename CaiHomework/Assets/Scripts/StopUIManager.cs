using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopUIManager : MonoBehaviour
{
    public static StopUIManager instance;
    private void Awake()
    {
        instance = this;
    }


    public GameObject StopPlane;
    public GameObject CountineBtn;
    public GameObject QuitBtn;

    public GameObject NameText;
    public GameObject UserHead;
    public GameObject PlaceText;
    public GameObject CenterPlaceText;
    Color centerPlaceColor;

     float TextVisSpeed;

    public List<GameObject> UserHeadList;
    public int nowHead;
    public int now;

    void Start()
    {
        StopPlane = GameObject.Find("StopPlane");
        CountineBtn = GameObject.Find("CountineBtn");
        QuitBtn = GameObject.Find("QuitBtn");
        NameText = GameObject.Find("NameText");
        UserHead = GameObject.Find("UserHead");
        PlaceText = GameObject.Find("PlaceText");
        CenterPlaceText = GameObject.Find("PlaceTextCenter");
        centerPlaceColor = CenterPlaceText.GetComponent<Text>().color;
        centerPlaceColor.a = 1f;
        TextVisSpeed = 0.7f;

        UserHeadList = new List<GameObject>();

        CountineBtn.GetComponent<Button>().onClick.AddListener(CountineGame);
        QuitBtn.GetComponent<Button>().onClick.AddListener(QuitGame);

        NameText.GetComponent<Text>().text = GameManager.Instance.userName;

        StopPlane.SetActive(false);

        HeadLoad();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopPlane.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            do
            {
                now = Random.Range(0, 3);
            } while (now == nowHead);

            UserHeadList[nowHead].SetActive(false);
            UserHeadList[now].SetActive(true);
            nowHead = now;
        }

        CenterPlaceTextVis();
    }

    void CountineGame()
    {
        Time.timeScale = 1f;
        StopPlane.SetActive(false);
        Cursor.visible = false;
    }

    void QuitGame()
    {
        Application.Quit();
    }
    void HeadLoad()
    {
        foreach (Transform child in UserHead.transform)
        {
            UserHeadList.Add(child.gameObject);
        }

        foreach (GameObject i in UserHeadList)
        {
            i.SetActive(false);
        }

        now = Random.Range(0, 3);
        UserHeadList[now].SetActive(true);
        nowHead = now;
    }
    public void ReLoadPlace(string name)
    {
        if (PlaceText.GetComponent<Text>().text != name)
        {
            PlaceText.GetComponent<Text>().text = name;
        }
    }

    void CenterPlaceTextVis()
    {
        if (PlaceText.GetComponent<Text>().text != CenterPlaceText.GetComponent<Text>().text)
        {
            CenterPlaceText.GetComponent<Text>().text = PlaceText.GetComponent<Text>().text;
            centerPlaceColor.a = 1;
            CenterPlaceText.GetComponent<Text>().color = centerPlaceColor;
        }

        if (CenterPlaceText.GetComponent<Text>().color.a != 0)
        {
            Debug.Log(centerPlaceColor.a);

            if (centerPlaceColor.a > 0)
            {
                centerPlaceColor.a -= Time.deltaTime * TextVisSpeed;
            }

            CenterPlaceText.GetComponent<Text>().color = centerPlaceColor;
        }
    }
}
