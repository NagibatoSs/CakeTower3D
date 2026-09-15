using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI
{
    public enum GameAudioType
    {
        Music,
        SFX
    }
    interface IAudioState
    {
        public event Action<bool> OnStateChanged;
        public bool IsEnabled { get; }
    }
}
