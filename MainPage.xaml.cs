using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Sdeshazer_EX4._6 {
    public sealed partial class MainPage : Page {
//      =============
//      Declarations:
//      =============
        private int totalpieces = 0;
        private int employees = 0;
        private double totalpay = 0;

        public MainPage() {
            this.InitializeComponent();
 
        }//MainPage
        
        private void calc_Button_Click(object sender, RoutedEventArgs e) {
            
            try {
                if (string.IsNullOrWhiteSpace(name_TextBox.Text) ||
                    string.IsNullOrWhiteSpace(pieces_TextBox.Text)){

                    DisplayMsg("Error", "Please fill in all required feilds", "OK");
                }//if

                else{

                    int pieces = 0;
                    pieces = int.Parse(pieces_TextBox.Text);
                    double pay = calculate(pieces);

                   

                    employees = employees + 1;

                    totalpieces = totalpieces + pieces;
                    totalpay += pay;
                    summary_Button.IsEnabled = true;

                    msg_TextBlock.Text = " Calculation completed!" + "\n" + "Please click [Summary] from the navigation above." ;
                }//else
            }//try
            catch (FormatException fex) {

                DisplayMsg("Error", "Please enter in the proper fields", "OK");
                clear_Button_Click(sender, e);
                summary_Button.IsEnabled = false;
            }//catch
            catch (Exception ex) {

                DisplayMsg("Error", "Please attempt again", "OK");
                clear_Button_Click(sender, e);
                summary_Button.IsEnabled = false;

            } //End try block
        }//calc_button

        private double calculate(int pieces){

           double pay = 0;
            if (pieces <= 199){
                return pay = (pieces * 0.5);
            }
            if ((pieces >= 200) && (pieces <= 399)){
                return pay = (pieces * 0.55);
            }
            if (pieces > 400 && pieces < 599){
               return pay = pieces * 0.6;
            }         
            else 
                   return pay = pieces * 0.65;

        }//calculate

        private void summary_Button_Click(object sender, RoutedEventArgs e) {

            clearAll_Button.IsEnabled = true;
           
            msg_TextBlock.Text = "Daily Summary" + "\n" + "Name: " + name_TextBox.Text.ToString()
                               + "\n" + "Number of Employees: " + employees.ToString()
                               + "\n" + "Number of Pieces: " + totalpieces.ToString()
                               + "\r\n\t\tTotal for Day: " + totalpay.ToString("C")
                               + "\n" + "Average Pay Per Person :" + (totalpay / employees).ToString("C");

        }//Summary_Button

        private void clear_Button_Click(object sender, RoutedEventArgs e){

        
            name_TextBox.Text = "";
            pieces_TextBox.Text = "";
         

            calc_Button.IsEnabled = false;
            clear_Button.IsEnabled = false;

        }//Clear_Button

        private void clearAll_Button_Click(object sender, RoutedEventArgs e) {

           
            msg_TextBlock.Text = "";
            name_TextBox.Text = "";
            pieces_TextBox.Text = "";
           

            totalpieces = 0;
                totalpay = 0;
                employees = 0;
                summary_Button.IsEnabled = false;
                clear_Button.IsEnabled = false;
                clearAll_Button.IsEnabled = false;

          
        }//clearAll

        private void any_TextBox_TextChanged(object sender, TextChangedEventArgs e){

            if (System.Text.RegularExpressions.Regex.IsMatch(name_TextBox.Text, "[0-9.-=+|*&%$#@!~;:><]")){
                name_TextBox.Text = name_TextBox.Text.Remove(name_TextBox.Text.Length - 1);
            }//if

            if (System.Text.RegularExpressions.Regex.IsMatch(pieces_TextBox.Text, "[^0-9]")){
                pieces_TextBox.Text = pieces_TextBox.Text.Remove(pieces_TextBox.Text.Length - 1);
            }//if


            calc_Button.IsEnabled = true;
            clear_Button.IsEnabled = true;

        }//any TextChanged
        private void exit_Button_Click(object sender, RoutedEventArgs e){

            Application.Current.Exit();

        }//exit_Button_Click

        private async void DisplayMsg(String title, String ss, String buttn){

            ContentDialog displayMsg = new ContentDialog{
                Title = title,
                Content = ss,
                CloseButtonText = buttn
            };//displayMsg

            await displayMsg.ShowAsync();
        }//DisplayMsg

    }//class MainPage
}//Namespace