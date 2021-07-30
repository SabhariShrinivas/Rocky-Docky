using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust = 0f;
    [SerializeField] float rotationthrust = 0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticle;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    private void ProcessThrust()

    {

        if (Input.GetKey(KeyCode.Space))
        {
            mainEngineParticle.Play();
            rb.AddRelativeForce(thrust * Time.deltaTime * Vector3.up);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(mainEngine);
        }
        else
            audioSource.Stop();

    }

    private void ProcessRotation()

    {

        if (Input.GetKey(KeyCode.A))

        {

            //rb.freezeRotation = false;

            transform.Rotate(rotationthrust * Time.deltaTime * Vector3.forward);

            //rb.freezeRotation = true;

        }

        else if (Input.GetKey(KeyCode.D))

        {



           // rb.freezeRotation = false;

            transform.Rotate(rotationthrust * Time.deltaTime * -Vector3.forward);

           // rb.freezeRotation = true;

        }

    }
}
