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
	partial class Form1
	{
		private string str_DB = " dB";

        private string sound1_filename;
        private string sound2_filename;
        private string sound3_filename;
        private string sound4_filename;
        private string sound5_filename;
        private string sound6_filename;

        private Int16[,] m_sound_volumes;
        private int length;
        private const int MAX_SOUNDS = 6;
        private const int MAX_VOLUME_STEPS = 40;
        private void init_all_sound_volumes()
        {
            m_sound_volumes = new Int16 [MAX_SOUNDS, MAX_VOLUME_STEPS];

            for(int i=0; i < MAX_SOUNDS; i++)
            {
                for (int j=0; j < MAX_VOLUME_STEPS; j++)
                    m_sound_volumes[i, j] = -99;
            }

        }
        private void from_trackbar_to_textbox(TrackBar tbar, ref TextBox tbox)
        {
            int val = Convert.ToInt16(tbar.Value.ToString());
            tbox.Text = Convert.ToString(val - 99) + str_DB;
        }

        private void set_m_sound_volumes(int x, int y, Int16 val)
        {
            m_sound_volumes[x, y] = val;
        }

        private void update_volumes(TrackBar tbar, int x, int y)
        {
            int val = Convert.ToInt16(tbar.Value.ToString());
            val -= 99;
            set_m_sound_volumes(x, y, (Int16)(val));
            Debug.WriteLine("update_volumes:" + val + ", xy:" + x + ","+y + " :" + tbar.Name);
            Debug.Flush();
        }

        private void init_sound1()
        {
            // init  sound 1 

            from_trackbar_to_textbox(trackBar_s1_1, ref textBox_s1_1);
            from_trackbar_to_textbox(trackBar_s1_2, ref textBox_s1_2);
            from_trackbar_to_textbox(trackBar_s1_3, ref textBox_s1_3);
            from_trackbar_to_textbox(trackBar_s1_4, ref textBox_s1_4);
            from_trackbar_to_textbox(trackBar_s1_5, ref textBox_s1_5);
            from_trackbar_to_textbox(trackBar_s1_6, ref textBox_s1_6);
            from_trackbar_to_textbox(trackBar_s1_7, ref textBox_s1_7);
            update_volumes(trackBar_s1_1, 0, 0);
            update_volumes(trackBar_s1_2, 0, 1);
            update_volumes(trackBar_s1_3, 0, 2);
            update_volumes(trackBar_s1_4, 0, 3);
            update_volumes(trackBar_s1_5, 0, 4);
            update_volumes(trackBar_s1_6, 0, 5);
            update_volumes(trackBar_s1_7, 0, 6);
        }

        private void init_sound2()
        {
            // init  sound 2 

            from_trackbar_to_textbox(trackBar_s2_1, ref textBox_s2_1);
            from_trackbar_to_textbox(trackBar_s2_2, ref textBox_s2_2);
            from_trackbar_to_textbox(trackBar_s2_3, ref textBox_s2_3);
            from_trackbar_to_textbox(trackBar_s2_4, ref textBox_s2_4);
            from_trackbar_to_textbox(trackBar_s2_5, ref textBox_s2_5);
            from_trackbar_to_textbox(trackBar_s2_6, ref textBox_s2_6);
            from_trackbar_to_textbox(trackBar_s2_7, ref textBox_s2_7);
            update_volumes(trackBar_s2_1, 1, 4);
            update_volumes(trackBar_s2_2, 1, 5);
            update_volumes(trackBar_s2_3, 1, 6);
            update_volumes(trackBar_s2_4, 1, 7);
            update_volumes(trackBar_s2_5, 1, 8);
            update_volumes(trackBar_s2_6, 1, 9);
            update_volumes(trackBar_s2_7, 1, 10);
        }

        private void init_sound3()
        {
            // init  sound 3

            from_trackbar_to_textbox(trackBar_s3_1, ref textBox_s3_1);
            from_trackbar_to_textbox(trackBar_s3_2, ref textBox_s3_2);
            from_trackbar_to_textbox(trackBar_s3_3, ref textBox_s3_3);
            from_trackbar_to_textbox(trackBar_s3_4, ref textBox_s3_4);
            from_trackbar_to_textbox(trackBar_s3_5, ref textBox_s3_5);
            from_trackbar_to_textbox(trackBar_s3_6, ref textBox_s3_6);
            from_trackbar_to_textbox(trackBar_s3_7, ref textBox_s3_7);
            from_trackbar_to_textbox(trackBar_s3_8, ref textBox_s3_8);
            from_trackbar_to_textbox(trackBar_s3_9, ref textBox_s3_9);
            from_trackbar_to_textbox(trackBar_s3_10, ref textBox_s3_10);
            update_volumes(trackBar_s3_1, 2, 8);
            update_volumes(trackBar_s3_2, 2, 9);
            update_volumes(trackBar_s3_3, 2, 10);
            update_volumes(trackBar_s3_4, 2, 11);
            update_volumes(trackBar_s3_5, 2, 12);
            update_volumes(trackBar_s3_6, 2, 13);
            update_volumes(trackBar_s3_7, 2, 14);
            update_volumes(trackBar_s3_8, 2, 15);
            update_volumes(trackBar_s3_9, 2, 16);
            update_volumes(trackBar_s3_10, 2, 17);

        }

        private void init_sound4()
        {
            // init  sound 4

            from_trackbar_to_textbox(trackBar_s4_1, ref textBox_s4_1);
            from_trackbar_to_textbox(trackBar_s4_2, ref textBox_s4_2);
            from_trackbar_to_textbox(trackBar_s4_3, ref textBox_s4_3);
            from_trackbar_to_textbox(trackBar_s4_4, ref textBox_s4_4);
            from_trackbar_to_textbox(trackBar_s4_5, ref textBox_s4_5);
            from_trackbar_to_textbox(trackBar_s4_6, ref textBox_s4_6);
            from_trackbar_to_textbox(trackBar_s4_7, ref textBox_s4_7);
            from_trackbar_to_textbox(trackBar_s4_8, ref textBox_s4_8);
            from_trackbar_to_textbox(trackBar_s4_9, ref textBox_s4_9);
            from_trackbar_to_textbox(trackBar_s4_10, ref textBox_s4_10);

            from_trackbar_to_textbox(trackBar_s4_11, ref textBox_s4_11);
            from_trackbar_to_textbox(trackBar_s4_12, ref textBox_s4_12);
            from_trackbar_to_textbox(trackBar_s4_13, ref textBox_s4_13);
            from_trackbar_to_textbox(trackBar_s4_14, ref textBox_s4_14);
            from_trackbar_to_textbox(trackBar_s4_15, ref textBox_s4_15);
            from_trackbar_to_textbox(trackBar_s4_16, ref textBox_s4_16);
            from_trackbar_to_textbox(trackBar_s4_17, ref textBox_s4_17);
            from_trackbar_to_textbox(trackBar_s4_18, ref textBox_s4_18);

            update_volumes(trackBar_s4_1, 3, 0);
            update_volumes(trackBar_s4_2, 3, 1);
            update_volumes(trackBar_s4_3, 3, 2);
            update_volumes(trackBar_s4_4, 3, 3);
            update_volumes(trackBar_s4_5, 3, 4);
            update_volumes(trackBar_s4_6, 3, 5);
            update_volumes(trackBar_s4_7, 3, 6);
            update_volumes(trackBar_s4_8, 3, 7);
            update_volumes(trackBar_s4_9, 3, 8);
            update_volumes(trackBar_s4_10, 3, 9);
            update_volumes(trackBar_s4_11, 3, 10);
            update_volumes(trackBar_s4_12, 3, 11);
            update_volumes(trackBar_s4_13, 3, 12);
            update_volumes(trackBar_s4_14, 3, 13);
            update_volumes(trackBar_s4_15, 3, 14);
            update_volumes(trackBar_s4_16, 3, 15);
            update_volumes(trackBar_s4_17, 3, 16);
            update_volumes(trackBar_s4_18, 3, 17);

        }

        private void init_sound5()
        {
            // init  sound 5

            from_trackbar_to_textbox(trackBar_s5_1, ref textBox_s5_1);
            from_trackbar_to_textbox(trackBar_s5_2, ref textBox_s5_2);
            from_trackbar_to_textbox(trackBar_s5_3, ref textBox_s5_3);
            from_trackbar_to_textbox(trackBar_s5_4, ref textBox_s5_4);
            from_trackbar_to_textbox(trackBar_s5_5, ref textBox_s5_5);
            from_trackbar_to_textbox(trackBar_s5_6, ref textBox_s5_6);
            from_trackbar_to_textbox(trackBar_s5_7, ref textBox_s5_7);
            from_trackbar_to_textbox(trackBar_s5_8, ref textBox_s5_8);
            from_trackbar_to_textbox(trackBar_s5_9, ref textBox_s5_9);
            from_trackbar_to_textbox(trackBar_s5_10, ref textBox_s5_10);

            from_trackbar_to_textbox(trackBar_s5_11, ref textBox_s5_11);
            from_trackbar_to_textbox(trackBar_s5_12, ref textBox_s5_12);
            from_trackbar_to_textbox(trackBar_s5_13, ref textBox_s5_13);
            from_trackbar_to_textbox(trackBar_s5_14, ref textBox_s5_14);
            from_trackbar_to_textbox(trackBar_s5_15, ref textBox_s5_15);
            from_trackbar_to_textbox(trackBar_s5_16, ref textBox_s5_16);
            from_trackbar_to_textbox(trackBar_s5_17, ref textBox_s5_17);
            from_trackbar_to_textbox(trackBar_s5_18, ref textBox_s5_18);

            update_volumes(trackBar_s5_1, 4, 0);
            update_volumes(trackBar_s5_2, 4, 1);
            update_volumes(trackBar_s5_3, 4, 2);
            update_volumes(trackBar_s5_4, 4, 3);
            update_volumes(trackBar_s5_5, 4, 4);
            update_volumes(trackBar_s5_6, 4, 5);
            update_volumes(trackBar_s5_7, 4, 6);
            update_volumes(trackBar_s5_8, 4, 7);
            update_volumes(trackBar_s5_9, 4, 8);
            update_volumes(trackBar_s5_10, 4, 9);
            update_volumes(trackBar_s5_11, 4, 10);
            update_volumes(trackBar_s5_12, 4, 11);
            update_volumes(trackBar_s5_13, 4, 12);
            update_volumes(trackBar_s5_14, 4, 13);
            update_volumes(trackBar_s5_15, 4, 14);
            update_volumes(trackBar_s5_16, 4, 15);
            update_volumes(trackBar_s5_17, 4, 16);
            update_volumes(trackBar_s5_18, 4, 17);

        }
        private void init_sound6()
        {
            // init  sound 1 

            from_trackbar_to_textbox(trackBar_s6_1, ref textBox_s6_1);
            from_trackbar_to_textbox(trackBar_s6_2, ref textBox_s6_2);
            from_trackbar_to_textbox(trackBar_s6_3, ref textBox_s6_3);
            update_volumes(trackBar_s6_1, 5, 0); 
            update_volumes(trackBar_s6_2, 5, 14); 
            update_volumes(trackBar_s6_3, 5, 39);
        }

        // convert two bytes to one double in the range -1 to 1
        static double bytesToDouble(byte firstByte, byte secondByte)
        {
            // convert two bytes to one short (little endian)
            short s = (short)((secondByte << 8) | firstByte);
            // convert to range from -1 to (just below) 1
            return s / 32768.0;
        }

        // Returns left and right double arrays. 'right' will be null if sound is mono.
        public void openWav(string filename, out double[] left, out double[] right)
        {
            byte[] wav = File.ReadAllBytes(filename);

            // Determine if mono or stereo
            int channels = wav[22];     // Forget byte 23 as 99.999% of WAVs are 1 or 2 channels

            // Get past all the other sub chunks to get to the data subchunk:
            int pos = 12;   // First Subchunk ID from 12 to 16

            // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
            while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
            {
                pos += 4;
                int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                pos += 4 + chunkSize;
            }
            pos += 8;

            // Pos is now positioned to start of actual sound data.
            int samples = (wav.Length - pos) / 2;     // 2 bytes per sample (16 bit sound mono)
            if (channels == 2) samples /= 2;        // 4 bytes per sample (16 bit stereo)

            // Allocate memory (right will be null if only mono sound)
            left = new double[samples];
            if (channels == 2) right = new double[samples];
            else right = null;

            // Write to double array/s:
            int i = 0;
            while (pos < length)
            {
                left[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                pos += 2;
                if (channels == 2)
                {
                    right[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                    pos += 2;
                }
                i++;
            }
        }

        private void saveAsciiFromWav(short[] buffer, string save_filename)
        {
            //FileStream fs = File.Create(save_filename);
            Stream fs;
            fs = new FileStream(save_filename, FileMode.Create);
            
            foreach(short s in buffer)
            {
                string str = "(short)0x"+s.ToString("X4")+",\n";
                byte[] bytes = Encoding.ASCII.GetBytes(str);
                fs.Write(bytes, 0, bytes.Length);
            }
            fs.Close();
        }

        private void dumpAsciiFromVolumeConfig(string filename)
        {
            Stream fs;
            fs = new FileStream(filename, FileMode.Create);

            for (int i=0; i< MAX_SOUNDS; i++)
            {
                for(int j=0; j< MAX_VOLUME_STEPS; j++)
                {
                    string str = m_sound_volumes[i, j].ToString() + ", ";
                    byte[] bytes = Encoding.ASCII.GetBytes(str);
                    fs.Write(bytes, 0, bytes.Length);
                }
                byte[] newline  = Encoding.ASCII.GetBytes("\n");
                fs.Write(newline, 0, newline.Length);
            }
            fs.Close();
        }
    }
}