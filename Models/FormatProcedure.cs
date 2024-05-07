namespace MultiLineStringFormatter.Models
{
    using System;
    using System.ComponentModel;
    using System.IO;

    public class FormatProcedure : INotifyPropertyChanged
    {

        private const String DATATAG = "[[D]]";
        private const String NUMBERTAG= "[[N]]";

        public FormatProcedure()
        {
            this.Input = "Example Text \nTo Test";
            this.Format = "'" + DATATAG +  "'";
            this.Delimiter = ",";
        }


        private String _Input;

        public String Input
        {
            get { return this._Input; }
            set {
                this._Input = value;
                this.OnPropertyChanged("Input");
                this.OnPropertyChanged("Preview");

            }
        }

        private String _Format;

        public String Format
        {
            get { return this._Format; }
            set {
                this._Format = value;
                this.OnPropertyChanged("Format");
                this.OnPropertyChanged("Preview");



            }
        }


        private String _Delimiter;

        public String Delimiter
        {
            get { return this._Delimiter; }
            set {
                this._Delimiter = value;
                this.OnPropertyChanged("Delimter");
                this.OnPropertyChanged("Preview");


            }
        }


        public String Preview
        {
            get {
                try {
                    String preview = this.Input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                    preview = preview.Trim();
                    return this.Format.Replace(DATATAG, preview)
                        .Replace(NUMBERTAG, "1") + this.Delimiter;
                }
                catch
                {
                    return "";

                }

            }

        }



        private String _Output;

        public String Output
        {
            get {return this._Output; }
            set {
                this._Output = value;
                this.OnPropertyChanged("Output");

            }
        }

        public void formatInput()
        {
            this.Output = "";
            String [] array = this.Input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int count = 1;
            foreach (String item in array)
            {
                var text = item.Trim();
                if (text == "")
                {

                }
                else
                {

                    this.Output += this.Format.Replace(DATATAG, text).Replace(NUMBERTAG, count.ToString()) + this.Delimiter + '\n';
                    count++;
                }
            }
            int delimLength = this.Delimiter.Length + 1;
            this.Output = this.Output.Remove(this.Output.Length - delimLength);


        }

        public void addData()
        {
            this.Format += DATATAG;

        }

        public void addNumbering()
        {
            this.Format += NUMBERTAG;

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
