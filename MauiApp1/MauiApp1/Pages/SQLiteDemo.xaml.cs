using MauiApp1.Entities;
using MauiApp1.Services;

namespace MauiApp1;

public partial class SQLiteDemo : ContentPage
{
    private readonly IDbService _dbService;
    public SQLiteDemo(IDbService dbService)
	{
        _dbService = dbService;
        InitializeComponent();        
    }
    private void LoadWardsPickerItems(object sender, EventArgs e)
    {
        _dbService.Init();
        var wards = _dbService.GetAllWards();
        foreach (var ward in wards)
        {
            WardsPicker.Items.Add($"Палата №{ward.Number} ФИО врача: {ward.FioMainDoctor}");
        }
        WardsPicker.Items.Remove("Палата №0 ФИО врача: ");
    }

    private void IndexChanged(object sender, EventArgs e)
    {
        var wards = _dbService.GetAllWards();
        string str = WardsPicker.SelectedItem.ToString()!;
        int wardId= 0;
        int index = 0;
        foreach (Ward ward in wards)
        {
            if ($"Палата №{ward.Number} ФИО врача: {ward.FioMainDoctor}" == str)
            {
                wardId = ward.Id; break;
            }
            index++;
        }
       // var ward = wards.First(w => w.FioMainDoctor == str);

        var patients = _dbService.GetWardPatients(wardId);
        List<string> patientsInfo = new List<string>();
        foreach (Patient patient in patients)
        {
            patientsInfo.Add($"ФИО: {patient.Fio}. Диагноз: {patient.Diagnosis}. Дней болезни: {patient.TreatmentDays}");
        }
        Collection.ItemsSource = patientsInfo;
    }
}