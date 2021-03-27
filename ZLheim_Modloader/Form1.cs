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
using System.Collections;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;

namespace ZLheim_Modloader
{

    public partial class Form1 : MaterialForm
    {

        string DefaultSteamInstallDir = @"C:\Program Files (x86)\Steam\steamapps\common\Valheim";
        string ValheimGameFolder;

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

            pictureBox_TitleGraphic.BackColor = Color.Transparent;
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



        private string LocateValhiemDirectory()
        {

            if (Directory.Exists(DefaultSteamInstallDir))
            {
                return DefaultSteamInstallDir;
            }
            else
            {
                return "Valhiem install directory not found!";
            }

        }

        private static bool GetValhiemPlusInstallStatus(string RootGameDirectory)
        {
            string ValheimPlusDll = $"{RootGameDirectory}\\BepInEx\\plugins\\ValheimPlus.dll";

            if (File.Exists(ValheimPlusDll))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ValheimGameFolder = LocateValhiemDirectory();
            materialSingleLineTextField_ValhiemDirectoryStatus.Text = ValheimGameFolder;

            if (GetValhiemPlusInstallStatus(ValheimGameFolder))
            {
                materialSingleLineTextFieldValhiemPlusInstallStatus.Text = "Valhiem Plus is Installed";
            }
            else
            {
                materialSingleLineTextFieldValhiemPlusInstallStatus.Text = "Valhiem Plus is not Installed!";
            }
        }







        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

