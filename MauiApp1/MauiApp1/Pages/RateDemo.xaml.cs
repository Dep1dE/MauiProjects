using MauiApp1.Entities;
using MauiApp1.Services;

namespace MauiApp1;


public partial class RateDemo : ContentPage
{
    List<string> Currencies = new List<string>();
    List<Rate> Changewards;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;

    private readonly IRateService _rateService;
    public RateDemo(IRateService rateService)
    {
        _rateService = rateService;
        FillCurrencies();
        InitializeComponent();
        MyDatePicker.MaximumDate = DateTime.Today;
        Changewards=(List<Rate>)_rateService.GetMyRates(MyDatePicker.Date);
    }

    private void LoadRatePickerItems(object sender, EventArgs e)
    {
        foreach (var current in Currencies)
        {
            RatePicker.Items.Add(current);

        }
    }
    private void LoadRatePickerItemsForChange(object sender, EventArgs e)
    {
        foreach (var current in Currencies)
        {
            RatePickerForChange.Items.Add(current);

        }
    }

    private void FillCurrencies()
    {
        Currencies.Add("Российский рубль");
        Currencies.Add("Евро");
        Currencies.Add("Доллар США");
        Currencies.Add("Швейцарский франк");
        Currencies.Add("Китайский юань");
        Currencies.Add("Фунт стерлингов");
    }

    private void IndexChangedForDate(object sender, EventArgs e)
    {
        List<Rate> wards = (List<Rate>)_rateService.GetMyRates(MyDatePicker.Date);
        CurrentLabel.Text = "Курс валюты на эту дату: " + wards[RatePicker.SelectedIndex].Cur_OfficialRate.ToString() + " бел. руб";
    }

    private void DateChanged(object sender, EventArgs e)
    {
        List<Rate> wards = (List<Rate>)_rateService.GetMyRates(MyDatePicker.Date);
        if (RatePicker.SelectedIndex==-1)
        {
            RatePicker.SelectedIndex = 0;
        }
        CurrentLabel.Text = "Курс валюты на эту дату: " + wards[RatePicker.SelectedIndex].Cur_OfficialRate.ToString() + " бел. руб";
    }

    private void BelTextChanged(object sender, EventArgs e)
    {
        if (!flag2)
        {
            flag1 = true;
            if (RatePickerForChange.SelectedIndex == -1)
            {
                flag3 = true;
                RatePickerForChange.SelectedIndex = 0;
            }
            if (Bel.Text != "")
            {
                double rate = Double.Parse(Changewards[RatePickerForChange.SelectedIndex].Cur_OfficialRate.ToString());
                foreign.Text = (Double.Parse(Bel.Text)/rate).ToString();
            }
            flag1 = false;
        }
    }
    private void ForeignTextChanged(object sender, EventArgs e)
    {
        if (!flag1)
        {
            flag2 = true;
            if (RatePickerForChange.SelectedIndex == -1)
            {
                flag3 = true;
                RatePickerForChange.SelectedIndex = 0;
            }
            if (foreign.Text != "")
            {
                double rate = Double.Parse(Changewards[RatePickerForChange.SelectedIndex].Cur_OfficialRate.ToString());
                Bel.Text = (rate * Double.Parse(foreign.Text)).ToString();
            }
            flag2 = false;
        }
    }

    private void IndexChanged(object sender, EventArgs e)
    {
        if (!flag3)
        {
            Bel.Text = "1";
        }
        else
        {
            flag3 = false;
        }
    }
}