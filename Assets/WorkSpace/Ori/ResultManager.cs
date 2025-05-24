using UnityEngine;

public class ResultManager : MonoBehaviour
{
    FadeManager fadeManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeManager = GetComponent<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fadeManager.FadeIn("TitleScene");
        }
    }
}
