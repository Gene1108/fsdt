using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomSoundManager : MonoBehaviour {
 
    [SerializeField] 
    AudioClip[] audioClips;
 
    AudioSource audioSource;

    public int avoidRepeat;
    public float pitchRange = 0;
    List<int> lastPlayed = new List<int>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound()
    {
        int randIndex = Random.Range(0, audioClips.Length);
        if(lastPlayed.Count < audioClips.Length)
        {
            while (lastPlayed.Contains(randIndex)) 
            {
                randIndex = Random.Range(0, audioClips.Length);
            }
        }
        
        if (lastPlayed.Count == avoidRepeat)
        {
            if (lastPlayed.Count > 0) 
            {
                lastPlayed.RemoveAt(0);
            }
            
        }
        lastPlayed.Add(randIndex);
        audioSource.pitch = pitchRange != 0 ? Random.Range(1f - pitchRange, 1f + pitchRange) : 1f;
        audioSource.PlayOneShot(audioClips[randIndex]);
    }
    
}
