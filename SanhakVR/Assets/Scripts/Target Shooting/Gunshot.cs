using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public float speed = 40f;
    public GameObject bullet;
    public Transform bulletHole;
    private AudioSource audioSource;
    public AudioClip audioClip;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, bulletHole.position, bulletHole.rotation);

        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * bulletHole.forward;

        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 5);
    }
}
