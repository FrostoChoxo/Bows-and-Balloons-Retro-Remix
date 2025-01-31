using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public Image deathscreen;
    public GameObject[] hearts;
    public int life;
    private bool dead;

    public AudioSource audioSource;
    public AudioClip popSound;

    public AudioSource bgmusic;
    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Length;
        //Reset time scale when game restarts
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            //Death Screen
            deathscreen.gameObject.SetActive(true);
            //Freeze Time when dead
            Time.timeScale = 0f;
            //Stop game music
            bgmusic.Stop();
        }
    }

    public void takeDamamge(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            //Debug.Log("Damage");
            if (life < 1)
            {
                dead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //Debug.Log("Hit");
            audioSource.PlayOneShot(popSound);
            takeDamamge(1);
            Destroy(collision.gameObject, 1.0f);
        }
    }
}
