using System;
using System.Drawing;
using System.Windows.Forms;

public class TimesUp : Form
{
    public class Popup : Form {
        public Popup (){
            Text = "Times Up!";
        }
    }

    static public void Main ()
    {
        Application.Run (new TimesUp ());
    }

    private Button button; 

    public TimesUp ()
    {
        Text = "Times Up! Timer Application";

        button = new Button();
        button.Text = "Start Timer";
        button.Location = new Point(30, 70);
        button.Click += new EventHandler(OnClick);
        button.Parent = this;

        DateTimePicker dtp = new DateTimePicker();
				dtp.Format = DateTimePickerFormat.Time;
				dtp.ShowUpDown = true;
				dtp.CustomFormat = "HH:mm";
				dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtp.Parent = this;

        CenterToScreen();
    }

    void OnClick(object sender, EventArgs e) {
	    //MessageBox.Show("Your've selected the meeting date: " 
			//										     + dtp.Value.Date);
				Console.WriteLine("date");
        button.Text = "Stop";
				Popup pop = new Popup();
				pop.Show();
    }
}
