/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class SoundManager : MonoBehaviour
    {
        public AudioClip[] jumpSounds;
        public AudioClip[] rightFootSteps;
        public AudioClip[] leftFootSteps;
        public AudioClip landing;
        public AudioClip diveBuildup;
        public AudioClip hardLanding;
        public AudioClip shootableEquip;
        public AudioClip shoot;
        public AudioClip[] meleeSwings;
        public AudioClip meleeEquip;
        public AudioClip meleeSheath;
        public AudioClip click;
        public AudioClip select;

        public static SoundManager Instance;

        [SerializeField]
        private AudioSource audioSource = null;
        [SerializeField]
        private AudioSource footStepsAudio = null;
        [SerializeField]
        private float minPitch = 0f;
        [SerializeField]
        private float maxPitch = 1f;
        [SerializeField]
        private float maxSpeed = 200f;
        [SerializeField]
        private float minVolume = 0.05f;
        [SerializeField]
        private float maxFootstepVolume = 0.1f;

        private float defaultPitch;
        private bool rightStep;
        private AudioClip footStepSfx;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            defaultPitch = audioSource.pitch;
        }

        public void StopPlaying()
        {
            audioSource.Stop();
        }

        public void PlaySound(AudioClip[] array)
        {
            audioSource.PlayOneShot(array[Random.Range(0, array.Length)]);
        }

        public void PlayFootSteps(float speed)
        {
            footStepsAudio.pitch = Mathf.Max(speed / maxSpeed, minPitch);
            if (footStepsAudio.isPlaying)
            {
                return;
            }

            if (rightStep)
            {
                footStepSfx = rightFootSteps[Random.Range(0, rightFootSteps.Length)];
                rightStep = false;
            }
            else
            {
                footStepSfx = leftFootSteps[Random.Range(0, leftFootSteps.Length)];
                rightStep = true;
            }
            footStepsAudio.PlayOneShot(footStepSfx, Mathf.Max(maxFootstepVolume * speed / maxSpeed, minVolume));
        }

        public void PlaySound(AudioClip clip, bool randomPitch = false)
        {
            audioSource.pitch = randomPitch ? Random.Range(minPitch, maxPitch) : defaultPitch;
            audioSource.PlayOneShot(clip);
        }
    }
}
