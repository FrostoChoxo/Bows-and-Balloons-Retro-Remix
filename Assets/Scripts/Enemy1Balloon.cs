using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Balloon : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed;

    private bool hit = false;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip popSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            transform.Translate(enemySpeed * -1 * Time.deltaTime, 0, 0);
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
