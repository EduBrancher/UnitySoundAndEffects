using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] ParticleSystem smokeParticles;
    [SerializeField] ParticleSystem dirtParticles;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip crashSound;

    AudioSource audioSource;
    Rigidbody rb;
    Animator anim;
    
    Vector3 baseGravity;
    bool isGrounded;
    bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        baseGravity = Physics.gravity;
    }



    // Update is called once per frame
    void Update()
    {
        if (isDead) {
            return;
        }
        var jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            isGrounded = false;
            dirtParticles.Stop();
            audioSource.PlayOneShot(jumpSound);
        }
        //So we can calibrate gravity easily in the editor
        Physics.gravity = baseGravity * gravityModifier;
    }

    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            dirtParticles.Play();
        }

        if (other.gameObject.CompareTag("Obstacle")) {
            Debug.Log("Game Over!");
            EventHub.RaisePlayerGameOver();
            isDead = true;
            anim.SetBool("Death_b", isDead);
            anim.SetInteger("DeathType_int", 1);
            smokeParticles.Play();
            dirtParticles.Stop();
            audioSource.PlayOneShot(crashSound, 0.5f);
            Destroy(other.gameObject, 0.2f);
            //Destroy(gameObject);
        }
    }
}
