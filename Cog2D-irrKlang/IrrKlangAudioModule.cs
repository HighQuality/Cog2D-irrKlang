using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cog.Modules.Audio;

namespace IrrKlangModule
{
    public class IrrKlangAudioModule : IAudioModule
    {
        internal static IrrKlang.ISoundEngine Engine;

        public IrrKlangAudioModule()
        {
            if (Engine != null)
                throw new InvalidOperationException("IrrKlangAudioModule has already been initialized!");
            Engine = new IrrKlang.ISoundEngine(IrrKlang.SoundOutputDriver.AutoDetect, IrrKlang.SoundEngineOptionFlag.MultiThreaded);
        }

        public SoundEffect Load(byte[] data)
        {
            return new IrrKlangSoundEffect(data);
        }

        public SoundEffect Load(string file)
        {
            return new IrrKlangSoundEffect(file);
        }
    }
}
