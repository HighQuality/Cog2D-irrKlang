using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cog.Modules.Audio;

namespace IrrKlangModule
{
    class IrrKlangSoundInstance : ISoundInstance
    {
        internal IrrKlang.ISound InnerSound;

        public SoundEffect SoundEffect { get; private set; }
        public bool Paused { get { return InnerSound.Paused; } set { InnerSound.Paused = value; } }
        public float Volume { get { return InnerSound.Volume; } set { InnerSound.Volume = value; } }
        
        internal IrrKlangSoundInstance(IrrKlangSoundEffect sound, bool autoPlay)
        {
            SoundEffect = sound;
            InnerSound = IrrKlangAudioModule.Engine.Play2D(sound.InnerSound, false, !autoPlay, true);
        }

        public void Stop()
        {
            InnerSound.Stop();
            InnerSound.Dispose();
            InnerSound = null;
        }
    }
}
