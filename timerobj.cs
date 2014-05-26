using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace TimerNS{
public class TimerObj : System.Windows.Forms.Timer {
static int idCount = 0;
private String text="Times Up";
public delegate void ChangedEventHandler(object sender, EventArgs e);
public event ChangedEventHandler TimerDeleted;
private int _objectID;

    public int ObjectId {
	      get { return _objectID; }
	  }

    public TimerObj(){
		    Tick += new EventHandler(TimerEventProcessor);
				idCount++;
        _objectID = idCount;
				Console.WriteLine( "id: " + _objectID );
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
          pop.buttonExtend.Click += new EventHandler(HandleExtend);
	        pop.Show();
    }

    void HandleDelete(object sender, EventArgs e) {
    		Console.WriteLine( "Delete clicked");
        // todo need to send out which object is deleted, I think
    		OnTimerDeleted(EventArgs.Empty); // shoot out a signal telling that we are deleted
    		pop.Close();
    }

    void HandleExtend(object sender, EventArgs e) {
		    Console.WriteLine( "Extend clicked");
        // todo need to restart the timer with new time
		    pop.Close();
    }
}
} // namespace TimerNS
