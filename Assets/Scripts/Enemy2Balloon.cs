using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Balloon : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed;

    [SerializeField]
    private float bobbingAmplitude = 0.5f;

    [SerializeField]
    private float bobbingFrequency = 1f;

    private bool hit = false;
    public Animator animator;
    private float initialY;
    private float phaseOffset;
    public AudioSource audioSource;
    public AudioClip popSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        initialY = transform.position.y;

        //Generate random Y offset for each enemy
        phaseOffset = Random.Range(0f, 2f * Mathf.PI);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            //Translate Enemy forward
            transform.Translate(enemySpeed * -1 * Time.deltaTime, 0, 0);

            //Bobbing action using sin wave with offset
            float newY = initialY + Mathf.Sin(Time.time * bobbingFrequency + phaseOffset) * bobbingAmplitude;

            //Apply new Y pos
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

      
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            animator.Play("EnemyDeath");
            hit = true;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(popSound);
        }
    }
}
