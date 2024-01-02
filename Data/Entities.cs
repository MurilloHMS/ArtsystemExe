using System.Configuration;


namespace artsystem_bat.Data
{
    internal class Entities
    {
        private string _pathInitial;
        private string _pathBat;
        private string _verOcx;


        public string PathInitial
        {
            get { return GetConfigValue("pathIni"); }
            set { _pathInitial = value;
                UpdateConfig("pathIni", value);
            }
        }

        public string PathBat
        {
            get { return GetConfigValue("pathBat"); }
            set { _pathBat = value;
                UpdateConfig("pathBat", value);
            }
        }

        public string VerOcx
        {
            get { return GetConfigValue("verOcx"); }
            set { _verOcx = value;
                UpdateConfig("verOcx", value);
            }
        }

        // Método privado para obter valores do appSettings
        private string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];   
        }

        // Método privado para atualizar valores no appSettings
        private void UpdateConfig(string key , string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
