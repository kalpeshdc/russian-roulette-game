using System.Media;

namespace DSD_01
{
    class Sound
    {
        public static void PlayFireBulletSound()
        {
            SoundPlayer player = new SoundPlayer("resources\\bullet.wav");
            player.Load();
            player.Play();
        }

        public static void PlayEmptyGunShotSound()
        {
            SoundPlayer player = new SoundPlayer("resources\\empty-gun-shot.wav");
            player.Load();
            player.Play();
        }

        public static void PlaySpinChamberSound()
        {
            SoundPlayer player = new SoundPlayer("resources\\spin-chamber.wav");
            player.Load();
            player.Play();
        }

        public static void PlayLoadGunSound()
        {
            SoundPlayer player = new SoundPlayer("resources\\gun-load.wav");
            player.Load();
            player.Play();
        }
    }
}
