using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] GameObject OptionsCanvas = null;
    [SerializeField] Toggle musicToggle = null;
    [SerializeField] bool defaultMusic = true;
    [SerializeField] Toggle effectToggle = null;
    [SerializeField] bool defaulEffect = true;
    [SerializeField] Slider difficultySlider = null;
    [SerializeField] float defaultDifficulty = 0f;

    AttackerSpawner[] spawners;

    // Start is called before the first frame update
    void Start()
    {
       
        if (OptionsCanvas==null) { GetInstances(); return; }
        else
        {
            OptionsCanvas.SetActive(false);
            spawners = FindObjectsOfType<AttackerSpawner>();
            GetInstances();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            if (musicToggle.isOn)
            {
                musicPlayer.SetMusic(1);
            }
            else
            {
                musicPlayer.SetMusic(0);
            }
        }
        else
        {
            Debug.LogWarning("No music player found... did you start from splash screen ?");
        }
    }

    public void GetInstances()
    {
        musicToggle.isOn = PlayerPrefsController.GetMasterMusicBool();
        effectToggle.isOn = PlayerPrefsController.GetMasterEffectBool();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    
    public void ReturnDefaults()
    {
        musicToggle.isOn = defaultMusic;
        effectToggle.isOn = defaulEffect;
        difficultySlider.value = defaultDifficulty;
    }
    public void OpenSettingCanvas()
    {
        Time.timeScale = 0f;
        OptionsCanvas.SetActive(true);
    }
    public void BackAndSave()
    {
        Save();
        FindObjectOfType<LevelLoader>().LoadStartScene();
    }
    private void Save()
    {
        PlayerPrefsController.SetMasterMusic(musicToggle.isOn);
        PlayerPrefsController.SetMasterEffects(effectToggle.isOn);
        PlayerPrefsController.SetDiff(difficultySlider.value);
    }
    public void CloseSettingCanvas()
    {
        Save();
        if (FindObjectOfType<Attacker>())
        {
            FindObjectOfType<Attacker>().EffectOnOrClose();
        }
        if (FindObjectOfType<Defender>())
        {
            FindObjectOfType<Defender>().EffectOnOrClose();
        }
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.MakeItHardOrEasy(difficultySlider.value);
        }
       
        Time.timeScale = 1f;
        OptionsCanvas.SetActive(false);
    }
}
