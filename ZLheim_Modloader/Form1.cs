using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;
using System.IO.Compression;
using System.Collections;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using Octokit;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Net;

namespace ZLheim_Modloader
{
    
    public partial class Form1 : MaterialForm
    {

        private const string DefaultSteamInstallDir = @"C:\Program Files (x86)\Steam\steamapps\common\Valheim";
        private static FileVersionInfo ValheimPlusFileDetail;

        private static string ValheimGameFolder;
        private static string ValheimPlusDll;
        private static string ValheimPlusInstallStatus;
        private static string ValheimPlusVersion; 
        private static string LatestValheimPlusVersion;
        //private List<string[]> releases = new List<string[]>();

        private dynamic JsonResponse;
        private bool downloadComplete = false;


        
        private static string TempPath = Path.GetTempPath();
        private static string ZipFullPath = $"{TempPath}WindowsClient.zip";
        private static string ZipExtractionPath = $"{TempPath}WindowsClient";


        public Form1()
        {
            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue900, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
                );

            pictureBox1.BackColor = Color.Transparent;
        }

        private static string GetApplictionInstallPath(string nameOfAppToFind)
        {
            string installedPath;
            string keyName;

            // search in: CurrentUser
            keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            installedPath = ExistsInSubKey(Registry.CurrentUser, keyName, "DisplayName", nameOfAppToFind);
            if (!string.IsNullOrEmpty(installedPath))
            {
                return installedPath;
            }

            // search in: LocalMachine_32
            keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            installedPath = ExistsInSubKey(Registry.LocalMachine, keyName, "DisplayName", nameOfAppToFind);
            if (!string.IsNullOrEmpty(installedPath))
            {
                return installedPath;
            }

            // search in: LocalMachine_64
            keyName = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            installedPath = ExistsInSubKey(Registry.LocalMachine, keyName, "DisplayName", nameOfAppToFind);
            if (!string.IsNullOrEmpty(installedPath))
            {
                return installedPath;
            }

            return string.Empty;
        }

