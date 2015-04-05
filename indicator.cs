// Special thanks to Arvydas:
//
// http://www.arvydas.co.uk/2012/08/notification-icon-in-ubuntu-with-unity-and-mono-c-sharp-example/

using AppIndicator;
using System;
using Gtk;
using Gdk;

namespace TimerNS{
public partial class TimesIndicator {
private String _ExecutableFolder = "";
private String ExecutableFolder {
    get {
        if (_ExecutableFolder == "")
            _ExecutableFolder = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        return _ExecutableFolder;
    }

} // END ExecutableFolder 

public void BuildMenu() {
    ApplicationIndicator indicator = new ApplicationIndicator (
        "sample-application", 		//id of the the indicator icon
	"app-icon",			        //file name of the icon (will look for app-icon.png) 
	Category.ApplicationStatus, 
	ExecutableFolder            //the folder where to look for app-icon.png
    );	// END ApplicationIndicator
	
        //Build Popup Menu for ApplicationIndicator
        Menu popupMenu = new Menu ();
    
        //Show menu item
        ImageMenuItem menuItemShow = new ImageMenuItem ("Show");
        menuItemShow.Image = new Gtk.Image(Stock.Info, IconSize.Menu);
//        menuItemShow.Activated += (sender, e) => this.Visible = !this.Visible;
        popupMenu.Append(menuItemShow);
    
        popupMenu.Append(new SeparatorMenuItem());
    
/*
        //Quit menu item
        ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
        menuItemQuit.Image = new Gtk.Image (Stock.Quit, IconSize.Menu);
        menuItemQuit.Activated += (sender, e) => Application.Quit ();
        popupMenu.Append (menuItemQuit);
*/
    	
        popupMenu.ShowAll();
        //Assign menu and make indicator active
//        indicator.Menu = popupMenu;
//        indicator.Status = AppIndicator.Status.Active;	

    } // BuildMenu()

} // END TimesIndicator

} // END namespace TimerNS
