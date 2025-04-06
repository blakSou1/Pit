using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    InputSystem_Actions inp;
    Animator anim;
    bool ispit;
    AudioSource[] au;
    bool click;
    bool audi = true;

    void Start()
    {
        au = GetComponents<AudioSource>();
        inp = new();

        inp.Player.Attack.performed += i => click = true;
        inp.Player.Attack.canceled += i => click = false;

        inp.Enable();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (click)
        {
            if (audi)
            {
                au[Random.Range(0, au.Length)].Play();
                audi = false;
                anim.Play("pit");
                StartCoroutine(time());
            }
        }
        else
        {
            anim.Play("nopit");
            foreach (AudioSource source in au)
            {
                source.Stop();
            }
        }
    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(1);
        audi = true;
    }
}
