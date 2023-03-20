using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        // time duration
        float totalSeconds = 0;

        //timer execution
        float elapsedSeconds = 0;
        bool running = false;

        //support for finished 
        bool started = false;

        public float Duration
        {
            set
            {
                if (!running)
                {
                    totalSeconds = value;
                }
            }
            get
            {
                return totalSeconds;
            }
        }

        public bool Finished
        {
            get
            {
                return started && !running;
            }
        }

        public bool Running
        {
            get
            {
                return running;
            }
        }

        public void run()
        {
            if (totalSeconds > 0)
            {
                started = true;
                running = true;
                elapsedSeconds = 0;
            }
            else
            {
                running = false;
            }
        }

        private void Update()
        {
            if (running)
            {
                elapsedSeconds += Time.deltaTime;
                if (elapsedSeconds >= totalSeconds)
                {
                    running = false;
                }
            }
        }
    }
}
