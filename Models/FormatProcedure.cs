namespace MultiLineStringFormatter.Models
{
    using System;
    using System.ComponentModel;
    using System.IO;

    public class FormatProcedure : INotifyPropertyChanged
    {

        public FormatProcedure()
        {
            Input = "Example";
            Format = "'_DATA_'";
            Delimiter = ",";
        }


        private String _Input;

        public String Input
        {
            get { return _Input; }
            set { 
                _Input = value;
                OnPropertyChanged("Input");
            }
        }

        private String _Format;

        public String Format 
        {
            get { return _Format; }
            set { 
                _Format= value;
                OnPropertyChanged("Format");


            }
        }


        private String _Delimiter;

        public String Delimiter
        {
            get { return _Delimiter; }
            set { 
                _Delimiter = value;
                OnPropertyChanged("Delimter");


            }
        }


        private String _Output;

        public String Output
        {
            get { return _Output; }
            set { 
                _Output = value;
                OnPropertyChanged("Output");
            
            }
        }

        public void formatInput()
        {
            Output = "";
            String [] array = Input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int count = 1;
            foreach (String item in array)
            {
                Output += Format.Replace("_DATA_", item).Replace("_#_",count.ToString()) + Delimiter + '\n';
                count++;
            }
            int delimLength = Delimiter.Length + 1;
            Output = Output.Remove(Output.Length - delimLength);
            

        }
        
        public void addData()
        {
            Format += "_DATA_";

        }

        public void addNumbering()
        {
            Format += "_#_";

        }



        #region INofityPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged (String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }


        }

        #endregion

    }

}
