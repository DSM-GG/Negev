using System;
using System.Collections;
using UnityEditor;
using UnityEngine;


    public class Spell : MonoBehaviour
    {
        [SerializeField]
        protected bool isActive;
        
        [SerializeField]
        protected int bulletCount;
        
        [SerializeField]
        protected float speed;
        
        [SerializeField]
        protected GameObject bulletPrefab;
        
        protected WaitForSeconds intervalTime;
//
//        protected delegate void ShootAction();
//        protected static event ShootAction OnShoot;
//      
        protected virtual void Initialize()
        {
            intervalTime = new WaitForSeconds((1000 - speed) * 0.001f);
        }
        
        private void Start()
        {
            Initialize();
            StartCoroutine(ActionSpell());
        }

        public void TurnOn()
        {
            isActive = true;
        }

        public void TurnOff()
        {
            isActive = false;
        }
        
        protected virtual IEnumerator ActionSpell()
        {
            yield return null;
        }
    }