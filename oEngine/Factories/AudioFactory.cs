using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using oEngine.Common;

namespace oEngine.Factories
{
    public sealed class AudioFactory : IFactory
    {
        private SoundEffectInstance[] playingSounds = new SoundEffectInstance[Consts.MaxSounds];       
                
        private bool isMuteSounds;
        private bool isMuteSongs;

        private IDictionary<string, SoundEffect> soundEffects = new Dictionary<string, SoundEffect>();

        private IDictionary<string, Song> songs = new Dictionary<string, Song>();

        public Song CurrentSong { get; private set; }

        public ContentManager Content;

        public float MusicVolume
        {
            get { return MediaPlayer.Volume; }
            set { MediaPlayer.Volume = value; }
        }

        public float SoundVolume
        {
            get { return SoundEffect.MasterVolume; }
            set { SoundEffect.MasterVolume = value; }
        }

        public bool MuteSounds
        {
            get { return isMuteSounds; }
            set
            {
                if (isMuteSounds == value)
                    return;

                isMuteSounds = value;

                if (value)
                    StopSounds(true);
            }
        }

        public void AddSong(string name)
        {
            if (Content == null)
                return;

            if(!songs.ContainsKey(name))
            {
                songs.Add(name, Content.Load<Song>("Audio/Songs/" + name));
            }
        }

        public void AddSoundEffect(string name)
        {
            if (Content == null)
                return;

            if (!soundEffects.ContainsKey(name))
            {
                soundEffects.Add(name, Content.Load<SoundEffect>("Audio/SoundEffects/" + name));
            }
        }     
        

        public void LoadDirectory(string path)
        {

        }

        public void PlaySound(string soundName, float volume = 1.0f, float pitch = 0.0f, float pan = 0.0f)
        {
            if (MuteSounds)
                return;

            // If there is no spot available do not play sound.
            // We dont want to cut the first sound being played to make room for the newest sound as this will produce cut off sounds. (es malo)

            int index = GetFirstIndex();

            if (index < 0)
                return;

            SoundEffect sound;

            if (!soundEffects.TryGetValue(soundName, out sound))
                return;

            playingSounds[index] = sound.CreateInstance();
            playingSounds[index].Volume = volume;
            playingSounds[index].Pitch = pitch;
            playingSounds[index].Pan = pan;
            playingSounds[index].Play();

            // check for paused sound state
            // useful for when created sounds shouldnt be played until in a resumed state?
            // iono

        }

        public void PauseSounds()
        {
            playingSounds.ForEach(sound =>
            {
                if (sound != null)
                    if (sound.State == SoundState.Playing)
                        sound.Pause();
            });
        }

        public void UnPauseSounds()
        {
            playingSounds.ForEach(sound =>
            {
                if (sound != null)
                    if (sound.State == SoundState.Paused)
                        sound.Resume();
            });
        }

        public void StopSounds(bool immediate)
        {
            playingSounds.ForEach(sound =>
            {
                if (sound != null)
                    sound.Stop(immediate);
            });
        }

        public void PauseMusic()
        {

        }

        public void UnloadContent()
        {
            soundEffects.Clear();
            songs.Clear();
        }

        /// <summary>
        /// Gets first available spot in playing sounds collection
        /// </summary>
        /// <returns></returns>
        private int GetFirstIndex()
        {
            return playingSounds.ToList().FindIndex(i => (i == null));
        }

        // pause song
        // play song w||wo loop
        // play sound effect
        // limit number of sound effects
        // unpause song
        // stop song
        // stop all sound effects
        // create a queue perhaps for sounds to be added to soundeffectinstances to only play max amount of sounds at once
    }
}
