using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class AniPointer : MonoBehaviour
{
    Animator animator;
    private float barTime = 0.0f;
    private bool IsOn;
    public Image LoadingBar;
    public TMP_Text tmp;

    // Start is called before the first frame update
    void Start()
    {
        IsOn = false;
        LoadingBar.fillAmount = 0;
        animator = GetComponent<Animator>();
        animator.SetBool("StandUp", false);
        tmp.text = "???";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (IsOn)
        {
            if (barTime >= 3.0f && gameObject.name == "MaleDummy")
            {
                tmp.text = "루이";
                StandUp();
            }

            if (barTime >= 3.0f && gameObject.name == "Next")
            {
                Debug.Log("Next Scene");
                NextScene();
            }

            if (barTime <= 3.0f)
            {
                barTime += Time.deltaTime;
            }
            LoadingBar.fillAmount = barTime / 3.0f;
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

    }

    public void StandUp()
    {
        animator.SetBool("StandUp", true);
    }
    public void NextScene()
    {
        // 문자열 이용해서 씬 전환
        SceneManager.LoadScene("Third Scene");
    }
}
