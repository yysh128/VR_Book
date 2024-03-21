using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour
{
    public Image LoadingBar;
    private bool IsOn;
    private float barTime = 0.0f;
    void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;
        //GameObject.Find("Canvas").transform.Find("Image").gameObject.SetActive(true);
        GameObject.Find("ShipCanvas").transform.Find("ShipTextbg").gameObject.SetActive(false);
        GameObject.Find("RobotCanvas").transform.Find("RobotTextbg").gameObject.SetActive(false);
    }

    void Update()
    {
        if (IsOn)
        {
            if (barTime <= 3.0f)
            {
                barTime += Time.deltaTime;
            }
            LoadingBar.fillAmount = barTime / 3.0f;

            if (barTime >= 3.0f && gameObject.name == "robotSphere")
            {
                GameObject.Find("RobotCanvas").transform.Find("RobotTextbg").gameObject.SetActive(true);
            }

            if (barTime >= 3.0f && gameObject.name == "Ship")
            {
                GameObject.Find("ShipCanvas").transform.Find("ShipTextbg").gameObject.SetActive(true);
            }

            if (barTime >= 3.0f && gameObject.name == "Next")
            {
                Debug.Log("Main Scene");
                NextScene();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        IsOn = gazedAt;
        barTime = 0.0f;
        if (gazedAt)
        {
            Debug.Log("In");
        }
        else
        {
            Debug.Log("Out");
            LoadingBar.fillAmount = 0;
            GameObject.Find("RobotCanvas").transform.Find("RobotTextbg").gameObject.SetActive(false);
            GameObject.Find("ShipCanvas").transform.Find("ShipTextbg").gameObject.SetActive(false);
        }
    }
    public void NextScene()
    {
        // 문자열 이용해서 씬 전환
        SceneManager.LoadScene("Main Scene");
    }
}
