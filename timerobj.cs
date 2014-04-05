using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace TimerNS{
public class TimerObj : System.Windows.Forms.Timer {
		private String text="Times Up";

    public TimerObj(){
		    Tick += new EventHandler(TimerEventProcessor);
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
		    pop.Show();
    }
}
} // namespace TimerNS
