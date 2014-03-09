using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace TimerNS{
public class TimerObj : System.Windows.Forms.Timer {
    public class Popup : Form {
        private Button button; 
			  private Label label;
        public Popup (String str){
				    this.CenterToScreen();

            this.BackColor = System.Drawing.Color.Red;
            Text = str;

						label = new Label();
            label.ForeColor = System.Drawing.Color.White;
						label.Text=str;
            label.Location = new Point(30, 70);
						label.Parent=this;

            button = new Button();
            button.BackColor = System.Drawing.Color.Gray;
            button.Text = "OK";
            button.Location = new Point(30, 150);
            button.Parent = this;
        }// public Popup()
    } // public class Popup : Form {
		private String text="Times Up";

    public TimerObj(){
		    Tick += new EventHandler(TimerEventProcessor);
		}

    public void setText(String str){
       text=str; 
		}

    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
				showpopup();
    }

		private Popup pop;
    public void showpopup() {
		    pop = new Popup(text);
		    pop.Show();
    }
}
} // namespace TimerNS
