using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDown : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float timer = 0.5f;
    float time;
    [SerializeField] float force;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        time += Time.deltaTime;
        if (time >= timer)
        {
            Quaternion quaternion = Quaternion.Euler(0, 0, -90);
            GameObject arrow = Instantiate(arrowPrefab, (Vector2)transform.position + -Vector2.up * 0.5f, quaternion);
            ArrowShoot arrowShoot = arrow.GetComponent<ArrowShoot>();
            //arrowShoot.Shoot(-transform.up.x, -transform.up.y, speed);
            /*arrowShoot.Shoot(-transform.up, speed);*/
            arrowShoot.Shoot(-transform.up, force);
            audioManager.PlaySFX(audioManager.arrowShoot);
            time = 0;
        }
    }
}
