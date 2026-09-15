using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    class AudioButtonUIHandler: MonoBehaviour
    {
        [SerializeField] private GameAudioType audioType;
        public GameAudioType AudioType => audioType;
        [SerializeField] private Image image;
        [SerializeField] private Sprite spriteOn;
        [SerializeField] private Sprite spriteOff;

        private IAudioState audioStateController;

        [Inject]
        private void Construct(IAudioState audioState)
        {
            audioStateController = audioState;
        }
        private void OnEnable()
        {
            audioStateController.OnStateChanged += UpdateImage;
            UpdateImage(audioStateController.IsEnabled);
        }

        private void OnDisable()
        {
            audioStateController.OnStateChanged -= UpdateImage;
        }

        private void UpdateImage(bool isEnabled)
        {
            image.sprite = isEnabled ? spriteOn : spriteOff;
        }
    }
}
