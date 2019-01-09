using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinXExplorerMenu
{
    class Globals
    {
        static public string ConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WinxExplorerMenu\\";
        static public string ConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WinxExplorerMenu\\Folders.XML";

        public const string SettingsStartMinimized = "StartMinimized";
        public const string SettingsMinimizeOnClose = "MinimizeOnClose";
        public const string SettingsAlwaysShowIcon = "AlwaysShowIcon";
        public const string SettingsEnableArrowKeys = "EnableArrowKeys";
        public const string SettingsAlternativeApp = "AlternativeApp";

        public static string GetConfigData(string sKey)
        {
            string sPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "WinXExplorerMenu.exe");
            return ConfigurationManager.AppSettings[sKey];
        }

        public static void SetConfigData(string sKey, string sValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(sKey);
            config.AppSettings.Settings.Add(sKey, sValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public class MainSettings
    {
        public bool AlwaysShowIcon { get; set; }
        public bool MinimizeOnStart { get; set; }
        public bool MinimizeOnClose { get; set; }

        public bool EnableArrowKeys { get; set; }

        public string AlternativeApp { get; set; }

    }
    public class FolderSettings
    {
        public string FolderName { get; set; }
        public string FolderDescription { get; set; }
        public string FolderParams { get; set; }

        public Guid FolderID { get; set; }

        public FolderSettings()
        {
            FolderID = Guid.NewGuid();
            FolderName = "";
            FolderDescription = "";
            FolderParams = "";
        }

        public static List<FolderSettings> Deserialize(string path)
        {
            List<FolderSettings> lstFolders = new List<FolderSettings>();

            try
            {
                XElement root = XElement.Load(path);

                var folders = from f in root.Elements("Folder")
                              select f;

                foreach (var folder in folders)
                {
                    lstFolders.Add(new FolderSettings()
                    {
                        FolderName = folder.Element("FolderName").Value,
                        FolderDescription = folder.Element("FolderDescription") != null ? folder.Element("FolderDescription").Value : "",
                        FolderParams = folder.Element("Params") != null ? folder.Element("FolderParams").Value : "",
                        FolderID = Guid.Parse(folder.Element("FolderID").Value)
                    });

                }

            }
            catch (Exception)
            {

                throw;
            }

            return lstFolders;
        }

        public static void Serialize(List<FolderSettings> listFolders, string path)
        {
            XElement root = new XElement("Folders");
            foreach (var item in listFolders)
            {
                XElement folderNode = new XElement("Folder",
                            new XElement("FolderName", item.FolderName),
                            new XElement("FolderDescription", item.FolderDescription),
                            new XElement("FolderParams", item.FolderParams),
                            new XElement("FolderID", item.FolderID.ToString())
                        );
                root.Add(folderNode);
            }
            root.Save(path);
        }
    }
}
