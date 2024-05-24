using System.Text.RegularExpressions;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        string result = "";
        double realresult = 0;
        string sign = "";
        bool flag = false;
        bool flag1 = false;

        public MainPage()
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
                if(flag) { 
                    result = ""; 
                    flag = false;
                }
                if(button.Text==",")
                {
                    if(result == "")
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


        private void functionButton(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if(!flag1)
                {
                    realresult += Double.Parse(ouputLabel.Text);
                }   
                flag = true;
                flag1 = true;
                
                switch (sign)
                {
                    case "+":
                        realresult += Double.Parse(ouputLabel.Text);
                        result=realresult.ToString();
                        ouputLabel.Text=result;
                        break;

                    case "-":
                        realresult -= Double.Parse(ouputLabel.Text);
                        result = realresult.ToString();
                        ouputLabel.Text = result;
                        break;

                    case "*":
                        realresult *= Double.Parse(ouputLabel.Text);
                        result = realresult.ToString();
                        ouputLabel.Text = result;
                        break;

                    case "/":
                        realresult /= Double.Parse(ouputLabel.Text);
                        result = realresult.ToString();
                        ouputLabel.Text = result;
                        break; 

                    case "%":
                        realresult = (realresult*Double.Parse(ouputLabel.Text))/100;
                        result = Math.Round(realresult, 5).ToString();
                        ouputLabel.Text = result;
                        break;
                }
                if (button.Text == "=")
                {
                    sign = "";
                    flag = false;
                    flag1 = false;
                    ouputLabel.Text = result;
                    realresult = 0;
                }
                else {sign=button.Text; }
                
            }
        }

    }
}
