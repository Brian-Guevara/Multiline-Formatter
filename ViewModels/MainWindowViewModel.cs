using GalaSoft.MvvmLight.Command;
using MultiLineStringFormatter.Models;
using System.Windows.Input;

namespace MultiLineStringFormatter.ViewModels
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            _Format = new FormatProcedure();
        }

        private FormatProcedure _Format;

        public FormatProcedure Format
        {
            get { return _Format; }

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
            Format.formatInput();

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
            Format.addData();

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
            Format.addNumbering();

        }

    }
}
