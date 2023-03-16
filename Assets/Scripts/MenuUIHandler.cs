using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_InputField PlayerNameInput;

    public void SetPlayerName(string name)
    {
        DataManager.Instance.CurrentName = name;
    }

    private void Start()
    {
        ScoreText.text = $"Best Score: {DataManager.Instance.ScoreName} : {DataManager.Instance.Score}";
        PlayerNameInput.onValueChanged.AddListener(SetPlayerName);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}