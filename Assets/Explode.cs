using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Explode : MonoBehaviour
{

    public Collider[] Box;

    void Update()
    {

        Box = Physics.OverlapSphere(this.transform.position, 10f);

    }

    private void OnCollisionEnter(Collision collision)

    {


        foreach (Collider hit in Box)

        {

            Rigidbody rb = hit.GetComponent<Rigidbody>();


            if (rb != null)

                rb.AddExplosionForce(2000f, this.transform.position, 2000f);

        }


        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        this.gameObject.GetComponent<SphereCollider>().enabled = false;

    }

}