using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Transform Player;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 2;
    private Animator anim;

    public AudioSource OpenDoorAudio;
    public float openDelay = 0f;
    public AudioSource CloseDoorAudio;
    public float closeDelay = 0f;

    private bool inside = true;
    public AudioClip[] outsideSteps;
    public AudioClip[] insideSteps;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        Player = GameObject.Find("shadow").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(Player.position, this.transform.position);

        if (distance < MaxDistance)
        {
            if (anim.GetBool("character_nearby") == false)
            {
                anim.SetBool("character_nearby", true);
                OpenDoorAudio.PlayDelayed(openDelay);
                if(inside)
                {
                    inside = false;
                    GameObject.Find("Outside_ambient").GetComponent<AudioSource>().Play();
                    GameObject.Find("Inside_ambient").GetComponent<AudioSource>().Stop();
                    GameObject.Find("shadow").GetComponent<StepSound>().footsteps = outsideSteps;
                }
                else
                {
                    inside = true;
                    GameObject.Find("Outside_ambient").GetComponent<AudioSource>().Stop();
                    GameObject.Find("Inside_ambient").GetComponent<AudioSource>().Play();
                    GameObject.Find("shadow").GetComponent<StepSound>().footsteps = insideSteps;
                }
            }
        }
        else
        {
            if (anim.GetBool("character_nearby") == true)
            {
                anim.SetBool("character_nearby", false);
                CloseDoorAudio.PlayDelayed(closeDelay);
            }
        }
    }
}
