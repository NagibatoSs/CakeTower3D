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
    class MusicButtonUIHandler: MonoBehaviour
    {
        [Inject] private MusicController musicController;
        [SerializeField] private Image image;
        [SerializeField] private Sprite spriteOn;
        [SerializeField] private Sprite spriteOff;

        private void OnEnable()
        {
            musicController.OnMusicStateChanged += UpdateImage;
            UpdateImage(musicController.IsMusicEnabled);
        }

        private void OnDisable()
        {
            musicController.OnMusicStateChanged -= UpdateImage;
        }

        private void UpdateImage(bool isEnabled)
        {
            image.sprite = isEnabled ? spriteOn : spriteOff;
        }
    }
}
