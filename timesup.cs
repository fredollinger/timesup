using System;
using System.Drawing;
using System.Threading;
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

		class TimerExampleState {
        public int counter = 0;
        public System.Windows.Forms.Timer tmr;
		}

    private Button button; 
		private Popup pop;

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

				pop = new Popup();

        CenterToScreen();
    }

    void OnClick(object sender, EventArgs e) {
	    //MessageBox.Show("Your've selected the meeting date: " 
			//										     + dtp.Value.Date);
				Console.WriteLine("date");
        button.Text = "Stop";
				TimerExampleState s = new TimerExampleState();
				TimerCallback timerDelegate = new TimerCallback(CheckStatus);
				System.Threading.Timer timer = new System.Threading.Timer(timerDelegate, s, 1000, 1000);
    }

		 //static void CheckStatus(Object state) {
		 void CheckStatus(Object state) {
				TimerExampleState s = (TimerExampleState) state;
				Console.WriteLine("Timer Action!!");
        button.Text = "Start";
				pop.Show();
				s.tmr.Dispose();
				s.tmr = null;
     }

} // END public class TimesUp : Form
