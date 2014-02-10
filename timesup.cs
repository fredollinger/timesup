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
		private Popup pop;
		static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

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


        /* Adds the event and the event handler for the method that will 
	  	  *           process the timer event to the timer. */
				myTimer.Tick += new EventHandler(TimerEventProcessor);


        CenterToScreen();
    }

    void OnClick(object sender, EventArgs e) {
				myTimer.Interval = 1000;
				myTimer.Start();
			  Console.WriteLine("date");
        button.Text = "Stop";
    }

		 //static void CheckStatus(Object state) {
		 //void CheckStatus(Object state) {
    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
			  myTimer.Stop();
				Console.WriteLine("Timer Action!!");
        button.Text = "Start Timer";
				pop = new Popup();
				pop.Show();
     }

} // END public class TimesUp : Form
