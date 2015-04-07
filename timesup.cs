using AppIndicator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using TimerNS;
using Gtk;

public
class TimesUp : Form {
    private System.Windows.Forms.Button button;
    private System.Windows.Forms.Button deleteButton;
    private StatusBarPanel statusbar;
    private DateTimePicker dtp = new DateTimePicker();
    public System.Windows.Forms.Label currentTimeLabel;
    private TextBox textMsg;
    private System.Windows.Forms.TreeView timerTree;
    // private TreeView timerTree;
    List<TimerObj> timerList = new List<TimerObj>();

    private int currentIndex = -1;
    private static System.Timers.Timer TickTimer;

    private TimesIndicator appIndicator = new TimesIndicator();
    private ApplicationIndicator indicator;

// BEGIN APP INDICATOR
    private String _ExecutableFolder = "";
    private String ExecutableFolder {
        get {
            if (_ExecutableFolder == "")
                _ExecutableFolder = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            return _ExecutableFolder;
        }
    } // END ExecutableFolder 

    public TimesUp() {
		int x = 90;
		int y = 50;

		Text = "Times Up! Timer Application";

                BuildMenu();

		this.BackColor = System.Drawing.Color.Blue;
		this.Padding = new System.Windows.Forms.Padding(20);

		textMsg = new TextBox();
		textMsg.Location = new Point(x, y);
		textMsg.Text = "Enter text here";
		textMsg.Parent = this;
		y = y + 35;

		button = new System.Windows.Forms.Button();
		button.BackColor = System.Drawing.Color.Gray;
		button.Text = "Start Timer";
		button.Location = new Point(x - 25, y);
		button.Click += new EventHandler(OnClick);
		button.Size = new Size(75, 25);
		button.Parent = this;

		currentTimeLabel = new System.Windows.Forms.Label();
		currentTimeLabel.Location = new Point(x + 15, y + 35);
		currentTimeLabel.ForeColor = System.Drawing.Color.White;
		currentTimeLabel.Parent = this;

		deleteButton = new System.Windows.Forms.Button();
		deleteButton.BackColor = System.Drawing.Color.Gray;
		deleteButton.Text = "Delete";
		deleteButton.Location = new Point(x + 55, y);
		deleteButton.Click += new EventHandler(DeleteClicked);
		deleteButton.Size = new Size(75, 25);
		deleteButton.Parent = this;

		dtp.Format = DateTimePickerFormat.Time;
		dtp.Size = new Size(500, 100);
		dtp.Dock = DockStyle.Fill;
		// Create a datetime while adding 5 minutes
		dtp.Value = DateTime.Now.Add(new TimeSpan(0,5,0));
		dtp.Parent = this;
		y = y + 30;

		dtp.Parent = this;
		y = y + 30;

		timerTree = new System.Windows.Forms.TreeView();
		timerTree.Location = new Point(20, y);
		timerTree.Size = new Size(250, 100);
		timerTree.Click += new EventHandler(TreeClicked);
		timerTree.Parent = this;

		StatusBar statusBar1 = new StatusBar();
		statusbar = new StatusBarPanel();
		statusBar1.BackColor = System.Drawing.Color.Gray;
		statusbar.Text = "Ready...";
		statusBar1.ShowPanels = true;
		statusBar1.Panels.Add(statusbar);
		this.Controls.Add(statusBar1);

        TickTimer = new System.Timers.Timer(1000);
        TickTimer.Elapsed += TickClock;
        TickTimer.Enabled = true;

		CenterToScreen();

        TickClock(this, null);
	}

    void TickClock(object source, ElapsedEventArgs e) {
	    currentTimeLabel.Text = DateTime.Now.ToLongTimeString();
    }

    void resetTimer() {
		button.Text = "Start Timer";
		return;
	}

	void TreeClicked(object sender, EventArgs e) {
		// Console.WriteLine(" tree clicked");
                System.Windows.Forms.TreeNode node = timerTree.SelectedNode;
		currentIndex = node.Index;
	}

	void DeleteTimer(int index) {
		timerList[index].Stop();
		timerList.RemoveAt(index);
		timerTree.Nodes[index].Remove();
	}

