using System.Configuration;


namespace artsystem_bat.Data
{
    internal class Entities
    {
        private string _pathInitial;
        private string _pathBat;
        private string _verOcx;
        private string _loadingSpeed;
        private string _removeUX;
        private string _priorizaBat;
        private string _abrirSistemaQuantidade;
        private string _localSalvamento;

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

        public string LoadingSpeed
        {
            get { return GetConfigValue("loadingSpeed"); }
            set { _loadingSpeed = value;
                UpdateConfig("loadingSpeed",value) ; 
            }
        }

        public string RemoveUX
        {
            get { return GetConfigValue("removeUX"); }
            set { _removeUX = value;
                UpdateConfig("removeUX", value);
            }
        }
        public string PriorizaBat
        {
            get { return GetConfigValue("priorizaBat"); }
            set { _priorizaBat = value;
                UpdateConfig("priorizaBat", value);}
        }
        public string AbrirSistemaQuantidade
        {
            get { return GetConfigValue("abrirSistemaQuantidade"); }
            set { _abrirSistemaQuantidade = value;
                UpdateConfig("abrirSistemaQuantidade", value);
            }
        }

        public string LocalSalvamento
        {
            get { return GetConfigValue("localSalvamento"); }
            set { _localSalvamento = value;
                UpdateConfig("localSalvamento", value);
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
