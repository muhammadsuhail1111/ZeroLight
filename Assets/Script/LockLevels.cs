using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockLevels : MonoBehaviour
{
    public static LockLevels Instance;

    [SerializeField] Button easyButton;
    [SerializeField] Button mediumButton;
    [SerializeField] Button hardButton;
    [SerializeField] Button veryhardButton;
    [SerializeField] Button veryeasyButton;

    [SerializeField] GameObject mediumLockIcon;
    [SerializeField] GameObject hardLockIcon;
    [SerializeField] GameObject veryhardLockIcon;
    [SerializeField] GameObject easyLockIcon;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeLevels();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateButtons();
    }
    private void InitializeLevels()
    {
        if (!PlayerPrefs.HasKey("VeryEasy")) PlayerPrefs.SetInt("VeryEasy", 1); 
        if (!PlayerPrefs.HasKey("Easy")) PlayerPrefs.SetInt("Easy", 0); 
        if (!PlayerPrefs.HasKey("Medium")) PlayerPrefs.SetInt("Medium", 0);
        if (!PlayerPrefs.HasKey("Hard")) PlayerPrefs.SetInt("Hard", 0);
        if (!PlayerPrefs.HasKey("VeryHard")) PlayerPrefs.SetInt("VeryHard", 0);

        PlayerPrefs.Save();
    }

    public void UpdateButtons()
    {
        veryeasyButton.interactable = true;

        easyButton.interactable = PlayerPrefs.GetInt("Easy", 0) == 1;
        easyLockIcon.SetActive(!easyButton.interactable);

        mediumButton.interactable = PlayerPrefs.GetInt("Medium", 0) == 1;
        mediumLockIcon.SetActive(!mediumButton.interactable);

        hardButton.interactable = PlayerPrefs.GetInt("Hard", 0) == 1;
        hardLockIcon.SetActive(!hardButton.interactable);

        veryhardButton.interactable = PlayerPrefs.GetInt("VeryHard", 0) == 1;
        veryhardLockIcon.SetActive(!veryhardButton.interactable);
        Debug.Log("update buttons");

    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("VeryEasy");
        PlayerPrefs.DeleteKey("Easy");
        PlayerPrefs.DeleteKey("Medium");
        PlayerPrefs.DeleteKey("Hard");
        PlayerPrefs.DeleteKey("VeryHard");

        InitializeLevels();
        UpdateButtons();
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}