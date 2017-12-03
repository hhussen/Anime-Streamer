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
        public static Dictionary<string, string> Episodes;
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
        public static void GrabVideo(string animeepisode)
        {
            var url = "https://animetake.tv" + Episodes[animeepisode];
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

        public static void GetEpisodes(string animename)
        {
            Episodes = new Dictionary<string, string>();
            string link = AnimeList[animename];
            var url = "https://animetake.tv" + link;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            Console.WriteLine(doc.DocumentNode.SelectNodes("//*[contains(@class,'list-group')]/a"));
            //string pattern = "a href\\s*=\\s*[\'\"](/watch/[^\"\'][\'\"])";
            //string pattern = "a href\\s*=\\s*[\'\"](/watch/([^\"\']+\\-(?=\\d)(\\d+)))";
            string pattern = "a href\\s*=\\s*[\'\"](/watch/([^\"\']+\\-(?=\\d)(\\d+)|[^\"\'/]+))";

            MatchCollection matches = Regex.Matches(doc.DocumentNode.OuterHtml, pattern);
         
            foreach (Match match in matches)
            {
                try
                {
                    if (!Episodes.ContainsKey(match.Groups[3].ToString()))
                    {
                        if (match.Groups[3].Length == 0)
                        {
                            Episodes.Add(match.Groups[2].ToString().ToUpper().Replace('-', ' '), match.Groups[1].ToString());
                        }
                        else
                        {
                            Episodes.Add(match.Groups[3].ToString().ToUpper(), match.Groups[1].ToString());
                        }
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Matches found: {0}", matches.Count);

        } /* GetEpisodes() */
    }
}
