using UnityEngine.Audio;
using UnityEngine;

public class Audiomanager2 : MonoBehaviour
{
    public Sound[] sounds;
    //stores the number corresponding to which of the three songs should be played at any one time during gameplay. 1 and 2 are eerie, 3 is upbeat
    private int queueNumber;

    //Awake called before start
    void Awake()
    {
        //setting a random default queueNumber for the song to be played at start 
        queueNumber = Random.Range(1,3);
        //looping through each Sound object in the Sounds array
        foreach (Sound s in sounds){
            //create an audioSource component
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //void Start plays the sound on Start
    void Start()
    {
        play(sounds[queueNumber-1].name);
    }

    //PLAY METHOD
    public void play(string name){
        //stores the Sound with the audioSource to be played
        Sound toBePlayed;
        //finding sound with the appropriate name
        foreach (Sound s in sounds){
            //if sound is name
            if(s.name == name){
                toBePlayed = s;
                toBePlayed.source.Play();
                return;
            }
        }
        //at this point- the sound doesn't exist so throw error and return

    }
}
