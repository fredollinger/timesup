using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TimerNS;

public class Poptest : Form{
	  static TimerObj myTimer = new TimerObj();

    public Poptest (){
        String text = "Frederick";
				this.Hide();
				myTimer.setText(text);
				myTimer.showtimesup();
				myTimer.TimerDeleted += new TimerObj.ChangedEventHandler(OnTimerDeleted);
    }

   void OnTimerDeleted(object sender, EventArgs e) {
            Console.WriteLine("timer deleted");
   }

    static public void Main ()
    {
        Application.Run (new Poptest ());
    }
} // END public class TimesUp : Form
// Sun Mar  9 10:29:04 PDT 2014
