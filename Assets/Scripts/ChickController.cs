using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class ChickController : MonoBehaviour
    {
        public float delay = 1f;
        private Animator ani;
        public float Speed = 8f;
        public bool IsWalking { get; set; }
        private Vector3 leavePosition;

        void Start()
        {
            ani = GetComponent<Animator>();
            Invoke(nameof(IMBirth), delay);
            leavePosition = new Vector3(-14f, transform.position.y, 0f);
        }

        void Update()
        {
            //判断边界，消失
            HandleIdle();
            if(IsWalking)
            {
                transform.position = Vector2.MoveTowards(transform.position, leavePosition, Speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, leavePosition) < 0.01f)
                {
                    Destroy(gameObject);
                }
            }
        }

        public void IMBirth()
        {
            ani.SetTrigger(chirpTriggerName);
            Invoke(nameof(Leave), 1.35f);
        }

        void Leave()
        {
            ani.SetTrigger("IsWalking");
            IsWalking = true;
        }

        void HandleIdle()
        {
            if (ani?.HasState(0, Animator.StringToHash("Idle")) == true)
            {
                SetRandomInterval();
            }
        }
        public string blinkTriggerName = "Blink";
        public string chirpTriggerName = "Chirp";
        private float timer = 0f;
        public float blinkInterval = 3f;
        void SetRandomInterval()
        {
            timer += Time.deltaTime;
            if (timer >= blinkInterval)
            {
                if (Random.value > 0.3)
                    ani.SetTrigger(blinkTriggerName);
                else
                    ani.SetTrigger(chirpTriggerName);
                timer = 0f;
                blinkInterval = Random.Range(3f, 6f);
            }
        }
    }
}
