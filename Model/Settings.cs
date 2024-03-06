using Microsoft.Win32;
using System;
using System.Collections.Generic;
using Newtonsoft.Json; 

namespace artsystem_bat.Model
{
    internal class Settings
    {
        private string _Path { get; set; }
        private string _KeyName { get; set; }
        private string _Value { get; set; }
        private RegistryKey _Key { get; set; }
        private List<string> _Values { get; set; }



        public Settings()
        {
            _Path = "SOFTWARE\\ArtsystemBat";
            _Key = Registry.CurrentUser;
        }
        public string PathInitial
        {
            get { return ReadFromRegistry("PathInitial"); }
            set { _Value = value; _KeyName = "PathInitial"; WriteToRegistry(); }
        }

        public string PathBat
        {
            get { return ReadFromRegistry("PathBat"); }
            set { _Value = value; _KeyName = "PathBat"; WriteToRegistry(); }
        }
        public string VerOcx
        {
            get { return ReadFromRegistry("OCX_Verification"); }
            set { _Value = value; _KeyName = "OCX_Verification"; WriteToRegistry(); }
        }

        public string LoadingSpeed
        {
            get { return ReadFromRegistry("LoadingSpeed"); }
            set { _Value = value; _KeyName = "LoadingSpeed"; WriteToRegistry(); }
        }
        public string RemoveUX
        {
            get { return ReadFromRegistry("RemoveUX"); }
            set { _Value = value; _KeyName = "RemoveUX"; WriteToRegistry(); }
        }

        public string PriorizaBat
        {
            get { return ReadFromRegistry("PriorizaBat"); }
            set { _Value = value; _KeyName = "PriorizaBat"; WriteToRegistry(); }
        }

        public string AbrirSistemaQuantidade
        {
            get { return ReadFromRegistry("SistemaQuantidade"); }
            set { _Value = value; _KeyName = "SistemaQuantidade"; WriteToRegistry(); }
        }

        public string LocalSalvamento
        {
            get { return ReadFromRegistry("LocalSalvamento");}
            set { _Value = value; _KeyName = "LocalSalvamento";WriteToRegistry();}
        }

        public string LocalDeRede
        {
            get { return ReadFromRegistry("LocalDeRede"); }
            set { _Value = value; _KeyName = "LocalDeRede"; WriteToRegistry();}
        }

        public List<string> ListaDeUsuarios
        {
            get { return ReadFromRegistryList("ListaDeUsuarios"); }
            set { _Values = value ; _KeyName = "ListaDeUsuarios"; WriteToRegistryList(); }
        }
        //Escreve um Json nos registros do windows
        public void WriteToRegistryList()
        {
            try
            {
                using (RegistryKey key = _Key.CreateSubKey(_Path, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    string serializedList = JsonConvert.SerializeObject(_Values);//serializa um objeto Json
                    key?.SetValue(_KeyName, serializedList);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ocorreu um erro : {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        //Realiza a leitura de um Json nos registros do windows
        public List<string> ReadFromRegistryList(string keyName)
        {
            try
            {
                using (RegistryKey key = _Key.OpenSubKey(_Path))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(keyName);
                        if (value is string serializedList)
                        {
                            return JsonConvert.DeserializeObject<List<string>>(serializedList);//desSerializa um objeto Json
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ocorreu um erro : {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return null;
        }
        //Escreve os dados no registro do windows
        public void WriteToRegistry()
        {
            
            try
            {
                using(RegistryKey key = _Key.CreateSubKey(_Path, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    key?.SetValue(_KeyName, _Value);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ocorreu um erro : {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            
        }
        //Realiza a leitura nos registros do windows
        public string ReadFromRegistry(string keyName)
        {
            try
            {
                using(RegistryKey key = _Key.OpenSubKey(_Path))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(keyName);
                        return value?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ocorreu um erro : {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return null;
            

        }
    }
}
