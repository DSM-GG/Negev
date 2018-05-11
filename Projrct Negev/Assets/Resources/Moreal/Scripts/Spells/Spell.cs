using System;
using System.Collections;
using UnityEngine;

namespace Resources.Moreal.Scripts.Spells
{
    public class Spell : MonoBehaviour
    {
        [SerializeField]
        protected bool isActive;
        protected int bulletCount;
        protected float speed;
        protected GameObject bulletPrefab;
        
        [SerializeField]
        protected WaitForSeconds intervalTime;

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
}