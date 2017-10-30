using HtmlAgilityPack;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AnimeStreamer
{
    class AnimeDownloader
    {
        public static Dictionary<string,string> AnimeList;
        public static string videoURL;


       /*******************************************************
        * Downloads the name of animes and their links
        * from the website into a .txt files
        *******************************************************/
        public static void Download()
        {
            //Create a HTTP Request from a link and do all this stuff
            var url = "https://animetake.tv/animelist/list/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            
            //Finds all tags with the class name 'letter-children' which is a div, so I got the child 'a' to get the link and name            
            var findclasses = doc.DocumentNode.SelectNodes("//*[contains(@class,'letter-children')]/a");

            //Just testing what im getting
            if (findclasses != null)
            {
                StreamWriter writer = new StreamWriter("Animes.txt");

                foreach (var link in findclasses)
                {
                    string line = ((link.InnerHtml + '{' + link.Attributes["href"].Value).Replace("\n", "")).Replace("- ", "").TrimStart();
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            //  Console.WriteLine(findclasses.);
            else
                Console.WriteLine("No matches found!");

        }


        /*******************************************************
         * Checks if the .txt file of anime exists, if it doesn't
         * it downloads and saves it then Loads() the animes into 
         * the combobox, otherwise it just Loads() the animes into
         * the Combobox
         *******************************************************/
        public static void Start()
        {
            if (!File.Exists("Animes.txt"))
            {
                MessageBox.Show("Downloading Latest Animes to Animes.txt", "Downloading");
                Download();
                Load();
            }
            else
            {
                Load();
            }
        }


       /*******************************************************
        * Loads the Animes.txt file into the dictionary to use
        * as the options for the ComboBox
        *******************************************************/ 
        public static void Load()
        {
            AnimeList = new Dictionary<string, string>();
            try
            {
                StreamReader file = new StreamReader(@"Animes.txt");
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split('{');

                    AnimeList.Add(parts[0],parts[1]);

                }

                file.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        } /* Load() */


        /*****************************************************************************
         * Function: Choose()
         * Description: Does some trying and catching of calling GetVideo(). There are 
         *              exceptions to the usual rule, so I try to get all cases
         * Inputs:      animename    - This is the animename from the Combobox
         *              animeepisode - This is the episode from the episode textbox 
         *
         * Outputs:     None 
         *
         *****************************************************************************/
        public static void Choose(string animename, string animeepisode)
        {
            try
            {
                GrabVideo(animename, animeepisode, false);
            }
            catch
            {
                try
                {
                    GrabVideo(animename, animeepisode, true);
                }
                catch (Exception e)
                {
                    if (animeepisode == "12")
                    {
                        try
                        {
                            animeepisode = "12-final";
                            GrabVideo(animename, animeepisode, false);
                        }
                        catch (Exception er)
                        {
                            Console.WriteLine(er.Message);
                            MessageBox.Show("Please try again.", "Error");
                        }

                    }
                    else
                    {
                        try
                        {
                            GrabVideo(animename, animeepisode, false, "ep");
                        }
                        catch
                        {
                            Console.WriteLine(e.Message);
                            MessageBox.Show("Please try again.", "Error");
                        }

                    }

                }
            }
        } /* Choose() */


        /*****************************************************************************
         * Function:    GrabVideo()
         * Description: This takes the combobox anime name, and episode number then it 
         *              does some stuff to get to the page of the actual episode
         *              then it gets the video
         * Inputs:      animename    - This is the animename from the Combobox
         *              animeepisode - This is the episode from the episode textbox 
         *
         * Outputs:     None 
         *
         *****************************************************************************/
        public static void GrabVideo(string animename, string animeepisode, bool tryagain, string format = "episode")
        {
            var episodelink = GetEpisodeLink(animename, animeepisode, tryagain);
            var url = "https://animetake.tv" + episodelink.Replace("episode",format);
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var test = doc.DocumentNode.SelectSingleNode("//script[contains(text(), 'anime360p()')]").InnerHtml;

            Console.WriteLine(test);

            string pattern = "src\\s*=\\s*\"([^\"]+)\"";

            MatchCollection matches = Regex.Matches(test, pattern);
            Console.WriteLine("Matches found: {0}", matches.Count);

            if (matches.Count > 2)
            {
                //Groups[0] has =src in it so I want [1] which has it removed
                videoURL = matches[1].Groups[1].Value;
                videoURL = "https://animetake.tv" + videoURL;
            }
            else if (matches.Count > 1)
            {
                videoURL = matches[1].Groups[1].Value;
                videoURL = "https://animetake.tv" + videoURL;
            }
            else
            {
                videoURL = matches[0].Groups[1].Value;
                videoURL = "https://animetake.tv" + videoURL;
            }
        } /* GrabVideo() */

        public static string GetEpisodeLink(string animename, string animeepisode, bool tryagain)
        {
            string link = AnimeList[animename];
            var url = "https://animetake.tv" + link;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            //Finds all tags with the class name 'letter-children' which is a div, so I got the child 'a' to get the link and name      
            var findclasses = doc.DocumentNode.SelectNodes("//a[contains(@class,'list-group-item animeinfo-content')]").First();
            var episodelink = findclasses.Attributes["href"].Value;
            var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '/', '-' };
            if (!animeepisode.Equals(""))
            {
                if (tryagain == true)
                {
                    if (animeepisode.Length == 1)
                        episodelink = episodelink.TrimEnd(digits) + '-' + "00" + animeepisode;
                    else if (animeepisode.Length == 2)
                        episodelink = episodelink.TrimEnd(digits) + '-' + "0" + animeepisode;
                    else
                        episodelink = episodelink.TrimEnd(digits) + '-' + animeepisode;
                }
                else
                {
                    episodelink = episodelink.TrimEnd(digits) + '-' + animeepisode;
                }
            }
            else
            {
                episodelink = episodelink.TrimEnd(digits);
            }
            return episodelink;

            url = "https://animetake.tv" + episodelink;
            doc = web.Load(url);
            var test = doc.DocumentNode.SelectSingleNode("//script[contains(text(), 'anime360p()')]").InnerHtml;

            Console.WriteLine(test);
            string pattern = "src\\s*=\\s*\"([^\"]+)\"";

            MatchCollection matches = Regex.Matches(test, pattern);
            Console.WriteLine("Matches found: {0}", matches.Count);

            if (matches.Count > 2)
            {
                //Groups[0] has =src in it so I want [1] which has it removed
                videoURL = matches[1].Groups[1].Value;
                videoURL = "https://animetake.tv" + videoURL;
            }
            else if (matches.Count > 1)
            {
                videoURL = matches[1].Groups[1].Value;
                videoURL = "https://animetake.tv" + videoURL;
            }
            else
            {
                videoURL = matches[0].Groups[1].Value;
                videoURL = "https://animetake.tv" + videoURL;
            }
        } /* GrabVideo() */
    }
}
