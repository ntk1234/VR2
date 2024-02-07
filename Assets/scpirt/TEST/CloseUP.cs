using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CloseUP : MonoBehaviour
    {
        public CharacterFloat CF;
        // Start is called before the first frame update
        void Start()
        {
            /*CF = GetComponent<CharacterFloat>();*/
        }

        // Update is called once per frame
        void Update()
        {

        }

        /* void OnCollisionEnter(Collider collision)

         {
             if (collision.gameObject.CompareTag("Player"))
             {
                 Debug.Log("CFON");

                 CF.isJump = false;

             }

         }

        void OnCollisionExit(Collision collision)
         {
             if (collision.gameObject.CompareTag("Player"))
             {

                 CF.isJump = true;
             }
         }*/
    }
}