using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public AudioSource audioSource;
    public Rigidbody projectilePrefab;
    //fire rate 
    [SerializeField] float fireRate = 1f;
    private float nextTimeToFire = 0f;

    //ammo system
    [SerializeField] int defaultAmmo = 6;
    [SerializeField] int currentAmmo;

    bool needReload;

    [SerializeField] Text ammoCounter;

    [SerializeField] ParticleSystem muzzleFlash;

    AudioSource aS;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo;

        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo <= 0)
        {
            needReload = true;
        }

        ammoCounter.text = currentAmmo.ToString();

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire && !needReload)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            currentAmmo--;
            muzzleFlash.Play();
            aS.Play();








            Rigidbody hitPlayer;
            hitPlayer = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
            hitPlayer.velocity = transform.TransformDirection(Vector3.forward * 100);
            //            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );






            for (var i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Rigidbody clone;
                    clone = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
                    clone.velocity = transform.TransformDirection(Vector3.forward * 200);
                    //            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );


                }
            }
        }



        











        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            audioSource.Play();
        }
    }

    void Reload()
    {
        currentAmmo = defaultAmmo;
        needReload = false;
    }
}
