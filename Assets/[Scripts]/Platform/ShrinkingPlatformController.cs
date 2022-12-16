//ShrinkingPlatformController
//LastUpdate 22_12_15
//Daekoen_Lee 101076401
//Revision History
//First modified 22_12_15
//Description - ShrinkingPlatformController - Player is collliding with this platform will be shrinink and colliding end it we be expand until orinial scale
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    public bool isActive;
    public float platformTimer;    
    private Vector3 orignalPos;
    public Transform platform;
    public Vector3 scale;
    private bool expand;
    public float waitingTime;
    private bool isShrinking = false;
    private bool isDisapear = false;
    private void Start()
    {
        scale = platform.localScale;
        orignalPos = transform.position;
        Invoke("Floating", 1f);
        expand = false;
        //audio = GetComponent<AudioSource>();
    }

    void Update()
    {
              
        if(isActive)
        {
            Shrinking();           
        }
        else
        {
            if (expand)
                Expand();
            else
                platformTimer += Time.deltaTime;
            if (platformTimer > waitingTime)
            {
                expand = true;
                platformTimer = 0;
            }
            
        }
        Floating();
    }
    private void Reset()
    {
        scale.x = 1;
        transform.position = orignalPos;
    }

    void Shrinking()
    {
        //audio.clip = clip[0];
        if (scale.x >= 0.2f)
        {
            scale.x -= Time.deltaTime;
        }
        else
        {
            scale.x = 0;
            platform.gameObject.SetActive(false);
        }
        
        platform.localScale = scale;
        expand = false;

        if (!SoundManager.Instance.channels[(int)Channel.PLATFORM_FX].isPlaying && !isShrinking)
        {
            SoundManager.Instance.PlaySoundFX(Sound.SHRINKING, Channel.PLATFORM_FX);
            isShrinking = true;
        }
    }

  

    void Expand()
    {
        platform.gameObject.SetActive(true);
        var check = (scale.x < 1) ? scale.x += Time.deltaTime : scale.x = 1;
        platform.localScale = scale;
        isShrinking = false;
        if (!SoundManager.Instance.channels[(int)Channel.PLATFORM_FX].isPlaying && scale.x != 1)
        {
            SoundManager.Instance.PlaySoundFX(Sound.EXPAND, Channel.PLATFORM_FX);
        }
    }

    void Floating()
    {
        transform.position = new Vector3(transform.position.x, orignalPos.y + Mathf.PingPong(Time.time * 0.2f, 0.2f), 0.0f);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = false;

        }
    }

}
