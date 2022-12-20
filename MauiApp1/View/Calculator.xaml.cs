using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class Calculator : ContentPage
{
    public Calculator()
    {
        InitializeComponent();
        BindingContext = new CalculatorSetting();
    }
}