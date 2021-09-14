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
using System.Runtime.InteropServices;

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
                    m_sound_volumes[i, j] = -100;
            }

        }
        private void from_trackbar_to_textbox(TrackBar tbar, ref TextBox tbox)
        {
            int val = Convert.ToInt16(tbar.Value.ToString());
            tbox.Text = Convert.ToString(val - 100) + str_DB;
        }

        private void set_m_sound_volumes(int x, int y, Int16 val)
        {
            m_sound_volumes[x, y] = val;
        }

        private void update_volumes(TrackBar tbar, int x, int y)
        {
            int val = Convert.ToInt16(tbar.Value.ToString());
            val -= 100;
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
        private void save_sound1()
        {
            WritePrivateProfileString("VESS Configuration", "trackBar_s1_1", trackBar_s1_1.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s1_2", trackBar_s1_2.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s1_3", trackBar_s1_3.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s1_4", trackBar_s1_4.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s1_5", trackBar_s1_5.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s1_6", trackBar_s1_6.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s1_7", trackBar_s1_7.Value.ToString(), ProfileName);
        }

        private void set_trackbar1_from_string(ref String name, ref String data)
        {
            if (name.CompareTo("trackBar_s1_1") == 0)
            {
                trackBar_s1_1.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s1_2") == 0)
            {
                trackBar_s1_2.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s1_3") == 0)
            {
                trackBar_s1_3.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s1_4") == 0)
            {
                trackBar_s1_4.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s1_5") == 0)
            {
                trackBar_s1_5.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s1_6") == 0)
            {
                trackBar_s1_6.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s1_7") == 0)
            {
                trackBar_s1_7.Value = Convert.ToInt16(data);
            }
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
        private void save_sound2()
        {
            WritePrivateProfileString("VESS Configuration", "trackBar_s2_1", trackBar_s2_1.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s2_2", trackBar_s2_2.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s2_3", trackBar_s2_3.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s2_4", trackBar_s2_4.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s2_5", trackBar_s2_5.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s2_6", trackBar_s2_6.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s2_7", trackBar_s2_7.Value.ToString(), ProfileName);
        }

        private void set_trackbar2_from_string(ref String name, ref String data)
        {
            if (name.CompareTo("trackBar_s2_1") == 0)
            {
                trackBar_s2_1.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s2_2") == 0)
            {
                trackBar_s2_2.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s2_3") == 0)
            {
                trackBar_s2_3.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s2_4") == 0)
            {
                trackBar_s2_4.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s2_5") == 0)
            {
                trackBar_s2_5.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s2_6") == 0)
            {
                trackBar_s2_6.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s2_7") == 0)
            {
                trackBar_s2_7.Value = Convert.ToInt16(data);
            }
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
        private void save_sound3()
        {
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_1", trackBar_s3_1.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_2", trackBar_s3_2.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_3", trackBar_s3_3.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_4", trackBar_s3_4.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_5", trackBar_s3_5.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_6", trackBar_s3_6.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_7", trackBar_s3_7.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_8", trackBar_s3_8.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_9", trackBar_s3_9.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s3_10", trackBar_s3_10.Value.ToString(), ProfileName);
        }
        private void set_trackbar3_from_string(ref String name, ref String data)
        {
            if (name.CompareTo("trackBar_s3_1") == 0)
            {
                trackBar_s3_1.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_2") == 0)
            {
                trackBar_s3_2.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_3") == 0)
            {
                trackBar_s3_3.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_4") == 0)
            {
                trackBar_s3_4.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_5") == 0)
            {
                trackBar_s3_5.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_6") == 0)
            {
                trackBar_s3_6.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_7") == 0)
            {
                trackBar_s3_7.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_8") == 0)
            {
                trackBar_s3_8.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_9") == 0)
            {
                trackBar_s3_9.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s3_10") == 0)
            {
                trackBar_s3_10.Value = Convert.ToInt16(data);
            }
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
        private void save_sound4()
        {
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_1", trackBar_s4_1.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_2", trackBar_s4_2.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_3", trackBar_s4_3.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_4", trackBar_s4_4.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_5", trackBar_s4_5.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_6", trackBar_s4_6.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_7", trackBar_s4_7.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_8", trackBar_s4_8.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_9", trackBar_s4_9.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_10", trackBar_s4_10.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_11", trackBar_s4_11.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_12", trackBar_s4_12.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_13", trackBar_s4_13.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_14", trackBar_s4_14.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_15", trackBar_s4_15.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_16", trackBar_s4_16.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_17", trackBar_s4_17.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s4_18", trackBar_s4_18.Value.ToString(), ProfileName);
        }

        private void set_trackbar4_from_string(ref String name, ref String data)
        {
            if (name.CompareTo("trackBar_s4_1") == 0)
            {
                trackBar_s4_1.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_2") == 0)
            {
                trackBar_s4_2.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_3") == 0)
            {
                trackBar_s4_3.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_4") == 0)
            {
                trackBar_s4_4.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_5") == 0)
            {
                trackBar_s4_5.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_6") == 0)
            {
                trackBar_s4_6.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_7") == 0)
            {
                trackBar_s4_7.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_8") == 0)
            {
                trackBar_s4_8.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_9") == 0)
            {
                trackBar_s4_9.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_10") == 0)
            {
                trackBar_s4_10.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_11") == 0)
            {
                trackBar_s4_11.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_12") == 0)
            {
                trackBar_s4_12.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_13") == 0)
            {
                trackBar_s4_13.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_14") == 0)
            {
                trackBar_s4_14.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_15") == 0)
            {
                trackBar_s4_15.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_16") == 0)
            {
                trackBar_s4_16.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_17") == 0)
            {
                trackBar_s4_17.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s4_18") == 0)
            {
                trackBar_s4_18.Value = Convert.ToInt16(data);
            }
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
        private void save_sound5()
        {
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_1", trackBar_s5_1.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_2", trackBar_s5_2.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_3", trackBar_s5_3.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_4", trackBar_s5_4.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_5", trackBar_s5_5.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_6", trackBar_s5_6.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_7", trackBar_s5_7.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_8", trackBar_s5_8.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_9", trackBar_s5_9.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_10", trackBar_s5_10.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_11", trackBar_s5_11.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_12", trackBar_s5_12.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_13", trackBar_s5_13.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_14", trackBar_s5_14.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_15", trackBar_s5_15.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_16", trackBar_s5_16.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_17", trackBar_s5_17.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s5_18", trackBar_s5_18.Value.ToString(), ProfileName);
        }
        private void set_trackbar5_from_string(ref String name, ref String data)
        {
            if (name.CompareTo("trackBar_s5_1") == 0)
            {
                trackBar_s5_1.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_2") == 0)
            {
                trackBar_s5_2.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_3") == 0)
            {
                trackBar_s5_3.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_4") == 0)
            {
                trackBar_s5_4.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_5") == 0)
            {
                trackBar_s5_5.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_6") == 0)
            {
                trackBar_s5_6.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_7") == 0)
            {
                trackBar_s5_7.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_8") == 0)
            {
                trackBar_s5_8.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_9") == 0)
            {
                trackBar_s5_9.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_10") == 0)
            {
                trackBar_s5_10.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_11") == 0)
            {
                trackBar_s5_11.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_12") == 0)
            {
                trackBar_s5_12.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_13") == 0)
            {
                trackBar_s5_13.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_14") == 0)
            {
                trackBar_s5_14.Value = Convert.ToInt16(data);;
            }
            else if (name.CompareTo("trackBar_s5_15") == 0)
            {
                trackBar_s5_15.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_16") == 0)
            {
                trackBar_s5_16.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_17") == 0)
            {
                trackBar_s5_17.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s5_18") == 0)
            {
                trackBar_s5_18.Value = Convert.ToInt16(data);
            }
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
            update_config(trackBar_s6_1, 0, 14);
            update_config(trackBar_s6_1, 14, 39);
        }

        private void save_sound6()
        {
            WritePrivateProfileString("VESS Configuration", "trackBar_s6_1", trackBar_s6_1.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s6_2", trackBar_s6_2.Value.ToString(), ProfileName);
            WritePrivateProfileString("VESS Configuration", "trackBar_s6_3", trackBar_s6_3.Value.ToString(), ProfileName);

        }
        private void set_trackbar6_from_string(ref String name, ref String data)
        {
            if (name.CompareTo("trackBar_s6_1") == 0)
            {
                trackBar_s6_1.Value = Convert.ToInt16(data);

            }
            else if (name.CompareTo("trackBar_s6_2") == 0)
            {
                trackBar_s1_2.Value = Convert.ToInt16(data);
            }
            else if (name.CompareTo("trackBar_s6_3") == 0)
            {
                trackBar_s1_3.Value = Convert.ToInt16(data);
            }
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

        private void adjustlinearConfig(ref Int16[,] arr, int arr_pos, int start, int end)
        {
            var s_val = arr[arr_pos, start];
            var e_val = arr[arr_pos, end];
            for(var i=start+1; i<end ; i++)
            {
                var y_val = (((e_val - s_val)*100 / (end - start)) * (i - start))/100 + s_val;
                Debug.WriteLine("adjustlinearConfig:" + y_val+" a:"+ ((e_val - s_val) *100 / (end - start)));
                arr[arr_pos, i] = (Int16)y_val;
            }
        }

        private void update_config(TrackBar tbar, int start, int end)
        {
            int val = Convert.ToInt16(tbar.Value.ToString());
            val -= 100;
            adjustlinearConfig(ref m_sound_volumes, 5, start, end);
        }

        public string SelectProfile(bool save)
        {
            //
            string dirName = ".\\";

            Directory.CreateDirectory(dirName);

            OpenFileDialog OpenRecord = new OpenFileDialog();
            OpenRecord.CheckFileExists = false;

            OpenRecord.InitialDirectory = dirName;
            OpenRecord.DefaultExt = "ini";
            OpenRecord.Filter = "ini files (*.ini)|*.ini|All files (*.*)|*.*";
            OpenRecord.FilterIndex = 2;

            OpenRecord.ShowDialog();
            ProfileName = null;

            if (save)
            {
                // file is for Saving
                if (OpenRecord.FileName != "")
                {
                    if (System.IO.File.Exists(OpenRecord.FileName))
                    {
                        if (MessageBox.Show("Do you want to overwrite it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            ProfileName = OpenRecord.FileName;
                        }
                        else
                        {
                            ProfileName = null;
                        }
                    }
                    else
                    {
                        ProfileName = OpenRecord.FileName;
                    }
                }
            }
            else
            {
                // File is for reading only
                if (OpenRecord.FileName != "")
                {
                    if (System.IO.File.Exists(OpenRecord.FileName))
                    {
                        ProfileName = OpenRecord.FileName;
                    }
                    else
                    {
                        MessageBox.Show("The file does not exist", "File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ProfileName = null;
                    }
                }
            }

            return ProfileName;
        }

        public void SaveProfileToFile()
        {
            // Construct the INI Name
            string fname = "VESS.ini";

            if (ProfileName != null)
            {
                string SaveList = GetIniString(fname, "Profile Registers", "List");

                string[] list = SaveList.Split(',');

                foreach (string sname in list)
                {
                    string s = GetIniSection(fname, sname);

                    String[] names = s.Split('\0');
                    foreach (String name in names)
                    {
                        if (name != String.Empty)
                        {

                            string pname = GetField(name, "=", 1);
                            string pdata = GetField(name, "=", 2);

                            string vReg = GetField(pdata, ",", 1);
                            string RW = GetField(pdata, ",", 2);
                            string Show = GetField(pdata, ",", 3);

                            string oData = null;
                            byte[] bData = new byte[128];

                            int regdata = 0;

                            string reg = GetField(vReg, " ", 1); // Get the Reg indicator and strip any thing else from the line

                            if (reg.Substring(0, 1) == "R") // is it a valid Register definition ?
                            {
                                reg = reg.Substring(1);
                                UInt16 regbin = Convert.ToUInt16(reg, 16);

                                if (RW == "RW")
                                {
                                    // Save this register and state in the profile
                                    //DisplayValue = GetPropertyDisplay(vReg);

                                    //regdata = GetRegVal((byte)regbin);

                                    //oData = vReg + ":" + regdata.ToString("X2") + "," + RW + "," + Show;

                                    //WritePrivateProfileString("501 Profile", pname, oData, ProfileName);
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Profile" + ProfileName + " Saved!", "File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Profile Name was not selected!", "File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSectionA")]
        static extern int GetPrivateProfileSection(
            string sName,
            byte[] lpszReturnBuffer,
            int nSize,
            string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA")]
        private static extern int WritePrivateProfileString(string AppName, string KeyName, string Value, string FileName);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, byte[] lpReturnedString, int nSize, string lpFileName);

        public String GetIniSection(String iniName, String Section)
        {
            byte[] buff = new byte[65536];
            int rc = GetPrivateProfileSection(Section, buff, buff.Length, iniName);

            String s = System.Text.Encoding.Default.GetString(buff);
            //Debug.WriteLine("Getinisection: " + s);

            return s;
        }
        public String GetIniString(String iniName, String Section, String KeyName)
        {
            byte[] buff = new byte[65536];
            string sDefault = "xxx";

            int rc = GetPrivateProfileString(Section, KeyName, sDefault, buff, buff.Length, iniName);

            String s = System.Text.Encoding.Default.GetString(buff);
            return s;
        }


        public String GetField(String source, String del, Int32 count)
        {
            String[] s;
            String rString;

            if ((source != null) && count > 0)
            {
                s = source.Split(del.ToCharArray());
                if (s.Length >= count)
                    rString = s[count - 1];
                else
                    rString = "";
            }
            else
                rString = "";

            return rString;
        }

    }
}