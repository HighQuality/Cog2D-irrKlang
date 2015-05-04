using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cog.Modules.Audio;

namespace IrrKlangModule
{
    class IrrKlangSoundEffect : SoundEffect
    {
        internal IrrKlang.ISoundSource InnerSound;

        public IrrKlangSoundEffect(byte[] data)
        {
            InnerSound = IrrKlangAudioModule.Engine.AddSoundSourceFromMemory(data, Guid.NewGuid().ToString());
        }

        public IrrKlangSoundEffect(string file)
        {
            InnerSound = IrrKlangAudioModule.Engine.AddSoundSourceFromFile(file);
        }

        public override ISoundInstance Play()
        {
            return new IrrKlangSoundInstance(this, true);
        }

        public override ISoundInstance CreateInstance()
        {
            return new IrrKlangSoundInstance(this, false);
        }

        ~IrrKlangSoundEffect()
        {
            Dispose(false);
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        private void Dispose(bool disposed)
        {
            if (disposed)
            {
                InnerSound.Dispose();
                InnerSound = null;
            }
        }
    }
}
