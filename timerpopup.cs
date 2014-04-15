using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace TimerNS{
public class TimerPopup : Form {
    public Button buttonDelete; 
    public Button buttonExtend; 
	private Label label;
    private DateTimePicker dtp = new DateTimePicker();

    public TimerPopup(String str){
        this.CenterToScreen();

        Text = str;

		label = new Label();
        label.ForeColor = System.Drawing.Color.White;
	    label.Text=str;
        label.Location = new Point(30, 40);
	    label.Parent=this;

		buttonDelete = new Button();
	    buttonDelete.BackColor = System.Drawing.Color.Gray;
	    buttonDelete.Text = "Delete";
	    buttonDelete.Location = new Point(30, 150);
	    buttonDelete.Parent = this;

	    dtp.Location = new Point(30, 90);
        dtp.Parent = this;

	    buttonExtend = new Button();
	    buttonExtend.BackColor = System.Drawing.Color.Gray;
	    buttonExtend.Text = "Extend Timer";
	    buttonExtend.Location = new Point(120, 150);
	    buttonExtend.Parent = this;
    } // end public TimerPopup
} // public class TimerPopup : Popup {
} // namespace TimerNS