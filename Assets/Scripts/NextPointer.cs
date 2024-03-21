using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class NextPointer : MonoBehaviour
{
    private float barTime = 0.0f;
    private bool IsOn;
    public SpriteRenderer FirstImage; //기존 sprite 이미지
    public Sprite SecondSprite; // 변경될 이미지
    public Image LoadingBar;

    private void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;

        GameObject.Find("Image").SetActive(false);
        GameObject.Find("Button1").SetActive(false);
        GameObject.Find("Button2").SetActive(false);
        GameObject.Find("Button3").SetActive(false);
        GameObject.Find("ListObject").SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (IsOn)
        {
            if (barTime <= 3.0f)
            {
                barTime += Time.deltaTime;
            }
            LoadingBar.fillAmount = barTime / 3.0f;

            if (barTime >= 3.0f && gameObject.name == "BookOpen")
            {
                if (GameObject.Find("Canvas").transform.Find("Image").gameObject.activeSelf == false)
                {
                    Debug.Log("Book Open");
                    GameObject.Find("Canvas").transform.Find("Image").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Button1").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Button2").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("Button3").gameObject.SetActive(true);
                }
            }
            if (barTime >= 3.0f && gameObject.name == "Button2")
            {
                Debug.Log("Back Btn");
                if (GameObject.Find("Canvas").transform.Find("Image").gameObject.activeSelf == true)
                {
                    GameObject.Find("Canvas").transform.Find("Image").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Button1").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Button2").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("Button3").gameObject.SetActive(false);
                } 
            }

            if (barTime >= 3.0f && gameObject.name == "Button3")
            {
                Debug.Log("Next Scene");
                NextScene();
            }

            if (barTime >= 3.0f && gameObject.name == "BooksList")
            {
                Debug.Log("Book List");
                GameObject.Find("ListCanvas").transform.Find("ListObject").gameObject.SetActive(true);
            }

            if (barTime >= 3.0f && gameObject.name == "Button1")
            {
                Debug.Log("Next Btn");
                ChangeImage();
            }
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        IsOn = gazedAt;
        barTime = 0.0f;

        if (gazedAt)
            Debug.Log("In");
        else
            Debug.Log("Out");
            LoadingBar.fillAmount = 0;
            GameObject.Find("ListObject").SetActive(false);
    }
    public void ChangeImage()
    {
        FirstImage.sprite = SecondSprite; //FirstImage를 SecondSprite에 존제하는 이미지로 바꾸어줍니다
    }

    public void NextScene()
    {
        // 문자열 이용해서 씬 전환
        SceneManager.LoadScene("Second Scene");   
    }
}