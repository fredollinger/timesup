using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace TimerNS{
public class TimerObj : System.Windows.Forms.Timer {
		private String text="Times Up";
		public delegate void ChangedEventHandler(object sender, EventArgs e);
  	public event ChangedEventHandler TimerDeleted;

    public TimerObj(){
		    Tick += new EventHandler(TimerEventProcessor);
		}

		protected virtual void OnTimerDeleted(EventArgs e){
				if (TimerDeleted != null)
				TimerDeleted(this, e);
		}

    public void setText(String str){
       text=str; 
		}

    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
        Stop();
				showtimesup();
    }

		private TimerPopup pop;
    public void showtimesup() {
		    pop = new TimerPopup(text);
        pop.BackColor = System.Drawing.Color.Red;
        pop.buttonDelete.Click += new EventHandler(HandleDelete);
		    pop.Show();
    }

    void HandleDelete(object sender, EventArgs e) {
				Console.WriteLine( "Delete clicked");
				OnTimerDeleted(EventArgs.Empty);
				pop.Close();
    }
}
} // namespace TimerNS
