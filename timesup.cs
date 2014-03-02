using System;
using System.Drawing;
using System.Windows.Forms;

public class TimesUp : Form
{
    public class Popup : Form {
        private Button button; 
        public Popup (){
            Text = "Times Up!";
            button = new Button();
            button.BackColor = System.Drawing.Color.Gray;
            button.Text = "OK";
            button.Location = new Point(30, 70);
            button.Parent = this;
        }

    }

    static public void Main ()
    {
        Application.Run (new TimesUp ());
    }

    private Button button; 
    private bool started=false;
    private StatusBarPanel statusbar;
	private Popup pop;
	static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    private DateTimePicker dtp = new DateTimePicker();

    public TimesUp ()
    {
        Text = "Times Up! Timer Application";

        this.BackColor = System.Drawing.Color.Blue;
        this.Padding = new System.Windows.Forms.Padding(20);

        button = new Button();
        button.BackColor = System.Drawing.Color.Gray;
        button.Text = "Start Timer";
        button.Location = new Point(30, 70);
        button.Click += new EventHandler(OnClick);
        button.Size = new Size(75,25);
        button.Parent = this;

        dtp.Format = DateTimePickerFormat.Time;
		dtp.ShowUpDown = true;
		dtp.CustomFormat = "HH:mm";
		dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtp.Size = new Size(500,100);
        dtp.Dock = DockStyle.Fill;
        dtp.Parent = this;

        StatusBar statusBar1 = new StatusBar();
        statusbar = new StatusBarPanel();
        statusBar1.BackColor = System.Drawing.Color.Gray;
        statusbar.Text = "Ready...";
        statusBar1.ShowPanels = true;
        statusBar1.Panels.Add(statusbar);
        this.Controls.Add(statusBar1);

        /* Adds the event and the event handler for the method that will 
	  	  *           process the timer event to the timer. */
		myTimer.Tick += new EventHandler(TimerEventProcessor);


        CenterToScreen();
    }

    void resetTimer() {
        button.Text = "Start Timer";
        myTimer.Stop();
        started=false;
        return;
    }

    void OnClick(object sender, EventArgs e) {
        if (started){
            resetTimer(); 
            return;
        }

		DateTime chosenTime=dtp.Value;
		TimeSpan setTime=chosenTime.Subtract(DateTime.Now);
	    Console.WriteLine( "date: " + myTimer.Interval.ToString() );
        if (setTime.TotalSeconds < 1){
            statusbar.Text = "Time Must be in Future";
            return;
        }
        started=true;
        statusbar.Text = "Timer started.";
        button.Text = "Stop";
		myTimer.Interval = (int) setTime.TotalSeconds * 1000;
		myTimer.Start();
    }

    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
        resetTimer();
        /*
        myTimer.Stop();
        started=false;
	    Console.WriteLine("Timer Action!!");
        button.Text = "Start Timer";
        */

		pop = new Popup();
		pop.Show();
     }

} // END public class TimesUp : Form
