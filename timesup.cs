using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TimerNS;

public class TimesUp : Form
{
    private Button button; 
    private bool started=false;
    private StatusBarPanel statusbar;
	  static TimerObj myTimer = new TimerObj();
    private DateTimePicker dtp = new DateTimePicker();
    private Label timeLeftLabel;
    private TextBox textMsg;
	  private	TreeView timerTree;
    List<TimerObj> timerList = new List<TimerObj>();

    public TimesUp ()
    {
				int x=90;
				int y=50;

        Text = "Times Up! Timer Application";

        this.BackColor = System.Drawing.Color.Blue;
        this.Padding = new System.Windows.Forms.Padding(20);

				textMsg = new TextBox();
        //textMsg.Location = new Point(20, 60);
        textMsg.Location = new Point(x, y);
				textMsg.Text = "Enter text here";
        textMsg.Parent = this;
				y=y+35;

        button = new Button();
        button.BackColor = System.Drawing.Color.Gray;
        button.Text = "Start Timer";
        button.Location = new Point(x+10, y);
        button.Click += new EventHandler(OnClick);
        button.Size = new Size(75,25);
        button.Parent = this;

        dtp.Format = DateTimePickerFormat.Time;
        dtp.Size = new Size(500,100);
        //textMsg.Location = new Point(x, y);
        dtp.Dock = DockStyle.Fill;
        dtp.Parent = this;
				y=y+30;

				timerTree = new TreeView();
        timerTree.Location = new Point(20, y);
        timerTree.Size = new Size(250,100);
				timerTree.Parent = this;

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

				timerTree.Nodes.Add(textMsg.Text);

        started=true;
        statusbar.Text = "Timer started.";
        button.Text = "Stop";
		    myTimer.Interval = (int) setTime.TotalSeconds * 1000;
				myTimer.setText(textMsg.Text);
		    myTimer.Start();

        // FRED: NEED TO MOVE THIS TO ARRAY
        //TimerObj timerobj=new TimerObj();
    }

    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
        resetTimer();
     }

    static public void Main ()
    {
        Application.Run (new TimesUp ());
    }

} // END public class TimesUp : Form
