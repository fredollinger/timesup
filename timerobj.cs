using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace TimerNS{
public class TimerObj : System.Windows.Forms.Timer {
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
	  private Popup pop;
    public TimerObj(){
		    Tick += new EventHandler(TimerEventProcessor);
		}


    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
		    pop = new Popup();
		    pop.Show();
    }
}
} // namespace TimerNS
