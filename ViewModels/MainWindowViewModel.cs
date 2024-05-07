

namespace MultiLineStringFormatter.ViewModels;

using GalaSoft.MvvmLight.Command;
using MultiLineStringFormatter.Models;
using System.Windows.Input;

internal class MainWindowViewModel
{
    public MainWindowViewModel() => this.FormatProcess = new FormatProcedure();

    public FormatProcedure FormatProcess { get; }

    public ICommand UpdateOutput => new RelayCommand(this.FormatProcess.formatInput);

    public ICommand AddData => new RelayCommand(this.FormatProcess.addData);

    public ICommand AddNumbering => new RelayCommand(this.FormatProcess.addNumbering);
}
