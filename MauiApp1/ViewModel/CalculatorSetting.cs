
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1.Model;

namespace MauiApp1.ViewModel;

public class CalculatorSetting : INotifyPropertyChanged
{
    private string _displayTextNumber = "";
    private string _displayTextChar;
    private double? _doubleNumber;
    private char _specialChar;
    
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand AddNumbers { get; private set; }
    public ICommand AddCharSymbol { get; private set; }
    public ICommand DeleteNumbers { get; private set; }
    public ICommand Eq { get; private set; }
    public CalculatorSetting()
    {
        AddNumbers = new Command<string>((key) => DisplayTextNumber += key);
        AddCharSymbol = new Command<string>((key) => DisplayTextChar = key);
        DeleteNumbers = new Command(() => DisplayTextNumber = "",
                                    () => DisplayTextNumber.Length > 0);
        Eq = new Command(Equally);
    }

    public string DisplayTextNumber
    {
        get => _displayTextNumber;
        private set
        {
            if (_displayTextNumber != value)
            {
                _displayTextNumber = value;
                OnPropertyChanged();

                ((Command)DeleteNumbers).ChangeCanExecute();
            }
        }
    }

    public string DisplayTextChar
    {
        get => _displayTextChar;
        private set
        {
            if (_displayTextChar != value)
            {
                _displayTextChar = value;
                OnPropertyChanged();
                
                _doubleNumber = Convert.ToDouble(DisplayTextNumber);
                _specialChar = Convert.ToChar(DisplayTextChar);
                DisplayTextNumber += "\n";
            }
        }
    }
    
    private void Equally()
    {
        if (DisplayTextNumber.Split('\n').Last() == "" || _doubleNumber == null)
            return;
        DisplayTextNumber = _specialChar switch
        {
            '+' => (_doubleNumber + Convert.ToDouble(DisplayTextNumber.Split('\n').Last())).ToString(),
            '-' => (_doubleNumber - Convert.ToDouble(DisplayTextNumber.Split('\n').Last())).ToString(),
            '*' => (_doubleNumber * Convert.ToDouble(DisplayTextNumber.Split('\n').Last())).ToString(),
            '/' => (_doubleNumber / Convert.ToDouble(DisplayTextNumber.Split('\n').Last())).ToString(),
            _ => throw new ArgumentOutOfRangeException()
        };
        _displayTextChar = "";
    }

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}