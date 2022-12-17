using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FootStep : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;

    public AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Thats the Animation Event
    public void SE_Steps()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        return audioClip[index];
    }

}
