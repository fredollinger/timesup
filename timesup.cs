using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TimerNS;

public
class TimesUp : Form {
       private
	Button button;

       private
	Button deleteButton;

       private
	StatusBarPanel statusbar;

       private
	DateTimePicker dtp = new DateTimePicker();
	// private Label timeLeftLabel;
	private Label currentTimeLabel;
	
       private
	TextBox textMsg;

       private
	TreeView timerTree;
	List<TimerObj> timerList = new List<TimerObj>();

       private
	int currentIndex = -1;

       public
	TimesUp() {
		int x = 90;
		int y = 50;

		Text = "Times Up! Timer Application";

		this.BackColor = System.Drawing.Color.Blue;
		this.Padding = new System.Windows.Forms.Padding(20);

		textMsg = new TextBox();
		textMsg.Location = new Point(x, y);
		textMsg.Text = "Enter text here";
		textMsg.Parent = this;
		y = y + 35;

		button = new Button();
		button.BackColor = System.Drawing.Color.Gray;
		button.Text = "Start Timer";
		button.Location = new Point(x - 25, y);
		button.Click += new EventHandler(OnClick);
		button.Size = new Size(75, 25);
		button.Parent = this;

		currentTimeLabel = new Label();
		currentTimeLabel.Location = new Point(x, y + 35);
		currentTimeLabel.Text = DateTime.Now.ToString();
		currentTimeLabel.ForeColor = System.Drawing.Color.White;
		currentTimeLabel.Parent = this;

		deleteButton = new Button();
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

		timerTree = new TreeView();
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

		CenterToScreen();
	}

	void resetTimer() {
		button.Text = "Start Timer";
		return;
	}

	void TreeClicked(object sender, EventArgs e) {
		Console.WriteLine(" tree clicked");
		TreeNode node = timerTree.SelectedNode;
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
		Console.WriteLine("FindIndexByName: " + s);
		int i = 0;
		foreach(TreeNode tn in timerTree.Nodes) {
			Console.WriteLine(tn.Name);
			if (tn.Name == s) return i;
			i++;
		}
		return -1;
	}  // END FindIndexByName()

	void DeleteTimer(String s) {
		int i;
		i = FindIndexByName(s);
		Console.WriteLine("DeleteTimer: " + i);
		DeleteTimer(i);
	}

	void DeleteClicked(object sender, EventArgs e) {
		Console.WriteLine(" delete clicked");
		Console.WriteLine(currentIndex);
		if (-1 == currentIndex) return;

		DeleteTimer(currentIndex);

	}  // END DeleteClicked()

	void OnTimerDeleted(object sender, EventArgs e) {
		Console.WriteLine(
		    "TODO: find and delete appropriate node on tree");
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
		TreeNode node = new TreeNode(treeString);
		node.Name = myTimer.ObjectId.ToString();
		timerTree.Nodes.Add(node);

		/* Adds the event and the event handler for the method that will
			  *           process the timer event to the timer. */
		myTimer.Tick += new EventHandler(TimerEventProcessor);

		myTimer.Interval = (int)setTime.TotalSeconds * 1000;
		myTimer.setText(textMsg.Text);
		timerList.Add(myTimer);
		myTimer.Start();
	}

       private
	void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
		resetTimer();
	}

	static public void Main() { Application.Run(new TimesUp()); }

}  // END public class TimesUp : Form
   // Sat May 24 17:29:07 PDT 2014