	/* Given a string, the name, which is == to ObjectId,
	 * find the actual int node on tree view which matches it */
	int FindIndexByName(String s) {
		// Console.WriteLine("FindIndexByName: " + s);
		int i = 0;
		foreach(System.Windows.Forms.TreeNode tn in timerTree.Nodes) {
			// Console.WriteLine(tn.Name);
			if (tn.Name == s) return i;
			i++;
		}
		return -1;
	}  // END FindIndexByName()

	void DeleteTimer(String s) {
		int i;
		i = FindIndexByName(s);
		//Console.WriteLine("DeleteTimer: " + i);
		DeleteTimer(i);
	}

	void DeleteClicked(object sender, EventArgs e) {
		// Console.WriteLine(" delete clicked");
		// Console.WriteLine(currentIndex);
		if (-1 == currentIndex) return;

		DeleteTimer(currentIndex);

	}  // END DeleteClicked()

	void OnTimerDeleted(object sender, EventArgs e) {
		//Console.WriteLine(
		//   "TODO: find and delete appropriate node on tree");
		TimerObj timerobj = sender as TimerObj;
		DeleteTimer(timerobj.ObjectId.ToString());
	}

	void OnClick(object sender, EventArgs e) {

		DateTime chosenTime = dtp.Value;
		TimeSpan setTime = chosenTime.Subtract(DateTime.Now);

		if (setTime.TotalSeconds < 1) {
			statusbar.Text = "Time Must be in Future";
			return;
		}

		statusbar.Text = "Timer started.";
		// button.Text = "Stop";

		TimerObj myTimer = new TimerObj();
		myTimer.TimerDeleted +=
		    new TimerObj.ChangedEventHandler(OnTimerDeleted);

               // textMsg = textMsg + " [" + chosenTime.ToString() + "]";
               String treeString = textMsg.Text + " [" + chosenTime.ToString() + "]";

		// TreeNode node = new TreeNode(textMsg.Text);
                System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode(treeString);
		node.Name = myTimer.ObjectId.ToString();
		timerTree.Nodes.Add(node);

		/* Adds the event and the event handler for the method that will
			  *           process the timer event to the timer. */
		myTimer.Tick += new EventHandler(TimerEventProcessor);

		myTimer.Interval = (int)setTime.TotalSeconds * 1000;
		myTimer.setText(textMsg.Text);
		timerList.Add(myTimer);
		myTimer.Start();
	} // END OnClick

       private
	void TimerEventProcessor(object myObject, EventArgs myEventArgs) {
		resetTimer();
	}

	private void BuildMenu()
	{
		ApplicationIndicator indicator = 
			new ApplicationIndicator (
				"sample-application", 		//id of the the indicator icon
				"app-icon",			        //file name of the icon (will look for app-icon.png) 
				Category.ApplicationStatus, 
				ExecutableFolder            //the folder where to look for app-icon.png
				);	
	
		//Build Popup Menu for ApplicationIndicator
		Gtk.Menu popupMenu = new Gtk.Menu ();

		//Show menu item
		ImageMenuItem menuItemShow = new ImageMenuItem ("Show");
		menuItemShow.Image = new Gtk.Image(Stock.Info, IconSize.Menu);
		menuItemShow.Activated += (sender, e) => this.Visible = !this.Visible;
		popupMenu.Append(menuItemShow);

		popupMenu.Append(new SeparatorMenuItem());

		//Quit menu item
		ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
		menuItemQuit.Image = new Gtk.Image (Stock.Quit, IconSize.Menu);
		//menuItemQuit.Activated += (sender, e) => Application.Quit ();
		popupMenu.Append (menuItemQuit);
		
		popupMenu.ShowAll();
		
		//Assign menu and make indicator active
		indicator.Menu = popupMenu;
		indicator.Status = AppIndicator.Status.Active;	
	}

	static public void Main() { System.Windows.Forms.Application.Run(new TimesUp()); }

}  // END public class TimesUp : Form
   // Sat May 24 17:29:07 PDT 2014
