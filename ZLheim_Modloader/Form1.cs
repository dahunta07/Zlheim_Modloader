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
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Net;
using System.Management;
using Gameloop.Vdf;
using Onova;

namespace ZLheim_Modloader
{

    public partial class Form1 : MaterialForm
    {

        private const string DefaultSteamInstallDir = @"C:\Program Files (x86)\Steam\steamapps\common\Valheim\";
        private static string ValheimGameFolder;

        private static string LaunchStatus = "";

        private string ZLMVersionFile;
        private static string ZLMInstallStatus;
        private static string ZLMVersion;
        private static string LatestZLMVersion;

        private dynamic JsonResponse;
        private bool downloadComplete = false;

        private static string TempPath = Path.GetTempPath();
        private static string ZipFullPath = $"{TempPath}WindowsClient.zip";
        private static string ZipExtractionPath = $"{TempPath}WindowsClient";


        private string[] ModDllList;


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

        private string GetApplictionInstallPath(string p_name)
        {
            string displayName;
            string[] keylist;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            keylist = key.GetSubKeyNames();
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return subkey.GetValue("InstallLocation") as string;
                }
            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            keylist = key.GetSubKeyNames();
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return subkey.GetValue("InstallLocation") as string;
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            keylist = key.GetSubKeyNames();
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return subkey.GetValue("InstallLocation") as string;
                }
            }

            // NOT FOUND
            return "Unable to Locate Valheim Installation folder";
        }



        private void UpdateUI()
        {

           

            materialLabel4.Text = ValheimGameFolder; //Game install Status
            materialLabel4.Refresh();
            LaunchStatus_Label.Text = LaunchStatus; //Game Launch Status
            LaunchStatus_Label.Refresh();

            ZLM_InstalledVersion_Label.Text = ZLMVersion;
            ZLM_InstalledVersion_Label.Refresh();
            ZLM_LatestVersion_Label.Text = LatestZLMVersion;
            ZLM_LatestVersion_Label.Refresh();
            ZLM_Status_Label.Text = ZLMInstallStatus;
            ZLM_Status_Label.Refresh();

            //MapSyncStatus_Label.Text = MapSyncStatus;
            //MapSyncStatus_Label.Refresh();
            //MapSyncInstalledVersion_Label.Text = MapSyncInstalledVersion;
            //MapSyncInstalledVersion_Label.Refresh();

        }

        private void LocateValheimDirectory()
        {

            string fileContents = ReadFromConfigFile();

            if (string.IsNullOrEmpty(fileContents))
            {
                //DO Nothing

 
            }
            else
            {
                string filePath = fileContents;
                ValheimGameFolder = Path.GetFullPath(filePath);
                GetZLMVersion();
                UpdateUI();
                return;
            }

                if (Directory.Exists(DefaultSteamInstallDir))
            {
                ValheimGameFolder = DefaultSteamInstallDir;
                UpdateUI();
                return;
            }


            var SteamInstallPath = Path.GetDirectoryName(GetSteamExe());

            if (null == SteamInstallPath)
            {
                ValheimGameFolder = "Unable to Locate Steam Installation!";
                UpdateUI();
                return;
            }


            ValheimGameFolder = "Unable to Locate Valheim Installation folder. Please select Valeim Install location";
            UpdateUI();

        }

        private void BrowseFolderButton_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                ValheimGameFolder = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }

            WriteToConfigFile( ValheimGameFolder );

            UpdateUI();

        }

        private void WriteToConfigFile(string text)
        {
            string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderName = "HunterModloader";
            string configName = "config.txt";
            string folderPath = Path.Combine(local, folderName);
            string filePath = Path.Combine(local, folderName, configName);
            MessageBox.Show(filePath);

            if (!System.IO.File.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch
                {
                    MessageBox.Show("An error occurred while creating appdata folder");
                    return;
                }
            }


            if (!File.Exists(filePath))
            {
                try
                {
                    File.Create(filePath).Dispose();
                }
                catch (IOException)
                {
                    MessageBox.Show("An error occurred while creating config.txt.");
                    return;
                }
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.Write(text);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("An error occurred while writing to config.txt.");
                return;
            }
        }

        private string ReadFromConfigFile()
        {

            string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderName = "HunterModloader";
            string configName = "config.txt";
            string filePath = Path.Combine(local, folderName, configName);
            MessageBox.Show(filePath);

            string fileContents = "";

            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        fileContents = reader.ReadToEnd();
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("An error occurred while reading from config.txt.");
                }
            }

            return fileContents;
        }

        private void ExitandCleanup()
        {
            if (File.Exists(ZipFullPath))
            {
                File.Delete(ZipFullPath);
            }

            if (Directory.Exists(ZipExtractionPath))
            {
                Directory.Delete(ZipExtractionPath, true);
            }

        }

        public string GetSteamExe()
        {

            string steam32 = "SOFTWARE\\VALVE\\";
            string steam64 = "SOFTWARE\\Wow6432Node\\Valve\\";
            string steam32exe;
            string steam64exe;


            RegistryKey key32 = Registry.CurrentUser.OpenSubKey(steam32);
            RegistryKey key64 = Registry.CurrentUser.OpenSubKey(steam64);

            if (key32.ToString() != null)
            {
                foreach (string k32subKey in key32.GetSubKeyNames())
                {
                    using (RegistryKey subKey = key32.OpenSubKey(k32subKey))
                    {
                        if (k32subKey == "Steam")
                        {
                            steam32exe = subKey.GetValue("SteamExe").ToString();

                            if (File.Exists(steam32exe))
                            {
                                return steam32exe;
                            }

                        }
                    }

                }
            }

            if (key64.ToString() != null)
            {
                foreach (string k64subKey in key64.GetSubKeyNames())
                {
                    using (RegistryKey subKey = key64.OpenSubKey(k64subKey))
                    {
                        if (k64subKey == "Steam")
                        {
                            steam64exe = subKey.GetValue("SteamExe").ToString();

                            if (File.Exists(steam64exe))
                            {
                                return steam64exe;
                            }

                        }
                    }

                }
            }

            //if unable to find
            return null;
        }

        private void StartValheim()
        {
            string SteamExe = GetSteamExe();

            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();


            if (null == SteamExe)
            {
                LaunchStatus = "Unable to locate Steam Exe.. Launch Valheim Manually";
                UpdateUI();
            }

            startInfo.FileName = SteamExe;
            startInfo.Arguments = "-applaunch 892970 +connect games.maynezone.com:2456";


            Process.Start(startInfo);

        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            materialProgressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            downloadComplete = true;
        }



        private void GetLatestZLMVersion()
        {
            var client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("/repos/dahunta07/ZLheim_Modpack/releases/latest", DataFormat.Json);

            var response = client.Get(request);
            JsonResponse = JsonConvert.DeserializeObject(response.Content);
            LatestZLMVersion = JsonResponse.tag_name;
            UpdateUI();
        }

        private void GetZLMVersion()
        {

            GetZLMInstallStatus();
            if (File.Exists(ZLMVersionFile))
            {
                ZLMVersion = System.IO.File.ReadAllText(ZLMVersionFile);
                UpdateUI();
            }
            else
            {
                ZLMVersion = "-";
                UpdateUI();
            }

        }

        private void GetZLMInstallStatus()
        {
            ZLMVersionFile = $"{ValheimGameFolder}\\BepInEx\\version.txt";

            if (File.Exists(ZLMVersionFile))
            {
                ZLMInstallStatus = "Installed";
                UpdateUI();
            }
            else
            {
                ZLMInstallStatus = "Not Installed";
                ZLMVersion = "-";
                UpdateUI();
            }

        }

        private void InstallZLM()
        {
            GetLatestZLMVersion();
            ZLMInstallStatus = "Download starting";
            UpdateUI();

            string ZLMDownloadURL = $"https://github.com/dahunta07/ZLheim_Modpack/releases/download/{LatestZLMVersion}/ZLM.zip";
            string ZLMZipFullPath = $"{TempPath}ZLM.zip";
            string ZLMZipExtractionPath = $"{TempPath}ZLM";
            

            //Download

            if (File.Exists(ZLMZipFullPath))
            {
                File.Delete(ZLMZipFullPath);
            }



            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(ZLMDownloadURL), ZLMZipFullPath);
            }
            catch
            {
                ZLMInstallStatus = "Download Failed!";
                UpdateUI();

            }


            while (!downloadComplete)
            {
                System.Windows.Forms.Application.DoEvents();
            }

            downloadComplete = false;

            //Extraction
            ZLMInstallStatus = "Extracting...";
            UpdateUI();

            try
            {
                if (Directory.Exists(ZLMZipExtractionPath))
                {
                    Directory.Delete(ZLMZipExtractionPath);
                }

                ZipFile.ExtractToDirectory(ZLMZipFullPath, ZLMZipExtractionPath);

            }
            catch
            {
                ZLMInstallStatus = "Extraction Failed!";
                UpdateUI();
                return;
            }


            //File copy
            ZLMInstallStatus = "Copying Files...";
            UpdateUI();


            try
            {

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(ZLMZipExtractionPath, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(ZLMZipExtractionPath, $"{ValheimGameFolder}"));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(ZLMZipExtractionPath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(ZLMZipExtractionPath, $"{ValheimGameFolder}"), true);

            }
            catch
            {
                ZLMInstallStatus = "Copy Failed!";
                UpdateUI();

                //Cleanup
                if (File.Exists(ZLMZipFullPath))
                {
                    File.Delete(ZLMZipFullPath);
                }

                if (Directory.Exists(ZLMZipExtractionPath))
                {
                    Directory.Delete(ZLMZipExtractionPath, true);
                }

                return;
            }

            ZLMInstallStatus = "Installation Complete";

            UpdateUI();
            GetZLMVersion();

            //Cleanup
            if (File.Exists(ZLMZipFullPath))
            {
                File.Delete(ZLMZipFullPath);
            }

            if (Directory.Exists(ZLMZipExtractionPath))
            {
                Directory.Delete(ZLMZipExtractionPath, true);
            }
        }

        private void GetModList()
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string DesinationDirectory = $"{ValheimGameFolder}\\BepInEx\\plugins";
            string SourcePath = $"{CurrentDirectory}\\LocalMods\\";

            ModDllList = Directory.GetFiles(SourcePath);


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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();

            GetZLMInstallStatus();
            GetZLMVersion();
            GetLatestZLMVersion();

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }


        private void materialLabel8_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click_1(object sender, EventArgs e)
        {

        }


        private void ZLM_Install_Button_Click(object sender, EventArgs e)
        {

            InstallZLM();

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            StartValheim();
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel8_Click_1(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void materialLabel10_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel11_Click(object sender, EventArgs e)
        {

        }


        private void materialLabel12_Click(object sender, EventArgs e)
        {

        }

        private void LaunchStatus_Label_Click(object sender, EventArgs e)
        {

        }

        private void materialProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel10_Click_1(object sender, EventArgs e)
        {

        }

        private void EID_Status_Label_Click(object sender, EventArgs e)
        {

        }

        private void ZLM_Uninstall_Button_Click(object sender, EventArgs e)
        {

            var dir = new DirectoryInfo($"{ValheimGameFolder}\\BepInEx");
            dir.Delete(true);
            GetZLMInstallStatus();
            UpdateUI();

        }

        private void materialLabel13_Click(object sender, EventArgs e)
        {

        }
    }
}

