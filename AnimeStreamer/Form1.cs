using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnimeStreamer;

namespace AnimeStreamer
{
    public partial class Form1 : Form
    {
       // private static int itemID;
        public Form1()
        {
            InitializeComponent();
            AnimeDownloader.Start();
            combobox.DataSource = AnimeDownloader.AnimeList.Keys.ToList();
            combobox.SelectedIndex = 0;
            /*
            List<string> players = new List<string>();
            players.Add("WMP");
            players.Add("VLC");
            cb_Player.DataSource = players;
            cb_Player.SelectedIndex = 0;
            */
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void t_Episode_TextChanged(object sender, EventArgs e)
        {

        }

        private void l_Episode_Click(object sender, EventArgs e)
        {  

        }

        private void wmp_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            b_Browser.Enabled = false;
            AnimeDownloader.Choose(combobox.Text, t_Episode.Text);
            /*  if (cb_Player.SelectedIndex == 0)
              {
                  wmp.URL = AnimeDownloader.videoURL;
              }
              else
              {
                  vlc.playlist.stop();
                  vlc.playlist.items.remove(itemID);
                  itemID = vlc.playlist.add(AnimeDownloader.videoURL,null,null);
                  vlc.playlist.play();
              }
              */
            wmp.URL = AnimeDownloader.videoURL;
            wmp.stretchToFit = true;
            b_Browser.Enabled = true;

        }

        private void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (b_Browser.Enabled)
            {
                try
                {
                    System.Diagnostics.Process.Start(AnimeDownloader.videoURL);
                }
                catch
                {
                    MessageBox.Show("Please have an anime episode playing.", "Error");
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_Player_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (cb_Player.SelectedIndex == 0)
            {
                wmp.Visible = true;
                vlc.Visible = false;
                vlc.playlist.stop();
            }
            else
            {
                wmp.Visible = false;
                wmp.Ctlcontrols.stop();
                vlc.Visible = true;
            }
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void wmp_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
