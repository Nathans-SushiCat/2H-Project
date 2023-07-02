using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    [SerializeField] TMP_Text speedTxt;
    string dir;
    private void Start()
    {
        dir = Application.persistentDataPath;
        speedTxt.text = speedSlider.value.ToString();
    }
    public void changeSpeed()
    {
        speedTxt.text = speedSlider.value.ToString();

        if (!Directory.Exists(dir + "//Settings"))
        {
            Directory.CreateDirectory(dir + "//Settings");
        }
        File.WriteAllText(dir + "//Settings" + "Settings.text", speedSlider.value.ToString());
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
