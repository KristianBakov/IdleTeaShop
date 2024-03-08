using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoSingleton<AudioManager>
{
    // AudioMixerGroup names
    public const string MusicGroup = "Music";
    public const string SfxGroup = "SFX";

    // parameter suffix
    private const string ParameterSuffix = "Volume";

    [SerializeField] private AudioMixer MainAudioMixer;
    
    // basic range of UI sound clips
    [Header("UI Sounds")]
    [Tooltip("General button click.")]
    [SerializeField] AudioClip DefaultButtonSound;
    [Tooltip("General button click.")]
    [SerializeField] AudioClip AltButtonSound;
    [Tooltip("General shop purchase clip.")]
    [SerializeField] AudioClip TransactionSound;
    [Tooltip("General error sound.")]
    [SerializeField] AudioClip DefaultWarningSound;
    
    [Header("Game Sounds")]
    [Tooltip("Start preparing drink sound.")]
    [SerializeField] AudioClip StartPreparingDrinkSound;
    [Tooltip("Finish preparing drink sound.")]
    [SerializeField] AudioClip FinishPreparingDrinkSound;

    private void OnEnable()
    {
        SettingsEvents.SettingsUpdated += OnSettingsUpdated;
        GameplayEvents.SettingsUpdated += OnSettingsUpdated;
    }

    private void OnDisable()
    {
        SettingsEvents.SettingsUpdated -= OnSettingsUpdated;
        GameplayEvents.SettingsUpdated -= OnSettingsUpdated;
    }

    private static void OnSettingsUpdated(GameData gameData)
    {
        // use the gameData to set the music and sfx volume
        SetVolume(MusicGroup + ParameterSuffix, gameData.musicVolume / 100f);
        SetVolume(SfxGroup + ParameterSuffix, gameData.sfxVolume / 100f);
    }
    
    public static void SetVolume(string groupName, float linearValue)
    {
        float decibelValue = GetDecibelValue(linearValue);

        if (Instance.MainAudioMixer != null)
        {
            Instance.MainAudioMixer.SetFloat(groupName, decibelValue);
        }
    }
    
    // convert linear value between 0 and 1 to decibels
    public static float GetDecibelValue(float linearValue)
    {
        // commonly used for linear to decibel conversion
        const float conversionFactor = 20f;

        float decibelValue = (linearValue != 0) ? conversionFactor * Mathf.Log10(linearValue) : -144f;
        return decibelValue;
    }
    
    // plays one-shot audio
    public static void PlayOneSFX(AudioClip clip, Vector3 sfxPosition)
    {
        if (clip == null)
            return;

        GameObject sfxInstance = new GameObject(clip.name);
        sfxInstance.transform.position = sfxPosition;

        AudioSource source = sfxInstance.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();

        // set the mixer group (e.g. music, sfx, etc.)
        source.outputAudioMixerGroup = GetAudioMixerGroup(SfxGroup);

        // destroy after clip length
        Destroy(sfxInstance, clip.length);
    }
    
    // return an AudioMixerGroup by name
    public static AudioMixerGroup GetAudioMixerGroup(string groupName)
    {
        if (Instance.MainAudioMixer == null)
            return null;

        AudioMixerGroup[] groups = Instance.MainAudioMixer.FindMatchingGroups(groupName);
        return groups.FirstOrDefault(match => match.ToString() == groupName);
    }
    
    // convert decibel value to a range between 0 and 1
    public static float GetLinearValue(float decibelValue)
    {
        const float conversionFactor = 20f;
        return Mathf.Pow(10f, decibelValue / conversionFactor);
    }
    
    // returns a value between 0 and 1 based on the AudioMixer's decibel value
    public static float GetVolume(string groupName)
    {
        float decibelValue = 0f;
        if (Instance.MainAudioMixer != null)
        {
            Instance.MainAudioMixer.GetFloat(groupName, out decibelValue);
        }
        return GetLinearValue(decibelValue);
    }
    
    public static void PlayDefaultButtonSound(Vector3 sfxPosition)
    {
        if(Instance != null && Instance.DefaultButtonSound != null)
            PlayOneSFX(Instance.DefaultButtonSound, sfxPosition);
    }
    
    public static void PlayAltButtonSound(Vector3 sfxPosition)
    {
        if(Instance != null && Instance.AltButtonSound != null)
            PlayOneSFX(Instance.AltButtonSound, sfxPosition);
    }
    
    public static void PlayTransactionSound(Vector3 sfxPosition)
    {
        if(Instance != null && Instance.TransactionSound != null)
            PlayOneSFX(Instance.TransactionSound, sfxPosition);
    }

    public static void PlayDefaultWarningSound(Vector3 sfxPosition)
    {
        if (Instance != null && Instance.DefaultWarningSound != null)
            PlayOneSFX(Instance.DefaultWarningSound, sfxPosition);
    }
    
    public static void PlayStartPreparingDrinkSound(Vector3 sfxPosition)
    {
        if (Instance != null && Instance.StartPreparingDrinkSound != null)
            PlayOneSFX(Instance.StartPreparingDrinkSound, sfxPosition);
    }
    
    public static void PlayFinishPreparingDrinkSound(Vector3 sfxPosition)
    {
        if (Instance != null && Instance.FinishPreparingDrinkSound != null)
            PlayOneSFX(Instance.FinishPreparingDrinkSound, sfxPosition);
    }
}
