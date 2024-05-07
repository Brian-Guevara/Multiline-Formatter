using GalaSoft.MvvmLight.Command;
using MultiLineStringFormatter.Models;
using System.Windows.Input;

namespace MultiLineStringFormatter.ViewModels
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this._FormatProcess = new FormatProcedure();
        }

        private FormatProcedure _FormatProcess;

        public FormatProcedure FormatProcess
        {
            get { return this._FormatProcess; }
        }

        public ICommand UpdateOutput
        {
            get
            {
                return new RelayCommand(this.formatText, () => true);
            }
        }

        public void formatText()
        {
            this.FormatProcess.formatInput();
        }

        public ICommand AddData
        {
            get
            {
                return new RelayCommand(this._AddData, () => true);
            }
        }

        public void _AddData()
        {
            this.FormatProcess.addData();
        }

        public ICommand AddNumbering
        {
            get
            {
                return new RelayCommand(this._AddNumbering, () => true);
            }
        }

        public void _AddNumbering()
        {
            this.FormatProcess.addNumbering();
        }
    }
}
