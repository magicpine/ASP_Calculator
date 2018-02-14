using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie theme = Request.Cookies.Get("cbTheme");

            if (theme != null)
            {
                string themeName = theme.Value;
                if (themeName.Length > 0)
                {
                    Page.Theme = themeName;
                    DropDownList2.Text = themeName;
                }
            }
            else
            {
                Page.Theme = "Metal";
            }
        }

        /// <summary>
        /// Handles the Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Default Values
                clearBtn_Click(null, null);
                //Add the Panel Colours
                DropDownList1.Items.Add("Red");
                DropDownList1.Items.Add("Lime");
                DropDownList1.Items.Add("Blue");
                DropDownList1.Items.Add("White");
                HttpCookie panelColour = Request.Cookies.Get("colour");
                if (panelColour != null)
                {
                    if (DropDownList1.Items.FindByValue(panelColour.Value) != null)
                    {
                        DropDownList1.Items.FindByValue(panelColour.Value).Selected = true;
                        DropDownList1_SelectedIndexChanged(null, null);
                    }
                }
                else
                    DropDownList1.SelectedIndex = 3;

            }
        }

        /// <summary>
        /// Handles All the Button Click Events.  Excluding the =, clear and back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Equation_Click(object sender, EventArgs e)
        {
            //If the Button is a number then set it to true right away
            CheckForSettingFlagToTrue(((Button)sender).Text);
            if (Convert.ToBoolean(Session["flagBreak"]))
            {
                //Add it into the Equation
                if ((string)Session["Equation"] == "0")
                {
                    //Allows the only the decimal point to be clicked if theres a zero in it
                    if (((Button)sender).Text != "-" && ((Button)sender).Text != "+" && ((Button)sender).Text != "*" && ((Button)sender).Text != "/")
                        Session["Equation"] = ((Button)sender).Text;
                }
                else
                    Session["Equation"] += ((Button)sender).Text;
                calculatorEquationTxt.Text = Convert.ToString(Session["Equation"]);
                //If the flag was already set to true and the button clicked was a operation then set the flag to false
                if ((string)Session["Equation"] != "0")
                    CheckForSettingFlagToFalse(((Button)sender).Text);
            }
        }

        /// <summary>
        /// Sets the flag to True if the equation text last part is a number
        /// </summary>
        /// <param name="sender"></param>
        private void CheckForSettingFlagToTrue(string sender = "")
        {
            string tmp = Convert.ToString(Session["Equation"]) + sender;
            if (tmp.Length > 1)
            {
                switch (tmp.Substring(tmp.Length - 1))
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "0":
                        Session["flagBreak"] = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the flag to false if the equation text last part is a operation or nothing
        /// </summary>
        /// <param name="sender"></param>
        private void CheckForSettingFlagToFalse(string sender = "")
        {
            string tmp = Convert.ToString(Session["Equation"]) + sender;
            if (tmp.Length == 0)
                Session["flagBreak"] = false;
            else
            {
                switch (tmp.Substring(tmp.Length - 1))
                {
                    case "+":
                    case ".":
                    case "/":
                    case "*":
                    case "-":
                    case "":
                        Session["flagBreak"] = false;
                        break;
                }
            }
        }

        /// <summary>
        /// handles the back button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void backBtn_Click(object sender, EventArgs e)
        {
            string tmp = Convert.ToString(Session["Equation"]);
            if (tmp.Length > 0)
            {
                Session["Equation"] = tmp.Substring(0, tmp.Length - 1);
                calculatorEquationTxt.Text = Convert.ToString(Session["Equation"]);
                CheckForSettingFlagToFalse();
                CheckForSettingFlagToTrue();
            }
            else
                Session["flagBreak"] = false;
        }

        /// <summary>
        /// Handles the Clear Button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clearBtn_Click(object sender, EventArgs e)
        {
            //Default Values
            Session["Equation"] = "0";
            Session["Answer"] = "0";
            calculatorEquationTxt.Text = Convert.ToString(Session["Equation"]);
            answerTxt.Text = Convert.ToString(Session["Answer"]);
            Session["flagBreak"] = true;
        }

        /// <summary>
        /// Handles the equals button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void equalsBtn_Click(object sender, EventArgs e)
        {
            if ((Convert.ToBoolean(Session["flagBreak"])))
            {
                string tmp = Convert.ToString(Session["Equation"]);
                //This does the calculation
                DataTable dt = new DataTable();
                var v = dt.Compute(tmp, "");
                //Put it into the variable and textbox
                Session["Answer"] = v;
                answerTxt.Text = Convert.ToString(Session["Answer"]);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update the Cookie to store the Colour they selected
            HttpCookie mc = new HttpCookie("colour");
            mc.Expires = DateTime.Now.AddHours(10);
            mc.Value = DropDownList1.SelectedValue;
            Response.Cookies.Add(mc);
            Panel1.BackColor = System.Drawing.Color.FromName(DropDownList1.SelectedValue);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update the Cookie to see what Theme is selected
            HttpCookie mc = new HttpCookie("cbTheme");
            mc.Expires = DateTime.Now.AddHours(10);
            mc.Value = DropDownList2.SelectedItem.Value;
            Response.Cookies.Add(mc);
            Response.Redirect(Request.RawUrl);
        }
    }
}