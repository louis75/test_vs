using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VESS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            init_all_sound_volumes();
            init_sound1();
            init_sound2();
            init_sound3();
            init_sound4();
            init_sound5();
            init_sound6();
            
            //m_AudioStreams = new Stream[(int)WaveSrc.SOUND_MAX];
        }

        private WaveLib.WaveOutPlayer m_Player;
        private WaveLib.WaveFormat m_Format;
        private Stream m_AudioStream;
        private System.Windows.Forms.OpenFileDialog OpenDlg;

        private void Filler(IntPtr data, int size)
        {
            byte[] b = new byte[size];
            if (m_AudioStream != null)
            {
                int pos = 0;
                while (pos < size)
                {
                    int toget = size - pos;
                    int got = m_AudioStream.Read(b, pos, toget);
                    if (got < toget)
                        m_AudioStream.Position = 0; // loop if the file ends
                    pos += got;
                }
            }
            else
            {
                for (int i = 0; i < b.Length; i++)
                    b[i] = 0;
            }
            System.Runtime.InteropServices.Marshal.Copy(b, 0, data, size);
        }

        private void Stop()
        {
            if (m_Player != null)
                try
                {
                    m_Player.Dispose();
                }
                finally
                {
                    m_Player = null;
                }
        }

        private void Play()
        {
            Stop();
            if (m_AudioStream != null)
            {
                m_AudioStream.Position = 0;
                m_Player = new WaveLib.WaveOutPlayer(-1, m_Format, 16384, 3, new WaveLib.BufferFillEventHandler(Filler));
            }
        }

        private void CloseFile()
        {
            Stop();
            if (m_AudioStream != null)
                try
                {
                    m_AudioStream.Close();
                }
                finally
                {
                    m_AudioStream = null;
                }
        }

        public enum WaveSrc { SOUND1, SOUND2, SOUND3, SOUND4, SOUND5, SOUND6, SOUND_MAX };
        private void OpenWaveFile(int num, ref string filename, string txtsavefilename)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                Debug.WriteLine("sound source: " + filename);
                CloseFile();
                try
                {
                    WaveLib.WaveStream S = new WaveLib.WaveStream(filename);
                    if (S.Length <= 0)
                        throw new Exception("Invalid WAV file");
                    m_Format = S.Format;
                    if (m_Format.wFormatTag != (short)WaveLib.WaveFormats.Pcm && m_Format.wFormatTag != (short)WaveLib.WaveFormats.Float)
                        throw new Exception("Only PCM files are supported");

                    m_AudioStream = S;
                }
                catch (Exception ex)
                {
                    CloseFile();
                    MessageBox.Show(ex.Message);
                }
                Debug.WriteLine("m_Format.wBitsPerSample:" + m_Format.wBitsPerSample.ToString());
                Debug.WriteLine("m_Format.nChannels:" + m_Format.nChannels.ToString());
                Debug.WriteLine("m_Format.nSamplesPerSec:" + m_Format.nSamplesPerSec.ToString());
                Debug.WriteLine("m_Format.wFormatTag:" + m_Format.wFormatTag.ToString());
                byte[] buffer = new byte[m_AudioStream.Length];
                int read = m_AudioStream.Read(buffer, 0, buffer.Length);
                short[] sampleBuffer = new short[read / 2];
                Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);

                Debug.WriteLine(sampleBuffer.Length.ToString() + " " + sampleBuffer[0].ToString("X4"));
                saveAsciiFromWav(sampleBuffer, txtsavefilename);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Debug.WriteLine("sound1 button click");
            Debug.Flush();

            OpenWaveFile((int)WaveSrc.SOUND1, ref sound1_filename, "test1.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("sound2 button click");
            Debug.Flush();
            OpenWaveFile((int)WaveSrc.SOUND2, ref sound2_filename, "test2.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("sound3 button click");
            Debug.Flush();
            OpenWaveFile((int)WaveSrc.SOUND3, ref sound3_filename, "test3.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("sound4 button click");
            Debug.Flush();
            OpenWaveFile((int)WaveSrc.SOUND4, ref sound4_filename, "test4.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("sound5 button click");
            Debug.Flush();
            OpenWaveFile((int)WaveSrc.SOUND5, ref sound5_filename, "test5.txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("sound6 button click");
            Debug.Flush();
            OpenWaveFile((int)WaveSrc.SOUND6, ref sound6_filename, "test6.txt");
        }


        private void textBox_s1_1_TextChanged(object sender, EventArgs e)
        {
        }

        private void trackBar_s1_1_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s1_1, ref textBox_s1_1);
            update_volumes(trackBar_s1_1, 0, 0);
        }

        private void trackBar_s1_2_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s1_2, ref textBox_s1_2);
            update_volumes(trackBar_s1_2, 0, 1);
        }

        private void trackBar_s1_3_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s1_3, ref textBox_s1_3);
            update_volumes(trackBar_s1_3, 0, 2);
        }

        private void trackBar_s1_5_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s1_5, ref textBox_s1_5);
            update_volumes(trackBar_s1_5, 0, 4);
        }

        private void trackBar_s1_4_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s1_4, ref textBox_s1_4);
            update_volumes(trackBar_s1_4, 0, 3);
        }

        private void trackBar_s1_6_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s1_6, ref textBox_s1_6);
            update_volumes(trackBar_s1_6, 0, 5);
        }

        private void trackBar_s1_7_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s1_7, ref textBox_s1_7);
            update_volumes(trackBar_s1_7, 0, 6);
        }

        private void trackBar_s2_7_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s2_7, ref textBox_s2_7);
            update_volumes(trackBar_s2_7, 1, 6);
        }

        private void trackBar_s2_2_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s2_2, ref textBox_s2_2);
            update_volumes(trackBar_s2_2, 1, 1);
        }

        private void trackBar_s2_3_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s2_3, ref textBox_s2_3);
            update_volumes(trackBar_s2_3, 1, 2);
        }

        private void trackBar_s2_4_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s2_4, ref textBox_s2_4);
            update_volumes(trackBar_s2_4, 1, 3);
        }

        private void trackBar_s2_5_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s2_5, ref textBox_s2_5);
            update_volumes(trackBar_s2_5, 1, 4);
        }

        private void trackBar_s2_6_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s2_6, ref textBox_s2_6);
            update_volumes(trackBar_s2_6, 1, 5);
        }

        private void trackBar_s2_1_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s2_1, ref textBox_s2_1);
            update_volumes(trackBar_s2_1, 1, 0);
        }

        private void trackBar_s3_1_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_1, ref textBox_s3_1);
            update_volumes(trackBar_s3_1, 2, 0);
        }

        private void trackBar_s3_2_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_2, ref textBox_s3_2);
            update_volumes(trackBar_s3_2, 2, 1);
        }

        private void trackBar_s3_3_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_3, ref textBox_s3_3);
            update_volumes(trackBar_s3_3, 2, 2);
        }

        private void trackBar_s3_4_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_4, ref textBox_s3_4);
            update_volumes(trackBar_s3_4, 2, 3);
        }

        private void trackBar_s3_5_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_5, ref textBox_s3_5);
            update_volumes(trackBar_s3_5, 2, 4);
        }

        private void trackBar_s3_6_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_6, ref textBox_s3_6);
            update_volumes(trackBar_s3_6, 2, 5);
        }

        private void trackBar_s3_7_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_7, ref textBox_s3_7);
            update_volumes(trackBar_s3_7, 2, 6);
        }

        private void trackBar_s3_8_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_8, ref textBox_s3_8);
            update_volumes(trackBar_s3_8, 2, 7);
        }

        private void trackBar_s3_9_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_9, ref textBox_s3_9);
            update_volumes(trackBar_s3_9, 2, 8);
        }

        private void trackBar_s3_10_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s3_10, ref textBox_s3_10);
            update_volumes(trackBar_s3_10, 2, 9);
        }

        private void trackBar_s4_1_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_1, ref textBox_s4_1);
            update_volumes(trackBar_s4_1, 3, 0);
        }

        private void trackBar_s4_2_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_2, ref textBox_s4_2);
            update_volumes(trackBar_s4_2, 3, 1);
        }

        private void trackBar_s4_3_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_3, ref textBox_s4_3);
            update_volumes(trackBar_s4_3, 3, 2);
        }

        private void trackBar_s4_4_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_4, ref textBox_s4_4);
            update_volumes(trackBar_s4_4, 3, 3);
        }

        private void trackBar_s4_5_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_5, ref textBox_s4_5);
            update_volumes(trackBar_s4_5, 3, 4);
        }

        private void trackBar_s4_6_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_6, ref textBox_s4_6);
            update_volumes(trackBar_s4_6, 3, 5);
        }

        private void trackBar_s4_7_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_7, ref textBox_s4_7);
            update_volumes(trackBar_s4_7, 3, 6);
        }

        private void trackBar_s4_8_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_8, ref textBox_s4_8);
            update_volumes(trackBar_s4_8, 3, 7);
        }

        private void trackBar_s4_9_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_9, ref textBox_s4_9);
            update_volumes(trackBar_s4_9, 3, 8);
        }

        private void trackBar_s4_10_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_10, ref textBox_s4_10);
            update_volumes(trackBar_s4_10, 3, 9);
        }

        private void trackBar_s4_11_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_11, ref textBox_s4_11);
            update_volumes(trackBar_s4_11, 3, 10);
        }

        private void trackBar_s4_12_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_12, ref textBox_s4_12);
            update_volumes(trackBar_s4_12, 3, 11);
        }

        private void trackBar_s4_13_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_13, ref textBox_s4_13);
            update_volumes(trackBar_s4_13, 3, 12);
        }

        private void trackBar_s4_14_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_14, ref textBox_s4_14);
            update_volumes(trackBar_s4_14, 3, 13);
        }

        private void trackBar_s4_15_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_15, ref textBox_s4_15);
            update_volumes(trackBar_s4_15, 3, 14);
        }

        private void trackBar_s4_16_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_16, ref textBox_s4_16);
            update_volumes(trackBar_s4_16, 3, 15);
        }

        private void trackBar_s4_17_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_17, ref textBox_s4_17);
            update_volumes(trackBar_s4_17, 3, 16);
        }

        private void trackBar_s4_18_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s4_18, ref textBox_s4_18);
            update_volumes(trackBar_s4_18, 3, 17);
        }

        private void trackBar_s5_1_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_1, ref textBox_s5_1);
            update_volumes(trackBar_s5_1, 4, 0);
        }

        private void trackBar_s5_2_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_2, ref textBox_s5_2);
            update_volumes(trackBar_s5_2, 4, 1);
        }

        private void trackBar_s5_3_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_3, ref textBox_s5_3);
            update_volumes(trackBar_s5_3, 4, 2);
        }

        private void trackBar_s5_4_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_4, ref textBox_s5_4);
            update_volumes(trackBar_s5_4, 4, 3);
        }

        private void trackBar_s5_5_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_5, ref textBox_s5_5);
            update_volumes(trackBar_s5_5, 4, 4);
        }

        private void trackBar_s5_6_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_6, ref textBox_s5_6);
            update_volumes(trackBar_s5_6, 4, 5);
        }

        private void trackBar_s5_7_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_7, ref textBox_s5_7);
            update_volumes(trackBar_s5_7, 4, 6);
        }

        private void trackBar_s5_8_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_8, ref textBox_s5_8);
            update_volumes(trackBar_s5_8, 4, 7);
        }

        private void trackBar_s5_9_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_9, ref textBox_s5_9);
            update_volumes(trackBar_s5_9, 4, 8);
        }

        private void trackBar_s5_10_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_10, ref textBox_s5_10);
            update_volumes(trackBar_s5_10, 4, 9);
        }

        private void trackBar_s5_11_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_11, ref textBox_s5_11);
            update_volumes(trackBar_s5_11, 4, 10);
        }

        private void trackBar_s5_12_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_12, ref textBox_s5_12);
            update_volumes(trackBar_s5_12, 4, 11);
        }

        private void trackBar_s5_13_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_13, ref textBox_s5_13);
            update_volumes(trackBar_s5_13, 4, 12);
        }

        private void trackBar_s5_14_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_14, ref textBox_s5_14);
            update_volumes(trackBar_s5_14, 4, 13);
        }

        private void trackBar_s5_15_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_15, ref textBox_s5_15);
            update_volumes(trackBar_s5_15, 4, 14);
        }

        private void trackBar_s5_16_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_16, ref textBox_s5_16);
            update_volumes(trackBar_s5_16, 4, 15);
        }

        private void trackBar_s5_17_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_17, ref textBox_s5_17);
            update_volumes(trackBar_s5_17, 4, 16);
        }

        private void trackBar_s5_18_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s5_18, ref textBox_s5_18);
            update_volumes(trackBar_s5_18, 4, 17);
        }

        private void trackBar_s6_1_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s6_1, ref textBox_s6_1);
            update_volumes(trackBar_s6_1, 5, 0);
        }

        private void trackBar_s6_2_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s6_2, ref textBox_s6_2);
            update_volumes(trackBar_s6_2, 5, 1);
        }

        private void trackBar_s6_3_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_s6_3, ref textBox_s6_3);
            update_volumes(trackBar_s6_3, 5, 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar_Speed_Scroll(object sender, EventArgs e)
        {
            int val = Convert.ToInt16(trackBar_Speed.Value.ToString());
            textBox_Speed.Text = Convert.ToString(val * 2.5) + " Km/h";
        }

        private void trackBar_volume_Scroll(object sender, EventArgs e)
        {
            from_trackbar_to_textbox(trackBar_volume, ref textBox_volume);
            int val = Convert.ToInt16(trackBar_volume.Value.ToString());
            if(m_Player != null)
            {
                Debug.WriteLine(val.ToString());
                m_Player.set_volume(val);
                
            }
        }

        static bool Mute_flag = true;
        private void checkBox_Mute_CheckedChanged(object sender, EventArgs e)
        {
            //if (m_Player != null)
            //{
                if (Mute_flag)
                {
                    int val = Convert.ToInt16(trackBar_volume.Value.ToString());
                    m_Player.set_volume(0);
                    Mute_flag = false;
                }
                else
                {
                    int val = Convert.ToInt16(trackBar_volume.Value.ToString());
                    m_Player.set_volume(val);
                    Mute_flag = true;
                }
            //}
                
        }

        private void checkBox_reverse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_mute1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_mute2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_mute3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_mute4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_mute5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_mute_reverse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_StartEngine_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void button_StopEngine_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_dump_Click(object sender, EventArgs e)
        {
            dumpAsciiFromVolumeConfig("config.txt");
        }
    }
}
