using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    [SerializeField] private GameObject bulletDecal;
    private float speed = 1f;
    private float timeToDestroy = 3f;

    [HideInInspector] public Vector3 target {get;set;}

    public bool hit {get;set;}


    private void Start()
    {
        Debug.Log("we created a bullet");
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(!hit && Vector3.Distance(transform.position, target) < .01f)
        {
             Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);
        GameObject.Instantiate(bulletDecal, contact.point, Quaternion.LookRotation(contact.normal));
        Destroy(gameObject);
    }
}
