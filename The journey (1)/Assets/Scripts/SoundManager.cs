using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static AudioClip caminaSnd, lanzaHachaSnd, playerDamageSnd, disparoHachaSnd,
        muerteEnemySnd, hachazoSnd, chopSnd, plyrMuerte, jumpSnd, powUpSnd, stairsSnd, slimeDamSnd, slimeAtkSnd, slimeMuerteSnd,
        forestAmbSnd, CaveAmbSnd, doorSnd,switchSnd,spawnSnd;


    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerDamageSnd = Resources.Load<AudioClip>("playerDamage");
        lanzaHachaSnd = Resources.Load<AudioClip>("lanzaHacha");
        caminaSnd = Resources.Load<AudioClip>("camina");
        disparoHachaSnd = Resources.Load<AudioClip>("disparoHacha");
        muerteEnemySnd = Resources.Load<AudioClip>("muerteEnemy");
        hachazoSnd = Resources.Load<AudioClip>("hachazo");
        chopSnd = Resources.Load<AudioClip>("chop");
        plyrMuerte = Resources.Load<AudioClip>("PlyrMuerteWhilelm");
        jumpSnd = Resources.Load<AudioClip>("jump");
        powUpSnd = Resources.Load<AudioClip>("PowUp");
        stairsSnd = Resources.Load<AudioClip>("stairs");
        slimeDamSnd = Resources.Load<AudioClip>("slime_Daño");
        slimeAtkSnd = Resources.Load<AudioClip>("slime_Attack");
        slimeMuerteSnd = Resources.Load<AudioClip>("slime_Muerte");
        forestAmbSnd = Resources.Load<AudioClip>("Forest_Ambience");
        CaveAmbSnd = Resources.Load<AudioClip>("Cave_Ambience");
        doorSnd = Resources.Load<AudioClip>("door");
        switchSnd = Resources.Load<AudioClip>("switch");
        spawnSnd = Resources.Load<AudioClip>("spawn");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerDamage":
                audioSrc.PlayOneShot(playerDamageSnd);
                break;
            case "lanzaHacha":
                audioSrc.PlayOneShot(lanzaHachaSnd);
                break;
            case "camina":
                audioSrc.PlayOneShot(caminaSnd);
                break;
            case "disparoHacha":
                audioSrc.PlayOneShot(disparoHachaSnd);
                break;
            case "muerteEnemy":
                audioSrc.PlayOneShot(muerteEnemySnd);
                break;
            case "hachazo":
                audioSrc.PlayOneShot(hachazoSnd);
                break;
            case "chop":
                audioSrc.PlayOneShot(chopSnd);
                break;
            case "PlyrMuerteWhilelm":
                audioSrc.PlayOneShot(plyrMuerte);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSnd);
                break;
            case "PowUp":
                audioSrc.PlayOneShot(powUpSnd);
                break;
            case "stairs":
                audioSrc.PlayOneShot(stairsSnd);
                break;
            case "slime_Daño":
                audioSrc.PlayOneShot(slimeDamSnd);
                break;
            case "slime_Attack":
                audioSrc.PlayOneShot(slimeAtkSnd);
                break;
            case "slime_Muerte":
                audioSrc.PlayOneShot(slimeMuerteSnd);
                break;
            case "Forest_Ambience":
                audioSrc.PlayOneShot(forestAmbSnd);
                break;
            case "Cave_Ambience":
                audioSrc.PlayOneShot(CaveAmbSnd);
                break;
            case "door":
                audioSrc.PlayOneShot(doorSnd);
                break;
            case "esqueletoAttack":
                audioSrc.PlayOneShot(hachazoSnd);
                break;
            case "switch":
                audioSrc.PlayOneShot(switchSnd);
                break;
            case "spawn":
                audioSrc.PlayOneShot(spawnSnd);
                break;
        }
        
    }
    
}
