using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public float endTime = 20f;

    void Start()
    {
        Invoke("QuitGame", endTime);
    }

    void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
