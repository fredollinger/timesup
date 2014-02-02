using System;
using System.Drawing;
using System.Windows.Forms;

public class HelloWorld : Form
{
    static public void Main ()
    {
        Application.Run (new HelloWorld ());
    }

    public HelloWorld ()
    {
        Text = "Times Up! Timer Application";

        Button button = new Button();
        button.Text = "Button";
        button.Location = new Point(30, 70);
				button.Click += new EventHandler(OnClick);
        button.Parent = this;

        CenterToScreen();
    }

    void OnClick(object sender, EventArgs e) {
        Console.Write("Clicked");
    }
}
