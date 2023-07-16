using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    [SerializeField] private GameObject bulletDecal;
    private float speed = 1f;
    private float timeToDestroy = 3f;
    private float creationTime;
    private GameObject parent;
    private Collider ignoreCollisionWithThis;

    public float invulnerableTime = 1f;

    [HideInInspector] public Vector3 target {get;set;}

    public bool hit {get;set;}


    public void CustomStart(GameObject bulletParent, Collider rocketCollider)
    {
        ignoreCollisionWithThis = rocketCollider;
        parent = bulletParent;
        Destroy(gameObject, timeToDestroy);
        Physics.IgnoreCollision(GetComponent<Collider>(), ignoreCollisionWithThis, true);
        creationTime = Time.time;
        Debug.Log("created: " + Time.time);
        

    }

    void FixedUpdate()
    {
        if(Time.time - creationTime > invulnerableTime)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), ignoreCollisionWithThis, false);
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(!hit && Vector3.Distance(transform.position, target) < .01f)
        {
             Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided" + other.gameObject);
        ContactPoint contact = other.GetContact(0);
        GameObject.Instantiate(bulletDecal, contact.point, Quaternion.LookRotation(contact.normal));
        Destroy(gameObject);
    }
}
