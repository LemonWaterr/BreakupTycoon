using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using NAudio.Wave;

namespace WAVTool
{
    class VoiceGenerator
    {
        public void Play()
        {
            var audioFile = new AudioFileReader("D:\\develop\\Breakup Tycoon\\Others\\resources\\track1.wav");
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(170);
            }
            audioFile.Dispose();
            outputDevice.Dispose();

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var path = Assembly.GetExecutingAssembly().Location;
            Console.WriteLine(path);
            var vg = new VoiceGenerator();
            vg.Play();
        }
    }
}
