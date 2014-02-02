using System;
using System.Drawing;
using System.Windows.Forms;

public class HelloWorld : Form
{
    static public void Main ()
    {
        Application.Run (new HelloWorld ());
    }

    public HelloWorld ()
    {
        Text = "Times Up! Timer Application";

        Button button = new Button();
        button.Text = "Button";
        button.Location = new Point(30, 70);
        button.Click += new EventHandler(OnClick);
        button.Parent = this;

        DateTimePicker dtp = new DateTimePicker();
        dtp.Parent = this;

        CenterToScreen();
    }

    void OnClick(object sender, EventArgs e) {
				/*
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        if (dialog.ShowDialog(this) == DialogResult.OK) {
								Console.WriteLine("Clicked");
        }
				*/
        //dtp.BringToFront();
				Console.WriteLine("date");
    }
}
