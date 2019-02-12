using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dierenpark
{
    public partial class Form1 : Form
    {
        private Subscription _newSubscription1,
            _newSubscription2,
            _newSubscription3,
            _newSubscription4,
            _newSubscription5,
            _newSubscription6,
            _newSubscription7;

        private List<Subscription> _subscriptions;
        private readonly List<int> _agesList = new List<int>();
        private double _priceTotal;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            _subscriptions = new List<Subscription>();

            _newSubscription1 = new Subscription("Echtpaar", 61);
            _newSubscription2 = new Subscription("Gezin met 1 kind", 71);
            _newSubscription3 = new Subscription("Gezin met 2 kinderen", 82);
            _newSubscription4 = new Subscription("Persoonlijk", 30);
            _newSubscription5 = new Subscription("Elk kind extra", 11);
            _newSubscription6 = new Subscription("Echtpaar 65+", 65);
            _newSubscription7 = new Subscription("Persoonlijk 65+", 26);

            _subscriptions.Add(_newSubscription1);
            _subscriptions.Add(_newSubscription2);
            _subscriptions.Add(_newSubscription3);
            _subscriptions.Add(_newSubscription4);
            _subscriptions.Add(_newSubscription5);
            _subscriptions.Add(_newSubscription6);
            _subscriptions.Add(_newSubscription7);

            // Fills labels
            int counterSubscriptions = 0;
            foreach (Label labelSubscription in panelSubscriptions.Controls)
            {
                //if (control.GetType() == typeof(Label))
                labelSubscription.Text = _subscriptions[counterSubscriptions].Name;
                counterSubscriptions++;
            }

            // Fills labels
            int counterPrices = 0;
            foreach (Label labelPrice in panelPrices.Controls)
            {
                labelPrice.Text = _subscriptions[counterPrices].Price.ToString();
                counterPrices++;
            }

            // Fills numericupdowns
            foreach (NumericUpDown control in panelYear.Controls)
            {
                control.Maximum = DateTime.Today.Year;
                control.Minimum = DateTime.Today.Year - 100;
                control.Value = DateTime.Today.Year;
            }

            foreach (NumericUpDown control in panelMonth.Controls)
            {
                control.Maximum = DateTime.Today.Month;
                control.Value = DateTime.Today.Month;
            }

            foreach (NumericUpDown control in panelDay.Controls)
            {
                control.Maximum = DateTime.Today.Day;
                control.Value = DateTime.Today.Day;
            }

            // foreach loop iterates ascending label1, label2, etc. On form labels must be put down
            // in descending order label7, label6. Because foreach loop selects most recent label first.

            labelPriceTotal.Text = $@"€ {Math.Round(_priceTotal, 2):0.00},-";
            labelTicketsTotal.Text = (numericUpDownAmount1.Value + numericUpDownAmount2.Value + numericUpDownAmount3.Value + numericUpDownAmount4.Value + numericUpDownAmount5.Value + numericUpDownAmount6.Value + numericUpDownAmount7.Value).ToString();
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            if (CheckDays())
            {
                int searchHitsAdult;
                if (numericUpDownAmount1.Value > 0)
                {
                    searchHitsAdult = (int)numericUpDownAmount1.Value * 2;

                    IEnumerable<int> ageSelectionAdult =
                        from intergers in _agesList
                        where intergers > 12
                        select intergers;

                    // Checks if adult
                    if (ageSelectionAdult.Count() == searchHitsAdult && ageSelectionAdult.Count() != 0)
                    {
                        _priceTotal += _newSubscription1.Price * (double)numericUpDownAmount1.Value;
                    }
                }

                int searchHitsKid;
                if (numericUpDownAmount2.Value > 0)
                {
                    searchHitsAdult = (int)numericUpDownAmount2.Value * 2;
                    searchHitsKid = (int)numericUpDownAmount2.Value;

                    IEnumerable<int> ageSelectionAdult =
                        from intergers in _agesList
                        where intergers > 12
                        select intergers;

                    IEnumerable<int> ageSelectionKid =
                        from intergers in _agesList
                        where intergers < 12
                        select intergers;

                    // Checks if adult or kid
                    if (ageSelectionAdult.Count() <= searchHitsAdult && ageSelectionAdult.Count() != 0 && ageSelectionKid.Count() == searchHitsKid && ageSelectionKid.Count() != 0)
                    {
                        _priceTotal += _newSubscription2.Price * (double)numericUpDownAmount2.Value;
                    }
                }

                if (numericUpDownAmount3.Value > 0)
                {
                    searchHitsAdult = (int)numericUpDownAmount3.Value * 2;
                    searchHitsKid = (int)numericUpDownAmount3.Value * 2;

                    IEnumerable<int> ageSelectionAdult =
                        from intergers in _agesList
                        where intergers > 12
                        select intergers;

                    IEnumerable<int> ageSelectionKid =
                        from intergers in _agesList
                        where intergers < 12
                        select intergers;

                    // Checks if adult or kid
                    if (ageSelectionAdult.Count() <= searchHitsAdult && ageSelectionAdult.Count() != 0 && ageSelectionKid.Count() == searchHitsKid && ageSelectionKid.Count() != 0)
                    {
                        _priceTotal += _newSubscription3.Price * (double)numericUpDownAmount3.Value;
                    }
                }

                if (numericUpDownAmount4.Value > 0)
                {
                    searchHitsAdult = (int)numericUpDownAmount4.Value;

                    IEnumerable<int> ageSelectionAdult =
                        from intergers in _agesList
                        where intergers > 12
                        select intergers;

                    // Checks if adult
                    if (ageSelectionAdult.Count() == searchHitsAdult && ageSelectionAdult.Count() != 0)
                    {
                        _priceTotal += _newSubscription4.Price * (double)numericUpDownAmount4.Value;
                    }
                }

                if (numericUpDownAmount5.Value > 0)
                {
                    searchHitsKid = (int)numericUpDownAmount5.Value;

                    IEnumerable<int> ageSelectionKid =
                        from intergers in _agesList
                        where intergers < 12
                        select intergers;

                    // Checks if kid
                    if (ageSelectionKid.Count() == searchHitsKid && ageSelectionKid.Count() != 0)
                    {
                        _priceTotal += _newSubscription5.Price * (double)numericUpDownAmount5.Value;
                    }
                }

                if (numericUpDownAmount6.Value > 0)
                {
                    searchHitsAdult = (int)numericUpDownAmount6.Value * 2;

                    IEnumerable<int> ageSelectionAdult =
                        from intergers in _agesList
                        where intergers >= 65
                        select intergers;

                    // Checks if adult
                    if (ageSelectionAdult.Count() == searchHitsAdult && ageSelectionAdult.Count() != 0)
                    {
                        _priceTotal += _newSubscription6.Price * (double)numericUpDownAmount6.Value;
                    }
                }

                if (numericUpDownAmount7.Value > 0)
                {
                    searchHitsAdult = (int)numericUpDownAmount7.Value;

                    IEnumerable<int> ageSelectionAdult =
                        from intergers in _agesList
                        where intergers >= 65
                        select intergers;

                    // Checks if adult
                    if (ageSelectionAdult.Count() == searchHitsAdult && ageSelectionAdult.Count() != 0)
                    {
                        _priceTotal += _newSubscription7.Price * (double)numericUpDownAmount7.Value;
                    }
                }

                labelPriceTotal.Text = $@"Totaal: € {Math.Round(_priceTotal, 2):0.00},-";
                labelTicketsTotal.Text = (numericUpDownAmount1.Value + numericUpDownAmount2.Value + numericUpDownAmount3.Value + numericUpDownAmount4.Value + numericUpDownAmount5.Value + numericUpDownAmount6.Value + numericUpDownAmount7.Value).ToString();
            }
            else
            {
                MessageBox.Show($@"The selected day value is incorrect");
            }
        }

        private bool CheckDays()
        {
            // Checks day input
            if (checkBox1.Checked)
            {
                int checkDay = DateTime.DaysInMonth((int)numericUpDownYear1.Value, (int)numericUpDownMonth1.Value);
                if ((int)numericUpDownDay1.Value <= checkDay)
                {
                    DateTime dateOfBirth1 = new DateTime((int)numericUpDownYear1.Value, (int)numericUpDownMonth1.Value, (int)numericUpDownDay1.Value);
                    int age1 = CalculateAge(dateOfBirth1);
                    _agesList.Add(age1);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (checkBox2.Checked)
            {
                int checkDay = DateTime.DaysInMonth((int)numericUpDownYear2.Value, (int)numericUpDownMonth2.Value);
                if ((int)numericUpDownDay2.Value <= checkDay)
                {
                    DateTime dateOfBirth2 = new DateTime((int)numericUpDownYear2.Value, (int)numericUpDownMonth2.Value, (int)numericUpDownDay2.Value);
                    int age2 = CalculateAge(dateOfBirth2);
                    _agesList.Add(age2);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (checkBox3.Checked)
            {
                int checkDay = DateTime.DaysInMonth((int)numericUpDownYear3.Value, (int)numericUpDownMonth3.Value);
                if ((int)numericUpDownDay3.Value <= checkDay)
                {
                    DateTime dateOfBirth3 = new DateTime((int)numericUpDownYear3.Value, (int)numericUpDownMonth3.Value, (int)numericUpDownDay3.Value);
                    int age3 = CalculateAge(dateOfBirth3);
                    _agesList.Add(age3);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (checkBox4.Checked)
            {
                int checkDay = DateTime.DaysInMonth((int)numericUpDownYear4.Value, (int)numericUpDownMonth4.Value);
                if ((int)numericUpDownDay4.Value <= checkDay)
                {
                    DateTime dateOfBirth4 = new DateTime((int)numericUpDownYear4.Value, (int)numericUpDownMonth4.Value, (int)numericUpDownDay4.Value);
                    int age4 = CalculateAge(dateOfBirth4);
                    _agesList.Add(age4);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (checkBox5.Checked)
            {
                int checkDay = DateTime.DaysInMonth((int)numericUpDownYear5.Value, (int)numericUpDownMonth5.Value);
                if ((int)numericUpDownDay5.Value <= checkDay)
                {
                    DateTime dateOfBirth5 = new DateTime((int)numericUpDownYear5.Value, (int)numericUpDownMonth5.Value, (int)numericUpDownDay5.Value);
                    int age5 = CalculateAge(dateOfBirth5);
                    _agesList.Add(age5);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (checkBox6.Checked)
            {
                int checkDay = DateTime.DaysInMonth((int)numericUpDownYear6.Value, (int)numericUpDownMonth6.Value);
                if ((int)numericUpDownDay6.Value <= checkDay)
                {
                    DateTime dateOfBirth6 = new DateTime((int)numericUpDownYear6.Value, (int)numericUpDownMonth6.Value, (int)numericUpDownDay6.Value);
                    int age6 = CalculateAge(dateOfBirth6);
                    _agesList.Add(age6);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (checkBox7.Checked)
            {
                int checkDay = DateTime.DaysInMonth((int)numericUpDownYear7.Value, (int)numericUpDownMonth7.Value);
                if ((int)numericUpDownDay7.Value <= checkDay)
                {
                    DateTime dateOfBirth7 = new DateTime((int)numericUpDownYear7.Value, (int)numericUpDownMonth7.Value, (int)numericUpDownDay7.Value);
                    int age7 = CalculateAge(dateOfBirth7);
                    _agesList.Add(age7);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

    }
}