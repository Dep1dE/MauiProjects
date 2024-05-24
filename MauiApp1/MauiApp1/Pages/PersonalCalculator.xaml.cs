namespace MauiApp1;

public partial class PersonalCalculator : ContentPage
{
    int count = 0;
    string result = "";
    double realresult = 0;
    double x;
    int y;
    bool flag = false;
    bool flag1 = false;
    public PersonalCalculator()
	{
		InitializeComponent();
	}
    private void outputLabel(object sender, EventArgs e)
    {
        ouputLabel.Text = result;
    }

    private void numberButton(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            if (flag)
            {
                result = "";
                flag = false;
            }
            if (button.Text == ",")
            {
                if (result == "")
                {
                    result += "0,";
                }
                else
                {
                    result += button.Text;
                }
            }
            else
            {
                result += button.Text;
            }
            ouputLabel.Text = result;
        }
    }

    private void deleteAllSymbols(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            flag = false;
            realresult = 0;
            result = "";
            ouputLabel.Text = "0";
        }
    }

    private void deleteOneSymbol(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {

            if (result.Length == 0)
            {

                ouputLabel.Text = "0";
            }
            else if (result.Length == 1)
            {
                result = result.Remove(result.Length - 1);
                ouputLabel.Text = "0";
            }
            else
            {
                result = result.Remove(result.Length - 1);
                ouputLabel.Text = result;
            }

        }
    }

    private void saveX(object sender, EventArgs e)
    {
        Button button = new Button();
        if (button != null)
        {
            x=Double.Parse(ouputLabel.Text);
            flag = true;
        }
    }

    private void saveY(object sender, EventArgs e)
    {
        Button button = new Button();
        if (button != null)
        {
            y = Int32.Parse(ouputLabel.Text);
            flag = true;
        }
    }

    private void getResult(object sender, EventArgs e)
    {
        Button button = new Button();
        if (button != null)
        {
            realresult= Math.Pow(x, y); 
            ouputLabel.Text=realresult.ToString();
            flag = true;
        }
    }


}