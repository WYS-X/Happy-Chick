using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChickController : MonoBehaviour
    {
        public float delay = 6f;
        private Animator ani;
        public bool IsWalking { get; set; }

        void Start()
        {
            ani = GetComponent<Animator>();
            Invoke(nameof(Paly), delay);
        }

        private void Update()
        {
            //判断边界，消失
        }

        public void Paly()
        {
            
        }
    }
}
