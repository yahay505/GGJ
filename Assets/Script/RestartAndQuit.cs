using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Script
{
    public class RestartAndQuit : MonoBehaviour
    {
        public UnityEvent Died;

        private void Update()
        {
            if (FindObjectOfType<CardStateManager>().Money<0||FindObjectOfType<CardStateManager>().Popularity<0)
            {
Died.Invoke();

            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}