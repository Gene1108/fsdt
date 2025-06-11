using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] footsteps;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    GameObject distantObject;
    // Start is called before the first frame update
void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //audioSource.Play();
            //int randomIndex = Random.Range(0, footsteps.Length);
            //audioSource.PlayOneShot(footsteps[randomIndex]);
            AudioSource.PlayClipAtPoint(clip,distantObject.transform.position);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSource.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioSource.Stop();
        };
    }
}     