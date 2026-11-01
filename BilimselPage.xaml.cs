using System;
using Microsoft.Maui.Controls;

namespace HesapMakinesi;

public partial class BilimselPage : ContentPage
{
    double number1 = 0;
    string operatorSymbol = "";
    bool isNewInput = true;

    public BilimselPage()
    {
        InitializeComponent();
    }
    private void NumClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        if (isNewInput || cScreen.Text == "0")
        {
            cScreen.Text = btn.Text;
            isNewInput = false;
        }
        else
        {
            cScreen.Text += btn.Text;
        }
    }

    private void OperatorClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        if (double.TryParse(cScreen.Text, out number1))
        {
            operatorSymbol = btn.Text;
            lblHistory.Text = $"{number1} {operatorSymbol}";
            isNewInput = true;
        }
    }

    private void EqualClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(cScreen.Text, out double number2))
            return;

        double result = 0;

        switch (operatorSymbol)
        {
            case "+": result = number1 + number2; break;
            case "-": result = number1 - number2; break;
            case "x": result = number1 * number2; break;
            case "÷": result = number2 != 0 ? number1 / number2 : 0; break;
            case "mod": result = number1 % number2; break;
            case "x^y": result = Math.Pow(number1, number2); break;
        }

        cScreen.Text = result.ToString();
        lblHistory.Text = $"{number1} {operatorSymbol} {number2}";
        number1 = result;
        isNewInput = true;
    }

    private void FunctionClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        string func = btn.Text;

        if (!double.TryParse(cScreen.Text, out double value))
            value = 0;

        double result = value;

        switch (func)
        {
            case "?": result = Math.PI; break;
            case "e": result = Math.E; break;
            case "x²": result = Math.Pow(value, 2); break;
            case "1/x": result = value != 0 ? 1 / value : 0; break;
            case "|x|": result = Math.Abs(value); break;
            case "exp": result = Math.Exp(value); break;
            case "10^x": result = Math.Pow(10, value); break;
            case "log": result = Math.Log10(value); break;
            case "ln": result = Math.Log(value); break;
            case "n!": result = Factorial((int)value); break;
            case "²?x":
                if (value < 0)
                {
                    cScreen.Text = "Geçersiz (negatif ?)";
                    return;
                }
                result = Math.Sqrt(value);
                break;
        }

        cScreen.Text = result.ToString();
        isNewInput = true;
    }
 

    private void TrigonometriToggle(object sender, EventArgs e)
    {
        TrigPanel.IsVisible = !TrigPanel.IsVisible;
    }


    private void TrigFunctionClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        string func = btn.Text;

        if (!double.TryParse(cScreen.Text, out double value))
            value = 0;

        double radians = value * Math.PI / 180;
        double result = 0;

        switch (func)
        {
            case "sin": result = Math.Sin(radians); break;
            case "cos": result = Math.Cos(radians); break;
            case "tan": result = Math.Tan(radians); break;
            case "cot": result = 1 / Math.Tan(radians); break;
            case "sec": result = 1 / Math.Cos(radians); break;
            case "csc": result = 1 / Math.Sin(radians); break;
            case "hyp": result = Math.Sqrt(value * value + 1); break;
        }

        cScreen.Text = result.ToString();
        isNewInput = true;
    }
 
    private void IslevToggle(object sender, EventArgs e)
    {
        IslevPanel.IsVisible = !IslevPanel.IsVisible;
        
        if (TrigPanel.IsVisible)
            TrigPanel.IsVisible = false;
    }


    private void IslevFunctionClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        string func = btn.Text;

        if (!double.TryParse(cScreen.Text, out double value))
            value = 0;

        double result = value;

        switch (func)
        {
            case "|x|": result = Math.Abs(value); break;
            case "[x]": result = Math.Floor(value); break; 
            case "rand": result = new Random().NextDouble(); break;
            case "?dms": break;
            case "?deg": break;
                
        }

        cScreen.Text = result.ToString();
        isNewInput = true;
    }


   


    private void ClearClicked(object sender, EventArgs e)
    {
        cScreen.Text = "0";
        lblHistory.Text = "";
        number1 = 0;
        operatorSymbol = "";
        isNewInput = true;
    }

    private void BackspaceClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(cScreen.Text) && cScreen.Text.Length > 1)
            cScreen.Text = cScreen.Text[..^1];
        else
            cScreen.Text = "0";
    }


    private double Factorial(int n)
    {
        if (n < 0) return double.NaN;
        double result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }
}
