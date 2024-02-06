using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man : MonoBehaviour
{
    public float speedForward;
    public float speedBackward;
    private bool isPractising;
    private bool isMoving;

    private Animator animator;
    private Vector3 previousPosition;
    public float animationSpeed = 1.0f;

    public AudioClip[] pleasureSounds;
    public AudioClip[] practiseSounds;
    public AudioClip footSound;
    public AudioClip breathSound;
    private AudioSource audioSource;

    private Vector3 velocity;

    private SpriteRenderer Square;

    public float timerRest = 20.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;

        audioSource = GetComponent<AudioSource>(); 
    }


    void Update()
    {
        timerRest -= Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speedForward * Time.deltaTime, 0, 0);
            isMoving = true;
            audioSource.clip = footSound;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-speedBackward * Time.deltaTime, 0, 0);
            isMoving = true;

            if (!audioSource.isPlaying)
            {
                audioSource.clip = pleasureSounds[Random.Range(0, pleasureSounds.Length)];
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
            audioSource.Stop();
        }
        
        if ((isMoving == false) && (Input.GetKey(KeyCode.Space)) && (isPractising != true))
        {
            audioSource.PlayOneShot(practiseSounds[Random.Range(0, practiseSounds.Length)]);
            isPractising = true;
        }

        if ((isPractising == true) && (Input.GetKey(KeyCode.R)) && (timerRest < 0))
        {
            audioSource.clip = breathSound;
            audioSource.PlayOneShot(audioSource.clip);
           isPractising = false;
            timerRest = 20.0f;
        }

        AnimatorSpeed();
    }

    void AnimatorSpeed()
    {
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        float speed = velocity.magnitude;
        previousPosition = transform.position;

        animator.speed = speed * animationSpeed;
    }
}
