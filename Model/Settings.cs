using Microsoft.Win32;
using System;
using System.Web;

namespace artsystem_bat.Model
{
    internal class Settings
    {
        private string _Path { get; set; }
        private string _KeyName { get; set; }
        private string _Value { get; set; }

        public Settings() 
        {
            _Path = "Software\\ArtsystemBat";
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


        
        public void WriteToRegistry()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(_Path))
                {
                    key.SetValue(_KeyName, _Value);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ocorreu um erro : {ex.Message}","Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        
        public string ReadFromRegistry(string keyName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(_Path))
                {
                    if (key != null)
                    {
                        object registryValue = key.GetValue(keyName);
                        if (registryValue != null)
                        {
                            return registryValue.ToString();
                        }
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ocorreu um erro : {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
