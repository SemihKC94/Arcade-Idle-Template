using UnityEngine;
public class SoundFXManager : MonoBehaviour
{
    public AudioClip[] jumpSounds;
    public AudioClip[] rightFootSteps;
    public AudioClip[] leftFootSteps;
    public AudioClip click;
    public AudioClip gather;
    public AudioClip pickUp;
    public AudioClip pickDown;

    public static SoundFXManager Instance;

    [SerializeField]
    private AudioSource audioSource = null;
    [SerializeField]
    private AudioSource footStepsAudio = null;
    [SerializeField]
    private float minPitch = 0f;
    [SerializeField]
    private float maxPitch = 1f;
    [SerializeField]
    private float maxSpeed = 200f;
    [SerializeField]
    private float minVolume = 0.05f;
    [SerializeField]
    private float maxFootstepVolume = 0.1f;

    private float defaultPitch;
    private bool rightStep;
    private AudioClip footStepSfx;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        defaultPitch = audioSource.pitch;
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }

    public void PlaySound(AudioClip[] array)
    {
        audioSource.PlayOneShot(array[Random.Range(0, array.Length)]);
    }

    public void PlayFootSteps(float speed)
    {
        footStepsAudio.pitch = Mathf.Max(speed / maxSpeed, minPitch);
        if (footStepsAudio.isPlaying)
        {
            return;
        }

        if (rightStep)
        {
            footStepSfx = rightFootSteps[Random.Range(0, rightFootSteps.Length)];
            rightStep = false;
        }
        else
        {
            footStepSfx = leftFootSteps[Random.Range(0, leftFootSteps.Length)];
            rightStep = true;
        }
        footStepsAudio.PlayOneShot(footStepSfx, Mathf.Max(maxFootstepVolume * speed / maxSpeed, minVolume));
    }

    public void PlaySound(AudioClip clip, bool randomPitch = false)
    {
        audioSource.pitch = randomPitch ? Random.Range(minPitch, maxPitch) : defaultPitch;
        audioSource.PlayOneShot(clip);
    }
}