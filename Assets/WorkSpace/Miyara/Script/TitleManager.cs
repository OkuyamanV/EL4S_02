using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] FadeManager fadeManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½");
            fadeManager.FadeIn("GameScene01");
        }
    }
}
