using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gallery_App.Models
{
    public class User
    {
        private string _password;

        public Guid Id { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    // Вызов уведомления при изменении
                    OnPropertyChanged("Password");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
