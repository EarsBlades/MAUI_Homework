namespace MauiApp1.View;

public partial class MainPage : ContentPage
{
    
    private List<string> Mass = new List<string>();
    private string password = "1234";

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnButtonClicked(object sender, EventArgs e) 
    { 
        Entry.Text += (sender as Button)?.Text;
        Mass.Add((sender as Button)?.Text);
    }

    private void OnButtonClickedRes(object sender, EventArgs e)
    {
        if (Entry.Text.Length != 0)
        {
            Entry.Text = Entry.Text.Remove(Entry.Text.Length - 1, 1);
            Mass.RemoveAt(Mass.Count - 1);
        }
    }

    private void OnButtonClickedDone(object sender, EventArgs e)
    {
        string res = "";
        foreach (var i in Mass)
        {
            res += i;
        }

        if (res == password)
        {
            Entry.TextColor = Colors.Aqua;
            Nutton1.IsEnabled = false;
        }
        else
        {
            Entry.Text = "";
            Mass.Clear();
        }
        
    }
}