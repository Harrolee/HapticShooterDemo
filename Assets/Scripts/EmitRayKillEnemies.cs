using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitRayKillEnemies : MonoBehaviour {

    public Quaternion gunRotation;
    public GameObject bulletObject;
    public AudioClip bulletSound;
    [Range(0.0f, 1.0f)]
    public float bulletSoundVolume = 1;
    //public GameObject muzzleFlash;
    Transform bulletSpawn;

    private AudioSource _audioSource;
    public ParticleSystem _particleSystem;
    public int damage = 50;
    public float bulletSpeed = 1000;


	void Start ()
    {
        _audioSource = GetComponent<AudioSource>();
        //_particleSystem = GetComponent<ParticleSystem>();
        //Debug.Log("_particleSystem -= " + _particleSystem);
	}
	
	void Update ()
    {
        bulletSpawn = transform;
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootNow();
        }
	}

    public void ShootNow ()
    {
        print("shootin");
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.yellow);

        GameObject bullet = (GameObject)(Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation)); //fireRotation

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, bulletSpeed))
        {
            Debug.Log("ray hit = " + hit.transform.gameObject.name);
            hit.collider.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
        }

        _audioSource.Play();
        //_particleSystem.Emit(120);
    }


    /*
    void FireOneShot()
    {
        //Look At Target
        if (targetTransform && !myAIBaseScript.inParkour)
        {
            //Snap our aim to the target even if we're aiming slightly off
            //This is because the RotateToAimGunScript will rarely point directly at the target- merely close enough
            bool amAtTarget = Vector3.Angle(bulletSpawn.forward, targetTransform.position - bulletSpawn.position) < maxFiringAngle;

            //Fire Shot
            //Most bullets will have one bullet.  However, shotguns and similar weapons will have more.
            for (int j = 0; j < pelletsPerShot; j++)
            {
                if (amAtTarget)
                {
                    fireRotation.SetLookRotation(targetTransform.position - bulletSpawn.position);
                }
                else
                {
                    fireRotation = Quaternion.LookRotation(bulletSpawn.forward);
                }

                //Modify our aim by a random amound to simulate inaccuracy.
                fireRotation *= Quaternion.Euler(Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy), 0);

                GameObject bullet = (GameObject)(Instantiate(bulletObject, bulletSpawn.position, fireRotation));
                //If this is using the TacticalAI Bullet Script and is a rocket launcher
                if (isRocketLauncher && bullet.GetComponent<TacticalAI.BulletScript>())
                {
                    bullet.GetComponent<TacticalAI.BulletScript>().SetAsHoming(targetTransform);
                }
            }

            //Play the sound that is audible by the player
            if (bulletSound)
            {
                audioSource.volume = bulletSoundVolume;
                audioSource.PlayOneShot(bulletSound);
            }

            if (animationScript)
            {
                animationScript.PlayFiringAnimation();
            }

            //Createthe muzzle flash and then destroy it after a given amount of time
            if (muzzleFlash)
            {
                GameObject flash = (GameObject)(Instantiate(muzzleFlash, muzzleFlashSpawn.position, muzzleFlashSpawn.rotation));
                flash.transform.parent = muzzleFlashSpawn;
                GameObject.Destroy(flash, flashDestroyTime);
            }
        }
    }


*/

}
