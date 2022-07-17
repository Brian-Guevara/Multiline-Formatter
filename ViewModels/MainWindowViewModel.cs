using GalaSoft.MvvmLight.Command;
using MultiLineStringFormatter.Models;
using System.Windows.Input;

namespace MultiLineStringFormatter.ViewModels
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            _FormatProcess = new FormatProcedure();
        }

        private FormatProcedure _FormatProcess;

        public FormatProcedure FormatProcess
        {
            get { return _FormatProcess; }

        }


        public ICommand UpdateOutput
        {
            get
            {
                return new RelayCommand(formatText, () => true);
            }
        }

        public void formatText()
        {
            FormatProcess.formatInput();

        }

        public ICommand AddData
        {
            get
            {
                return new RelayCommand(_AddData, () => true);
            }
        }

        public void _AddData()
        {
            FormatProcess.addData();

        }

        public ICommand AddNumbering
        {
            get
            {
                return new RelayCommand(_AddNumbering, () => true);
            }
        }

        public void _AddNumbering()
        {
            FormatProcess.addNumbering();

        }

    }
}
