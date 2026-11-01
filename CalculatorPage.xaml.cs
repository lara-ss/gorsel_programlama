namespace HesapMakinesi;

public partial class CalculatorPage : ContentPage
{
    double number1 = 0;
    string operatorSymbol = "";
    bool isNewInput = true;

    public CalculatorPage()
    {
        InitializeComponent();
    }

    private void NumClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        if (cScreen.Text == "0")
            cScreen.Text = btn.Text;
        else
            cScreen.Text += btn.Text;
    }

    private void OperatorClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        if (double.TryParse(cScreen.Text, out number1))
        {
            operatorSymbol = btn.Text;
            lblHistory.Text = $"{number1} {operatorSymbol}";
            cScreen.Text = "0";
        }
    }

    private void EqualClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(cScreen.Text, out double number2)) return;

        double result = 0;
        switch (operatorSymbol)
        {
            case "+": result = number1 + number2; break;
            case "-": result = number1 - number2; break;
            case "x": result = number1 * number2; break;
            case "÷": result = number2 != 0 ? number1 / number2 : 0; break;
        }

        cScreen.Text = result.ToString();
        lblHistory.Text = $"{number1} {operatorSymbol} {number2}";
        number1 = result;
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        cScreen.Text = "0";
        lblHistory.Text = "";
        number1 = 0;
        operatorSymbol = "";
    }

    private void Square_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(cScreen.Text, out double number))
        {
            lblHistory.Text = $"{number}²";
            cScreen.Text = (number * number).ToString();
        }
    }
    private void karekokAlmaClicked(object sender, EventArgs e)
    {
        if (double.TryParse(cScreen.Text, out double value))
        {
            if (value < 0)
            {
                cScreen.Text = "Geçersiz (?<0)";
            }
            else
            {
                double result = Math.Sqrt(value);
                cScreen.Text = result.ToString();
            }
        }
        else
        {
            cScreen.Text = "Hata";
        }

        isNewInput = true; 
    }

    private void BackSpaceClicked(object sender, EventArgs e)
    {
        cScreen.Text = cScreen.Text.Length > 1 ? cScreen.Text[..^1] : "0";
    }
    private void Standart_Clicked(object sender, EventArgs e)
    {
        Title = "Standart";
     
    }

    private void Bilimsel_Clicked(object sender, EventArgs e)
    {
        Title = "Bilimsel";
        
    }
}
