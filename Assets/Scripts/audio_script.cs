using UnityEngine;

public class audio_script : MonoBehaviour
{

    AudioSource audiosrc;
    public static bool IsPaused;


    void Awake()
    {
        audiosrc = GetComponent<AudioSource>();
        IsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                audiosrc.Play();
                IsPaused = false;
            }
            else
            {
                audiosrc.Stop();
                IsPaused = true;
            }
        }
    }
}