        private static string ExistsInSubKey(RegistryKey root, string subKeyName, string attributeName, string nameOfAppToFind)
        {
            RegistryKey subkey;
            string displayName;

            using (RegistryKey key = root.OpenSubKey(subKeyName))
            {
                if (key != null)
                {
                    foreach (string kn in key.GetSubKeyNames())
                    {
                        using (subkey = key.OpenSubKey(kn))
                        {
                            displayName = subkey.GetValue(attributeName) as string;
                            if (nameOfAppToFind.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                return subkey.GetValue("InstallLocation") as string;
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void UpdateUI()
        {
            materialLabel4.Text = ValheimGameFolder; //Game install Status
            materialLabel4.Refresh();
            materialLabel5.Text = ValheimPlusInstallStatus; //Valhiem Plus Install Status
            materialLabel5.Refresh();
            materialLabel7.Text = ValheimPlusVersion; //Valheim Plus Version Installed
            materialLabel7.Refresh();
            materialLabel9.Text = LatestValheimPlusVersion; //Latest Valheim Plus Version from github
            materialLabel9.Refresh();

        }

        private void LocateValheimDirectory()
        {

            if (Directory.Exists(DefaultSteamInstallDir))
            {
                ValheimPlusInstallStatus = DefaultSteamInstallDir;
                ValheimGameFolder = DefaultSteamInstallDir;
                UpdateUI();
            }
            else
            {
                ValheimPlusInstallStatus = "Valheim install directory not found!";
                ValheimGameFolder = null;
                UpdateUI();
            }

        }

        private void GetValheimPlusInstallStatus()
        {
            ValheimPlusDll = $"{ValheimGameFolder}\\BepInEx\\plugins\\ValheimPlus.dll";

            if (File.Exists(ValheimPlusDll))
            {
                ValheimPlusInstallStatus = "Valheim Plus is Installed";
                UpdateUI();
            }
            else
            {
                ValheimPlusInstallStatus = "Valheim Plus is not Installed";
                ValheimPlusVersion = "-";
                UpdateUI();
            }
            
        }

        private void GetValheimPlusVersion()
        {

            GetValheimPlusInstallStatus();
            if (File.Exists(ValheimPlusDll))
            {
                ValheimPlusFileDetail = FileVersionInfo.GetVersionInfo(ValheimPlusDll);
                ValheimPlusVersion = ValheimPlusFileDetail.FileVersion;
                UpdateUI();
            }
            else
            {
                ValheimPlusVersion = "-";
                UpdateUI();
            }

        }

        private void GetLatestValheimPlusVersion()
        {



            var client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("/repos/valheimPlus/ValheimPlus/releases/latest", DataFormat.Json);

            var response = client.Get(request);
            JsonResponse = JsonConvert.DeserializeObject(response.Content);
            LatestValheimPlusVersion = JsonResponse.tag_name;
            UpdateUI();




        }

        private void ExitandCleanup()
        {
            if (File.Exists(ZipFullPath))
            {
                File.Delete(ZipFullPath);
            }

            if (Directory.Exists(ZipExtractionPath))
            {
                Directory.Delete(ZipExtractionPath,true);
            }

        }


        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            materialProgressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            ValheimPlusInstallStatus = "Download completed!";
            UpdateUI();
            downloadComplete = true;
        }
        private void InstallValheimPlus()
        {
            GetLatestValheimPlusVersion();
            ValheimPlusInstallStatus = "Download starting";
            UpdateUI();

            string ValheimPlusDownloadURL = $"https://github.com/valheimPlus/ValheimPlus/releases/download/{LatestValheimPlusVersion}/WindowsClient.zip";

            //Download

            if (File.Exists(ZipFullPath))
            {
                File.Delete(ZipFullPath);
            }



            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(ValheimPlusDownloadURL), ZipFullPath);
            }
            catch
            {
                ValheimPlusInstallStatus = "Download Failed!";
                UpdateUI();

            }


            while (!downloadComplete)
            {
                System.Windows.Forms.Application.DoEvents();
            }

            downloadComplete = false;

            //Extraction
            ValheimPlusInstallStatus = "Extracting...";
            UpdateUI();

            try
            {
                if (Directory.Exists(ZipExtractionPath))
                {
                   Directory.Delete(ZipExtractionPath);
                }

                ZipFile.ExtractToDirectory(ZipFullPath, ZipExtractionPath);

            }
            catch
            {
               ValheimPlusInstallStatus = "Extraction Failed!";
                UpdateUI();
                ExitandCleanup();
                return;
            }


            //File copy
            ValheimPlusInstallStatus = "Copying Files...";

            try
            {
                //foreach (var file in Directory.GetFiles(ZipExtractionPath))
                //    File.Copy(file, Path.Combine(ValheimGameFolder, Path.GetFileName(file)), true);


                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(ZipExtractionPath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(ZipExtractionPath, ValheimGameFolder));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(ZipExtractionPath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(ZipExtractionPath, ValheimGameFolder), true);

            }
            catch
            {
                ValheimPlusInstallStatus = "Copy Failed!";
                UpdateUI();
                ExitandCleanup();
                return;
            }

            ValheimPlusInstallStatus = "Installation Complete";

            UpdateUI();
            GetValheimPlusVersion();

            ExitandCleanup();
        }

        private void UninstallValheimPlus()
        {

            try
            {
                File.Delete(ValheimPlusDll);
                File.Delete($"{ValheimGameFolder}\\winhttp.dll");
            }
            catch
            {
                materialLabel5.Text = "Failed to remove Valhiem Plus!";
                UpdateUI();
            }


            GetValheimPlusInstallStatus();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {


        }



        private void Form1_Load_1(object sender, EventArgs e)
        {
            LocateValheimDirectory();
            materialLabel4.Text = ValheimGameFolder;

            GetValheimPlusInstallStatus();
            GetValheimPlusVersion();
            GetLatestValheimPlusVersion();

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            UninstallValheimPlus();
            UpdateUI();
        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            InstallValheimPlus();

        }
    }
}

