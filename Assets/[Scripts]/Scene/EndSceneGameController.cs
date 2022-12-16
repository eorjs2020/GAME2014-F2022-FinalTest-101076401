//EndSceneGameController
//LastUpdate 22_12_15
//Daekoen_Lee 101076401
//Revision History
//First modified 22_12_15
//Description - EndSceneGameController - Control EndScene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SoundManager>().PlayMusic(Sound.END_MUSIC);
    }

}
