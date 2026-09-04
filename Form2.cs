using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitCal;
            exitCal = MessageBox.Show("Are you want to exit?", "Calculator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exitCal == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide(); 
        }
        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide(); 
        }
        private void unitConvertorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide(); 
        }
        

//**********************************************//unit convertor//***************************************************** 

//combobox binding


        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] Units = new String[] { "Area", "Length", "Temperature", "Time", "Volume", "Weight" };
            //cmbUnit.DataSource = Units;
            //cmbUnit.SelectedIndex = 0;

            if (cmbUnit.SelectedIndex == 0)
            {
                String[] area = new String[] { "Acres", "Hectares", "Square centimeter", "Square feet", "Square inch", "Square kilometer", "Square meters", "Square mile", "Square millimeter", "Square yard" };
                cmbFrom.Items.Clear();
                cmbTo.Items.Clear();
                cmbFrom.Items.AddRange(area);
                cmbTo.Items.AddRange(area);
            }
            if (cmbUnit.SelectedIndex == 1)
            {
                String[] Length = new String[] { "Centimeters", "Feet", "Inch", "Kilometers", "Meter", "Microns", "Mile", "Millimeters", "Nanometer", "Nautical Miles", "Yard" };
                cmbFrom.Items.Clear();
                cmbTo.Items.Clear();
                cmbFrom.Items.AddRange(Length);
                cmbTo.Items.AddRange(Length);
            }
            if (cmbUnit.SelectedIndex == 2)
            {
                String[] temperature = new String[] { "Celsius", "Fahrenheit", "Kelvin" };
                cmbFrom.Items.Clear();
                cmbTo.Items.Clear();
                cmbFrom.Items.AddRange(temperature);
                cmbTo.Items.AddRange(temperature);
            }
            if (cmbUnit.SelectedIndex == 3)
            {
                String[] time = new String[] { "Day", "Hour", "Microsecond", "Millisecond", "Minute", "Second"};
                cmbFrom.Items.Clear();
                cmbTo.Items.Clear();
                cmbFrom.Items.AddRange(time);
                cmbTo.Items.AddRange(time);
            }
            if (cmbUnit.SelectedIndex == 4)
            {
                String[] volume = new String[] { "Cubic centimeter", "Cubic feet", "Cubic inch", "Cubic meter", "Cubic yard" };
                cmbFrom.Items.Clear();
                cmbTo.Items.Clear();
                cmbFrom.Items.AddRange(volume);
                cmbTo.Items.AddRange(volume);
            }
            if (cmbUnit.SelectedIndex == 5)
            {
                String[] Weight = new String[] { "Carat", "Centigram", "Gram", "Kilogram", "Milligrame", "Ounce", "Pound", "Tonne" };
                cmbFrom.Items.Clear();
                cmbTo.Items.Clear();
                cmbFrom.Items.AddRange(Weight);
                cmbTo.Items.AddRange(Weight);
            }
            //this lines use for hold in 0 index of cmbFrom and cmbTo when choose a type of cmbUnit 
            cmbFrom.SelectedIndex = 0;
            cmbTo.SelectedIndex = 0;

        }

// adding placeholder to txtFrom textbox 
        private void placeholdertxt(object sender, EventArgs e)
        {
            if (txtFrom.Text == "Enter Value")
            {
                txtFrom.Text = "";

            }

        }

        private void placeholder(object sender, EventArgs e)
        {

        }

//strings and char (letters or characters) can not be used in txtFrom textbox 

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            char let = e.KeyChar;
            if ((let == 46 && txtFrom.Text.IndexOf(".") != -1) ||
                (let == 45 && txtFrom.Text.IndexOf("-") != -1) ||
                (let == 45 && txtFrom.Text.IndexOf(".") != -1) ||
                (!Char.IsDigit(let) && let != 8 && let != 46 && let != 45))
            {
                e.Handled = true;
                return;
            }
        }

//**************temperature converter***************

        private double Fahrenheit, Celsius, Kelvin;

        private double FahrenheitToCelsius
        {
            get { return (Fahrenheit - 32) * 5 / 9; }
            set { Fahrenheit = value; }
        }
        private double FahrenheitToKelvin
        {
            get { return (Fahrenheit - 32) * 5 / 9 + 273.15; }
            set { Fahrenheit = value; }
        }
        private double CelsiusToKelvin
        {
            get { return Celsius + 273.15; }
            set { Celsius = value; }
        }
        private double CelsiusToFahrenheit
        {
            get { return (Celsius * 9 / 5) + 32; }
            set { Celsius = value; }
        }
        private double KelvinToFahrenheit
        {
            get { return (Kelvin - 273.15) * 9 / 5 + 32; }
            set { Kelvin = value; }
        }
        private double KelvinToCelsius
        {
            get { return Kelvin - 273.15; }
            set { Kelvin = value; }
        }

        private void TempConverter()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Fahrenheit" && cmbTo.Text == "Celsius")
            {
                FahrenheitToCelsius = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = FahrenheitToCelsius.ToString();
            }
            else if (cmbFrom.Text == "Fahrenheit" && cmbTo.Text == "Kelvin")
            {
                FahrenheitToKelvin = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = FahrenheitToKelvin.ToString();
            }
            else if (cmbFrom.Text == "Celsius" && cmbTo.Text == "Fahrenheit")
            {
                CelsiusToFahrenheit = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CelsiusToFahrenheit.ToString();
            }
            else if (cmbFrom.Text == "Celsius" && cmbTo.Text == "Kelvin")
            {
                CelsiusToKelvin = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CelsiusToKelvin.ToString();
            }
            else if (cmbFrom.Text == "Kelvin" && cmbTo.Text == "Celsius")
            {
                KelvinToCelsius = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KelvinToCelsius.ToString();
            }
            else if (cmbFrom.Text == "Kelvin" && cmbTo.Text == "Fahrenheit")
            {
                KelvinToFahrenheit = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KelvinToFahrenheit.ToString();
            }
            else if (cmbFrom.Text == "Kelvin" && cmbTo.Text == "Kelvin")
            {
                txtFrom.Text = Convert.ToString(txtFrom.Text);
                txtTo.Text = txtFrom.Text.ToString();
            }
            else if (cmbFrom.Text == "Fahrenheit" && cmbTo.Text == "Fahrenheit")
            {
                txtFrom.Text = Convert.ToString(txtFrom.Text);
                txtTo.Text = txtFrom.Text.ToString();
            }
            else if (cmbFrom.Text == "Celsius" && cmbTo.Text == "Celsius")
            {
                txtFrom.Text = Convert.ToString(txtFrom.Text);
                txtTo.Text = txtFrom.Text.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


//Adding function to related comboBox

        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            TempConverter();
            AreaConvertor();
            LengthCentimeter(); LengthFeet(); LengthInch(); LengthKilometers(); LengthInch(); LengthMeter(); LengthMicrons(); LengthMile(); LengthMillimeters(); LengthNanometer(); LengthNauticalMiles(); LengthYard();
            TimeDay(); TimeHour(); TimeMinute(); TimeSecond(); TimeMillisecond(); TimeMicrosecond();
            VolumeCubicCentimeter(); VolumeCubicMeter(); VolumeCubicFeet(); VolumeCubicYard(); VolumeCubicInch();
            WeightCarat(); WeightCentigram(); WeightGram(); WeightKilogram(); WeightMilligrame(); WeightOunce(); WeightPound(); WeightTonne(); 
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TempConverter();
            AreaConvertor();
            LengthCentimeter(); LengthFeet(); LengthInch(); LengthKilometers(); LengthInch(); LengthMeter(); LengthMicrons(); LengthMile(); LengthMillimeters(); LengthNanometer(); LengthNauticalMiles(); LengthYard();
            TimeDay(); TimeHour(); TimeMinute(); TimeSecond(); TimeMillisecond(); TimeMicrosecond();
            VolumeCubicCentimeter(); VolumeCubicMeter(); VolumeCubicFeet(); VolumeCubicYard(); VolumeCubicInch();
            WeightCarat(); WeightCentigram(); WeightGram(); WeightKilogram(); WeightMilligrame(); WeightOunce(); WeightPound(); WeightTonne();
        }
        
        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            TempConverter();
            AreaConvertor();
            LengthCentimeter(); LengthFeet(); LengthInch(); LengthKilometers(); LengthInch(); LengthMeter(); LengthMicrons(); LengthMile(); LengthMillimeters(); LengthNanometer(); LengthNauticalMiles(); LengthYard();
            TimeDay(); TimeHour(); TimeMinute(); TimeSecond(); TimeMillisecond(); TimeMicrosecond();
            VolumeCubicCentimeter(); VolumeCubicMeter(); VolumeCubicFeet(); VolumeCubicYard(); VolumeCubicInch();
            WeightCarat(); WeightCentigram(); WeightGram(); WeightKilogram(); WeightMilligrame(); WeightOunce(); WeightPound(); WeightTonne();
        }

        private void txtTo_TextChanged(object sender, EventArgs e)
        {
            TempConverter();
            AreaConvertor();
            LengthCentimeter(); LengthFeet(); LengthInch(); LengthKilometers(); LengthInch(); LengthMeter(); LengthMicrons(); LengthMile(); LengthMillimeters(); LengthNanometer(); LengthNauticalMiles(); LengthYard();
            TimeDay(); TimeHour(); TimeMinute(); TimeSecond(); TimeMillisecond(); TimeMicrosecond();
            VolumeCubicCentimeter(); VolumeCubicMeter(); VolumeCubicFeet(); VolumeCubicYard(); VolumeCubicInch();
            WeightCarat(); WeightCentigram(); WeightGram(); WeightKilogram(); WeightMilligrame(); WeightOunce(); WeightPound(); WeightTonne();
        }

// clear button is used to clear data of txtFrom and txtTo textboxes
        private void btnUnitClear_Click(object sender, EventArgs e)
        {
            txtFrom.Text = "";
            txtTo.Text = "";
        }

//********************************Area Convertor******************************

        private double Acres, Hectares, Square_centimeter, Square_feet, Square_inch, Square_kilometer, Square_meters, Square_mile ,Square_millimeter, Square_yard;

//converting to Acres to other

        private double AcresToHectares
        {
            get { return Acres * 0.40468564224; }
            set { Acres = value; }
        }

        private double AcresToSquare_centi
        {
            get { return Acres * 40468564.224; }
            set { Acres = value; }
        }

        private double AcresToSquare_feet
        {
            get { return Acres * 43560; }
            set { Acres = value; }
        }
        private double AcresToSquare_inch
        {
            get { return Acres * 6272640; }
            set { Acres = value; }
        }
        private double AcresToSquare_meter
        {
            get { return Acres * 4046.8564224; }
            set { Acres = value; }
        }
        private double AcresToSquare_kilometer
        {
            get { return Acres * 0.0040468564224; }
            set { Acres = value; }
        }
        private double AcresToSquare_mile
        {
            get { return Acres * 0.0015625; }
            set { Acres = value; }
        }
        private double AcresToSquare_milli
        {
            get { return Acres * 4046856422.4; }
            set { Acres = value; }
        }
        private double AcresToSquare_yard
        {
            get { return Acres * 4840; }
            set { Acres = value; }
        }

//converting to Hectares to other  

        private double HectaresToAcres
        {
            get { return Hectares * 2.471053814671653; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_centi
        {
            get { return Hectares * 100000000; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_feet
        {
            get { return Hectares * 107639.1041670972; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_inch
        {
            get { return Hectares * 15500031.000062; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_meter
        {
            get { return Hectares * 10000; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_kilometer
        {
            get { return Hectares * 0.01; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_mile
        {
            get { return Hectares * 0.0038610215854245; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_milli
        {
            get { return Hectares * 10000000000; }
            set { Hectares = value; }
        }
        private double HectaresToSquare_yard
        {
            get { return Hectares * 11959.9004630108; }
            set { Hectares = value; }
        }

//converting Square_feet to other

        private double Square_feetToAcres
        {
            get { return Square_feet * 2.295684113865932e-5; }
            set { Square_feet = value; }
        }

        private double Square_feetToHectares
        {
            get { return Square_feet * 0.000009290304; }
            set { Square_feet = value; }
        }

        private double Square_feetToSquare_feet
        {
            get { return Square_feet * 929.0304; }
            set { Square_feet = value; }
        }
        private double Square_feetToSquare_inch
        {
            get { return Square_feet * 144; }
            set { Square_feet = value; }
        }
        private double Square_feetToSquare_meter
        {
            get { return Square_feet * 0.09290304; }
            set { Square_feet = value; }
        }
        private double Square_feetToSquare_kilometer
        {
            get { return Square_feet * 0.00000009290304; }
            set { Square_feet = value; }
        }
        private double Square_feetToSquare_mile
        {
            get { return Square_feet * 3.587006427915519e-8; }
            set { Square_feet = value; }
        }
        private double Square_feetToSquare_milli
        {
            get { return Square_feet * 92903.04; }
            set { Square_feet = value; }
        }
        private double Square_feetToSquare_yard
        {
            get { return Square_feet * 0.1111111111111111; }
            set { Square_feet = value; }
        }

        //converting Square_centimeter to other

        private double Square_centimeterToAcres
        {
            get { return Square_centimeter * 2.471053814671653e-8; }
            set { Square_centimeter = value; }
        }

        private double Square_centimeterToHectares
        {
            get { return Square_centimeter * 0.00000001; }
            set { Square_centimeter = value; }
        }

        private double Square_centimeterToSquare_feet
        {
            get { return Square_centimeter * 0.001076391041671; }
            set { Square_centimeter = value; }
        }
        private double Square_centimeterToSquare_inch
        {
            get { return Square_centimeter * 0.15500031000062; }
            set { Square_centimeter = value; }
        }
        private double Square_centimeterToSquare_meter
        {
            get { return Square_centimeter * 0.0001; }
            set { Square_centimeter = value; }
        }
        private double Square_centimeterToSquare_kilometer
        {
            get { return Square_centimeter * 0.0000000001; }
            set { Square_centimeter = value; }
        }
        private double Square_centimeterToSquare_mile
        {
            get { return Square_centimeter * 3.861021585424458e-11; }
            set { Square_centimeter = value; }
        }
        private double Square_centimeterToSquare_milli
        {
            get { return Square_centimeter * 100; }
            set { Square_centimeter = value; }
        }
        private double Square_centimeterToSquare_yard
        {
            get { return Square_centimeter * 1.19599004630108e-4; }
            set { Square_centimeter = value; }
        }

 //converting Square_inch to other

        private double Square_inchToAcres
        {
            get { return Square_inch * 1.594225079073564e-7; }
            set { Square_inch = value; }
        }

        private double Square_inchToHectares
        {
            get { return Square_inch * 0.000000064516; }
            set { Square_inch = value; }
        }

        private double Square_inchToSquare_feet
        {
            get { return Square_inch * 0.0069444444444444; }
            set { Square_inch = value; }
        }
        private double Square_inchToSquare_centimeter
        {
            get { return Square_inch * 6.4516; }
            set { Square_inch = value; }
        }
        
        private double Square_inchToSquare_inch
        {
            get { return Square_inch * 1; }
            set { Square_inch = value; }
        }
        private double Square_inchToSquare_meter
        {
            get { return Square_inch * 0.00064516; }
            set { Square_inch = value; }
        }
        private double Square_inchToSquare_kilometer
        {
            get { return Square_inch * 0.00000000064516; }
            set { Square_inch = value; }
        }
        private double Square_inchToSquare_mile
        {
            get { return Square_inch * 2.490976686052444e-10; }
            set { Square_inch = value; }
        }
        private double Square_inchToSquare_milli
        {
            get { return Square_inch * 645.16; }
            set { Square_inch = value; }
        }
        private double Square_inchToSquare_yard
        {
            get { return Square_inch * 7.716049382716049e-4; }
            set { Square_inch = value; }
        }

//converting Square_kilometer to other

        private double Square_kilometerToAcres
        {
            get { return Square_kilometer * 247.1053814671653; }
            set { Square_kilometer = value; }
        }

        private double Square_kilometerToHectares
        {
            get { return Square_kilometer * 100; }
            set { Square_kilometer = value; }
        }

        private double Square_kilometerToSquare_feet
        {
            get { return Square_kilometer * 10763910.41670972; }
            set { Square_kilometer = value; }
        }
        private double Square_kilometerToSquare_centimeter
        {
            get { return Square_kilometer * 10000000000; }
            set { Square_kilometer = value; }
        }

        private double Square_kilometerToSquare_inch
        {
            get { return Square_kilometer * 1550003100.0062; }
            set { Square_kilometer = value; }
        }
        private double Square_kilometerToSquare_meter
        {
            get { return Square_kilometer * 1000000; }
            set { Square_kilometer = value; }
        }
        private double Square_kilometerToSquare_kilometer
        {
            get { return Square_kilometer * 1; }
            set { Square_kilometer = value; }
        }
        private double Square_kilometerToSquare_mile
        {
            get { return Square_kilometer * 0.3861021585424458; }
            set { Square_kilometer = value; }
        }
        private double Square_kilometerToSquare_milli
        {
            get { return Square_kilometer * 1000000000000; }
            set { Square_kilometer = value; }
        }
        private double Square_kilometerToSquare_yard
        {
            get { return Square_kilometer * 1195990.04630108; }
            set { Square_kilometer = value; }
        }

//converting Square_meters to other

        private double Square_metersToAcres
        {
            get { return Square_meters * 2.471053814671653e-4; }
            set { Square_meters = value; }
        }

        private double Square_metersToHectares
        {
            get { return Square_meters * 0.0001; }
            set { Square_meters = value; }
        }

        private double Square_metersToSquare_feet
        {
            get { return Square_meters * 10.76391041670972; }
            set { Square_meters = value; }
        }
        private double Square_metersToSquare_centimeter
        {
            get { return Square_meters * 10000; }
            set { Square_meters = value; }
        }

        private double Square_metersToSquare_inch
        {
            get { return Square_meters * 1550.0031000062; }
            set { Square_meters = value; }
        }
        private double Square_metersToSquare_meter
        {
            get { return Square_meters * 1; }
            set { Square_meters = value; }
        }
        private double Square_metersToSquare_kilometer
        {
            get { return Square_meters * 0.000001; }
            set { Square_meters = value; }
        }
        private double Square_metersToSquare_mile
        {
            get { return Square_meters * 3.861021585424458e-7; }
            set { Square_meters = value; }
        }
        private double Square_metersToSquare_milli
        {
            get { return Square_meters * 1000000; }
            set { Square_meters = value; }
        }
        private double Square_metersToSquare_yard
        {
            get { return Square_meters * 1.19599004630108; }
            set { Square_meters = value; }
        }

 //converting Square_mile to other

        private double Square_mileToAcres
        {
            get { return Square_mile * 640; }
            set { Square_mile = value; }
        }

        private double Square_mileToHectares
        {
            get { return Square_mile * 258.9988110336; }
            set { Square_mile = value; }
        }

        private double Square_mileToSquare_feet
        {
            get { return Square_mile * 27878400; }
            set { Square_mile = value; }
        }
        private double Square_mileToSquare_centimeter
        {
            get { return Square_mile * 25899881103.36; }
            set { Square_mile = value; }
        }

        private double Square_mileToSquare_inch
        {
            get { return Square_mile * 4014489600; }
            set { Square_mile = value; }
        }
        private double Square_mileToSquare_meter
        {
            get { return Square_mile * 2589988.110336; }
            set { Square_mile = value; }
        }
        private double Square_mileToSquare_kilometer
        {
            get { return Square_mile * 2.589988110336; }
            set { Square_mile = value; }
        }
        private double Square_mileToSquare_mile
        {
            get { return Square_mile * 1; }
            set { Square_mile = value; }
        }
        private double Square_mileToSquare_milli
        {
            get { return Square_mile * 2589988110336; }
            set { Square_mile = value; }
        }
        private double Square_mileToSquare_yard
        {
            get { return Square_mile * 3097600; }
            set { Square_mile = value; }
        }

 //converting Square_millimeter to other

        private double Square_millimeterToAcres
        {
            get { return Square_millimeter * 2.471053814671653e-10; }
            set { Square_millimeter = value; }
        }

        private double Square_millimeterToHectares
        {
            get { return Square_millimeter * 0.0000000001; }
            set { Square_millimeter = value; }
        }

        private double Square_millimeterToSquare_feet
        {
            get { return Square_millimeter * 1.076391041670972e-5; }
            set { Square_millimeter = value; }
        }
        private double Square_millimeterToSquare_centimeter
        {
            get { return Square_millimeter * 0.01; }
            set { Square_millimeter = value; }
        }

        private double Square_millimeterToSquare_inch
        {
            get { return Square_millimeter * 0.0015500031000062; }
            set { Square_millimeter = value; }
        }
        private double Square_millimeterToSquare_meter
        {
            get { return Square_millimeter * 0.000001; }
            set { Square_millimeter = value; }
        }
        private double Square_millimeterToSquare_kilometer
        {
            get { return Square_millimeter * 0.000000000001; }
            set { Square_millimeter = value; }
        }
        private double Square_millimeterToSquare_mile
        {
            get { return Square_millimeter * 3.861021585424458e-13; }
            set { Square_millimeter = value; }
        }
        private double Square_millimeterToSquare_milli
        {
            get { return Square_millimeter * 1; }
            set { Square_millimeter = value; }
        }
        private double Square_millimeterToSquare_yard
        {
            get { return Square_millimeter * 1.19599004630108e-6; }
            set { Square_millimeter = value; }
        }

        //converting Square_yard to other

        private double Square_yardToAcres
        {
            get { return Square_yard * 2.066115702479339e-4; }
            set { Square_yard = value; }
        }

        private double Square_yardToHectares
        {
            get { return Square_yard * 0.000083612736; }
            set { Square_yard = value; }
        }

        private double Square_yardToSquare_feet
        {
            get { return Square_yard * 9; }
            set { Square_yard = value; }
        }
        private double Square_yardToSquare_centimeter
        {
            get { return Square_yard * 8361.2736; }
            set { Square_yard = value; }
        }

        private double Square_yardToSquare_inch
        {
            get { return Square_yard * 1296; }
            set { Square_yard = value; }
        }
        private double Square_yardToSquare_meter
        {
            get { return Square_yard * 0.83612736; }
            set { Square_yard = value; }
        }
        private double Square_yardToSquare_kilometer
        {
            get { return Square_yard * 0.00000083612736; }
            set { Square_yard = value; }
        }
        private double Square_yardToSquare_mile
        {
            get { return Square_yard * 3.228305785123967e-7; }
            set { Square_yard = value; }
        }
        private double Square_yardToSquare_milli
        {
            get { return Square_yard * 836127.36; }
            set { Square_yard = value; }
        }
        private double Square_yardToSquare_yard
        {
            get { return Square_yard * 1; }
            set { Square_yard = value; }
        }

 //************************************************************************************

        private void AreaConvertor()
        {
            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Hectares")
            {
                AcresToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToHectares.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square centimeter")
            {
                AcresToSquare_centi = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_centi.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square feet")
            {
                AcresToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square inch")
            {
                AcresToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square kilometer")
            {
                AcresToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square meters")
            {
                AcresToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square mile")
            {
                AcresToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square millimeter")
            {
                AcresToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Square yard")
            {
                AcresToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = AcresToSquare_yard.ToString();
            }
            else if (cmbFrom.Text == "Acres" && cmbTo.Text == "Acres")
            {
                txtFrom.Text = Convert.ToString(txtFrom.Text);
                txtTo.Text = txtFrom.Text.ToString();
            }

 //***********Hectares

            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Acres")
            {
                HectaresToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToAcres.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square centimeter")
            {
                HectaresToSquare_centi = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_centi.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square feet")
            {
                HectaresToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square inch")
            {
                HectaresToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square kilometer")
            {
                HectaresToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square meters")
            {
                HectaresToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square mile")
            {
                HectaresToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square millimeter")
            {
                HectaresToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Square yard")
            {
                HectaresToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HectaresToSquare_yard.ToString();
            }
            else if (cmbFrom.Text == "Hectares" && cmbTo.Text == "Hectares")
            {
                txtFrom.Text = Convert.ToString(txtFrom.Text);
                txtTo.Text = txtFrom.Text.ToString();
            }

 //*****************************Square centimeter

            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Acres")
            {
                Square_centimeterToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Hectares")
            {
                Square_centimeterToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square feet")
            {
                Square_centimeterToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square inch")
            {
                Square_centimeterToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square kilometer")
            {
                Square_centimeterToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square meters")
            {
                Square_centimeterToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square mile")
            {
                Square_centimeterToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square millimeter")
            {
                Square_centimeterToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square yard")
            {
                Square_centimeterToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_centimeterToSquare_yard.ToString();
            }
            else if (cmbFrom.Text == "Square centimeter" && cmbTo.Text == "Square centimeter")
            {
                txtFrom.Text = Convert.ToString(txtFrom.Text);
                txtTo.Text = txtFrom.Text.ToString();
            }

 //*****************************Square feet

            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Acres")
            {
                Square_feetToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Hectares")
            {
                Square_feetToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square centimeter")
            {
                Square_feetToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square inch")
            {
                Square_feetToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square kilometer")
            {
                Square_feetToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square meters")
            {
                Square_feetToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square mile")
            {
                Square_feetToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square millimeter")
            {
                Square_feetToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square yard")
            {
                Square_feetToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_feetToSquare_yard.ToString();
            }
            else if (cmbFrom.Text == "Square feet" && cmbTo.Text == "Square feet")
            {
                txtFrom.Text = Convert.ToString(txtFrom.Text);
                txtTo.Text = txtFrom.Text.ToString();
            }

 //*****************************Square inch

             else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Acres")
            {
                Square_inchToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Hectares")
            {
                Square_inchToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Square centimeter")
            {
                Square_inchToSquare_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToSquare_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Square inch")
            {
                Square_inchToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Square kilometer")
            {
                Square_inchToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Square meters")
            {
                Square_inchToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Square mile")
            {
                Square_inchToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Square millimeter")
            {
                Square_inchToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square inch" && cmbTo.Text == "Square yard")
            {
                Square_inchToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_inchToSquare_yard.ToString();
            }

 //*****************************Square kilometer

            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Acres")
            {
                Square_kilometerToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Hectares")
            {
                Square_kilometerToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square centimeter")
            {
                Square_kilometerToSquare_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square feet")
            {
                Square_kilometerToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square inch")
            {
                Square_kilometerToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square kilometer")
            {
                Square_kilometerToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square meters")
            {
                Square_kilometerToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square mile")
            {
                Square_kilometerToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square millimeter")
            {
                Square_kilometerToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square kilometer" && cmbTo.Text == "Square yard")
            {
                Square_kilometerToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_kilometerToSquare_yard.ToString();
            }

 //*****************************Square meters

            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Acres")
            {
                Square_metersToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Hectares")
            {
                Square_metersToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square centimeter")
            {
                Square_metersToSquare_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square feet")
            {
                Square_metersToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square inch")
            {
                Square_metersToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square kilometer")
            {
                Square_metersToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square meters")
            {
                Square_metersToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square mile")
            {
                Square_metersToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square millimeter")
            {
                Square_metersToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square meters" && cmbTo.Text == "Square yard")
            {
                Square_metersToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_metersToSquare_yard.ToString();
            }

 //*****************************Square mile

            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Acres")
            {
                Square_mileToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Hectares")
            {
                Square_mileToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square centimeter")
            {
                Square_mileToSquare_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square feet")
            {
                Square_mileToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square inch")
            {
                Square_mileToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square kilometer")
            {
                Square_mileToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square meters")
            {
                Square_mileToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square mile")
            {
                Square_mileToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square millimeter")
            {
                Square_mileToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square mile" && cmbTo.Text == "Square yard")
            {
                Square_mileToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_mileToSquare_yard.ToString();
            }

 //*****************************Square millimeter

            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Acres")
            {
                Square_millimeterToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Hectares")
            {
                Square_millimeterToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square centimeter")
            {
                Square_millimeterToSquare_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square feet")
            {
                Square_millimeterToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square inch")
            {
                Square_millimeterToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square kilometer")
            {
                Square_millimeterToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square meters")
            {
                Square_millimeterToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square mile")
            {
                Square_millimeterToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square millimeter")
            {
                Square_millimeterToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square millimeter" && cmbTo.Text == "Square yard")
            {
                Square_millimeterToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_millimeterToSquare_yard.ToString();
            }

            //*****************************Square yard

            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Acres")
            {
                Square_yardToAcres = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToAcres.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Hectares")
            {
                Square_yardToHectares = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToHectares.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square centimeter")
            {
                Square_yardToSquare_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square feet")
            {
                Square_yardToSquare_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_feet.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square inch")
            {
                Square_yardToSquare_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_inch.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square kilometer")
            {
                Square_yardToSquare_kilometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_kilometer.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square meters")
            {
                Square_yardToSquare_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_meter.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square mile")
            {
                Square_yardToSquare_mile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_mile.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square millimeter")
            {
                Square_yardToSquare_milli = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_milli.ToString();
            }
            else if (cmbFrom.Text == "Square yard" && cmbTo.Text == "Square yard")
            {
                Square_yardToSquare_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Square_yardToSquare_yard.ToString();
            }
        }

 //********************************Length Convertor******************************       

        private double Centimeters, Feet, Inch, Kilometers, Meter, Microns, Mile, Millimeters, Nanometer, Nautical_Miles, Yard;

//converting Centimeter  to other
        private double CentimetersPerCentimeter = 1, FeetsPerCentimeter = 0.0328083989501312, InchsPerCentimeter = 0.3937007874015748, KilometersPerCentimeter = 0.00001,
            MetersPerCentimeter = 0.01, MicronsPerCentimeter = 10000, MilesPerCentimeter = 6.21371192237334e-6, MillimetersPerCentimeter = 10, NanometersPerCentimeter = 10000000, NauticalMilesPerCentimeter = 5.399568034557235e-6, YardsPerCentimeter = 0.0109361329833771;
        private double CentimetersToCentimeters
        {
            get { return Centimeters * CentimetersPerCentimeter; }
            set { Centimeters = value; }
        }

        private double CentimetersToFeet
        {
            get { return Centimeters * FeetsPerCentimeter; }
            set { Centimeters = value; }
        }

        private double CentimetersToInch
        {
            get { return Centimeters * InchsPerCentimeter ; }
            set { Centimeters = value; }
        }
        private double CentimetersToKilometers
        {
            get { return Centimeters * KilometersPerCentimeter; }
            set { Centimeters = value; }
        }
        private double CentimetersToMeter
        {
            get { return Centimeters * MetersPerCentimeter; }
            set { Centimeters = value; }
        }
        private double CentimetersToMicrons
        {
            get { return Centimeters * MicronsPerCentimeter; }
            set { Centimeters = value; }
        }
        private double CentimetersToMile
        {
            get { return Centimeters * MilesPerCentimeter; }
            set { Centimeters = value; }
        }
        private double CentimetersToMillimeters
        {
            get { return Centimeters * MillimetersPerCentimeter; }
            set { Centimeters = value; }
        }
        private double CentimetersToNanometer
        {
            get { return Centimeters * NanometersPerCentimeter; }
            set { Centimeters = value; }
        }
        private double CentimetersToNautical_Miles
        {
            get { return Centimeters * NauticalMilesPerCentimeter; }
            set { Centimeters = value; }
        }
        private double CentimetersToYard
        {
            get { return Centimeters * YardsPerCentimeter; }
            set { Centimeters = value; }
        }

 //converting to Feet to other
        private double CentimetersPerFeet = 30.48, FeetsPerFeet = 1, InchsPerFeet = 12, KilometersPerFeet = 0.0003048, MetersPerFeet = 0.3048, MicronsPerFeet = 304800, MilesPerFeet = 1.893939393939394e-4, MillimetersPerFeet = 304.8, NanometersPerFeet = 304800000, NauticalMilesPerFeet = 1.645788336933045e-4, YardsPerFeet = 0.3333333333333333;
        private double FeetToCentimeters
        {
            get { return Feet * CentimetersPerFeet; }
            set { Feet = value; }
        }
        private double FeetToFeet
        {
            get { return Feet * FeetsPerFeet; }
            set { Feet = value; }
        }
        private double FeetToInch
        {
            get { return Feet * InchsPerFeet; }
            set { Feet = value; }
        }
        private double FeetToKilometers
        {
            get { return Feet * KilometersPerFeet; }
            set { Feet = value; }
        }
        private double FeetToMeter
        {
            get { return Feet * MetersPerFeet; }
            set { Feet = value; }
        }
        private double FeetToMicrons
        {
            get { return Feet * MicronsPerFeet; }
            set { Feet = value; }
        }
        private double FeetToMile
        {
            get { return Feet * MilesPerFeet; }
            set { Feet = value; }
        }
        private double FeetToMillimeters
        {
            get { return Feet * MillimetersPerFeet; }
            set { Feet = value; }
        }
        private double FeetToNanometer
        {
            get { return Feet * NanometersPerFeet; }
            set { Feet = value; }
        }
        private double FeetToNautical_Miles
        {
            get { return Feet * NauticalMilesPerFeet; }
            set { Feet = value; }
        }
        private double FeetToYard
        {
            get { return Feet * YardsPerFeet; }
            set { Feet = value; }
        }

//converting to Inch to other
        private double CentimetersPerInch = 2.54, FeetsPerInch = 0.0833333333333333, InchsPerInch = 1, KilometersPerInch = 0.0000254, MetersPerInch = 0.0254,
            MicronsPerInch = 25400, MilesPerInch = 1.578282828282828e-5, MillimetersPerInch = 25.4, NanometersPerInch = 25400000, NauticalMilesPerInch = 1.371490280777538e-5, YardsPerInch = 0.0277777777777778;
        
        private double InchToCentimeters
        {
            get { return Inch * CentimetersPerInch; }
            set { Inch = value; }
        }
        private double InchToFeet
        {
            get { return Inch * FeetsPerInch; }
            set { Inch = value; }
        }
        private double InchToInch
        {
            get { return Inch * InchsPerInch; }
            set { Inch = value; }
        }
        private double InchToKilometers
        {
            get { return Inch * KilometersPerInch; }
            set { Inch = value; }
        }
        private double InchToMeter
        {
            get { return Inch * MetersPerInch; }
            set { Inch = value; }
        }
        private double InchToMicrons
        {
            get { return Inch * MicronsPerInch; }
            set { Inch = value; }
        }
        private double InchToMile
        {
            get { return Inch * MilesPerInch; }
            set { Inch = value; }
        }
        private double InchToMillimeters
        {
            get { return Inch * MillimetersPerInch; }
            set { Inch = value; }
        }
        private double InchToNanometer
        {
            get { return Inch * NanometersPerInch; }
            set { Inch = value; }
        }
        private double InchToNautical_Miles
        {
            get { return Inch * NauticalMilesPerInch; }
            set { Inch = value; }
        }
        private double InchToYard
        {
            get { return Inch * YardsPerInch; }
            set { Inch = value; }
        }

//converting to Kilometers to other
        private double CentimetersPerKilometer = 100000, FeetsPerKilometer = 3280.839895013123, InchsPerKilometer = 39370.07874015748, KilometersPerKilometer = 1, MetersPerKilometer = 1000, MicronsPerKilometer = 1000000000, MilesPerKilometer = 0.621371192237334,
            MillimetersPerKilometer = 1000000, NanometersPerKilometer = 1000000000000, NauticalMilesPerKilometer = 0.5399568034557235, YardsPerKilometer = 1093.613298337708;
        
        private double KilometersToCentimeters
        {
            get { return Kilometers * CentimetersPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToFeet
        {
            get { return Kilometers * FeetsPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToInch
        {
            get { return Kilometers * InchsPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToKilometers
        {
            get { return Kilometers * KilometersPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToMeter
        {
            get { return Kilometers * MetersPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToMicrons
        {
            get { return Kilometers * MicronsPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToMile
        {
            get { return Kilometers * MilesPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToMillimeters
        {
            get { return Kilometers * MillimetersPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToNanometer
        {
            get { return Kilometers * NanometersPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToNautical_Miles
        {
            get { return Kilometers * NauticalMilesPerKilometer; }
            set { Kilometers = value; }
        }
        private double KilometersToYard
        {
            get { return Kilometers * YardsPerKilometer; }
            set { Kilometers = value; }
        }

//converting to Meter to other
        private double CentimetersPerMeter = 100, FeetsPerMeter = 3.280839895013123, InchsPerMeter = 39.37007874015748, KilometersPerMeter = 0.001,
            MetersPerMeter = 1, MicronsPerMeter = 1000000, MilesPerMeter = 6.21371192237334e-4, MillimetersPerMeter = 1000, NanometersPerMeter = 1000000000, NauticalMilesPerMeter = 5.399568034557235e-4, YardsPerMeter = 1.093613298337708;
        
        private double MeterToCentimeters
        {
            get { return Meter * CentimetersPerMeter; }
            set { Meter = value; }
        }
        private double MeterToFeet
        {
            get { return Meter * FeetsPerMeter; }
            set { Meter = value; }
        }
        private double MeterToInch
        {
            get { return Meter * InchsPerMeter; }
            set { Meter = value; }
        }
        private double MeterToKilometers
        {
            get { return Meter * KilometersPerMeter; }
            set { Meter = value; }
        }
        private double MeterToMeter
        {
            get { return Meter * MetersPerMeter; }
            set { Meter = value; }
        }
        private double MeterToMicrons
        {
            get { return Meter * MicronsPerMeter; }
            set { Meter = value; }
        }
        private double MeterToMile
        {
            get { return Meter * MilesPerMeter; }
            set { Meter = value; }
        }
        private double MeterToMillimeters
        {
            get { return Meter * MillimetersPerMeter; }
            set { Meter = value; }
        }
        private double MeterToNanometer
        {
            get { return Meter * NanometersPerMeter; }
            set { Meter = value; }
        }
        private double MeterToNautical_Miles
        {
            get { return Meter * NauticalMilesPerMeter; }
            set { Meter = value; }
        }
        private double MeterToYard
        {
            get { return Meter * YardsPerMeter; }
            set { Meter = value; }
        }

//converting to Microns to other
        private double CentimetersPerMicron = 0.0001, FeetsPerMicron = 3.280839895013123e-6, InchsPerMicron = 3.937007874015748e-5, KilometersPerMicron = 0.000000001,
            MetersPerMicron = 0.000001, MicronsPerMicron = 1, MilesPerMicron = 6.21371192237334e-10, MillimetersPerMicron = 0.001, NanometersPerMicron = 1000, NauticalMilesPerMicron = 5.399568034557235e-10, YardsPerMicron = 1.093613298337708e-6;
       
        private double MicronsToCentimeters
        {
            get { return Microns * CentimetersPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToFeet
        {
            get { return Microns * FeetsPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToInch
        {
            get { return Microns * InchsPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToKilometers
        {
            get { return Microns * KilometersPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToMeter
        {
            get { return Microns * MetersPerMicron ; }
            set { Microns = value; }
        }
        private double MicronsToMicrons
        {
            get { return Microns * MicronsPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToMile
        {
            get { return Microns * MilesPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToMillimeters
        {
            get { return Microns * MillimetersPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToNanometer
        {
            get { return Microns * NanometersPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToNautical_Miles
        {
            get { return Microns * NauticalMilesPerMicron; }
            set { Microns = value; }
        }
        private double MicronsToYard
        {
            get { return Microns * YardsPerMicron; }
            set { Microns = value; }
        }

//converting to Mile to other
        private double CentimetersPerMile = 160934.4, FeetsPerMile = 5280, InchsPerMile = 63360, KilometersPerMile = 1.609344, MetersPerMile = 1609.344,
            MicronsPerMile = 1609344000, MilesPerMile = 1, MillimetersPerMile = 1609344, NanometersPerMile = 1609344000000, NauticalMilesPerMile = 0.8689762419006479, YardsPerMile = 1760;

        private double MileToCentimeters
        {
            get { return Mile * CentimetersPerMile; }
            set { Mile = value; }
        }
        private double MileToFeet
        {
            get { return Mile * FeetsPerMile; }
            set { Mile = value; }
        }
        private double MileToInch
        {
            get { return Mile * InchsPerMile; }
            set { Mile = value; }
        }
        private double MileToKilometers
        {
            get { return Mile * KilometersPerMile; }
            set { Mile = value; }
        }
        private double MileToMeter
        {
            get { return Mile * MetersPerMile; }
            set { Mile = value; }
        }
        private double MileToMicrons
        {
            get { return Mile * MicronsPerMile; }
            set { Mile = value; }
        }
        private double MileToMile
        {
            get { return Mile * MilesPerMile; }
            set { Mile = value; }
        }
        private double MileToMillimeters
        {
            get { return Mile * MillimetersPerMile; }
            set { Mile = value; }
        }
        private double MileToNanometer
        {
            get { return Mile * NanometersPerMile; }
            set { Mile = value; }
        }
        private double MileToNautical_Miles
        {
            get { return Mile * NauticalMilesPerMile; }
            set { Mile = value; }
        }
        private double MileToYard
        {
            get { return Mile * YardsPerMile; }
            set { Mile = value; }
        }

//converting to Millimeters to other
        private double CentimetersPerMillimeter = 0.1, FeetsPerMillimeter = 0.0032808398950131, InchsPerMillimeter = 0.0393700787401575, KilometersPerMillimeter = 0.000001,
            MetersPerMillimeter = 0.001, MicronsPerMillimeter = 1000, MilesPerMillimeter = 6.21371192237334e-7, MillimetersPerMillimeter = 1, NanometersPerMillimeter = 1000000, NauticalMilesPerMillimeter = 5.399568034557235e-7, YardsPerMillimeter = 0.0010936132983377;
        
        private double MillimetersToCentimeters
        {
            get { return Millimeters * CentimetersPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToFeet
        {
            get { return Millimeters * FeetsPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToInch
        {
            get { return Millimeters * InchsPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToKilometers
        {
            get { return Millimeters * KilometersPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToMeter
        {
            get { return Millimeters * MetersPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToMicrons
        {
            get { return Millimeters * MicronsPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToMile
        {
            get { return Millimeters * MilesPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToMillimeters
        {
            get { return Millimeters * MillimetersPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToNanometer
        {
            get { return Millimeters * NanometersPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToNautical_Miles
        {
            get { return Millimeters * NauticalMilesPerMillimeter; }
            set { Millimeters = value; }
        }
        private double MillimetersToYard
        {
            get { return Millimeters * YardsPerMillimeter; }
            set { Millimeters = value; }
        }

//converting to Nanometer to other
        private double CentimetersPerNanometer = 0.0000001, FeetsPerNanometer = 3.280839895013123e-9, InchsPerNanometer = 3.937007874015748e-8, KilometersPerNanometer = 0.000000000001, MetersPerNanometer = 0.000000001, MicronsPerNanometer = 0.001, MilesPerNanometer = 6.21371192237334e-13, MillimetersPerNanometer = 0.000001, NanometersPerNanometer = 1, NauticalMilesPerNanometer = 5.399568034557235e-13, YardsPerNanometer = 1.093613298337708e-9;
        
        private double NanometerToCentimeters
        {
            get { return Nanometer * CentimetersPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToFeet
        {
            get { return Nanometer * FeetsPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToInch
        {
            get { return Nanometer * InchsPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToKilometers
        {
            get { return Nanometer * KilometersPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToMeter
        {
            get { return Nanometer * MetersPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToMicrons
        {
            get { return Nanometer * MicronsPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToMile
        {
            get { return Nanometer * MilesPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToMillimeters
        {
            get { return Nanometer * MillimetersPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToNanometer
        {
            get { return Nanometer * NanometersPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToNautical_Miles
        {
            get { return Nanometer * NauticalMilesPerNanometer; }
            set { Nanometer = value; }
        }
        private double NanometerToYard
        {
            get { return Nanometer * YardsPerNanometer; }
            set { Nanometer = value; }
        }

//converting to Nautical Miles to other
        private double CentimetersPerNautical_Mile = 185200, FeetsPerNautical_Mile = 6076.115485564304, InchsPerNautical_Mile = 72913.38582677165,
            KilometersPerNautical_Mile = 1.852, MetersPerNautical_Mile = 1852, MicronsPerNautical_Mile = 1852000000, MilesPerNautical_Mile = 1.150779448023543, MillimetersPerNautical_Mile = 1852000, NanometersPerNautical_Mile = 1852000000000, NauticalMilesPerNautical_Mile = 1, YardsPerNautical_Mile = 2025.371828521435;

        private double Nautical_MilesToCentimeters
        {
            get { return Nautical_Miles * CentimetersPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToFeet
        {
            get { return Nautical_Miles * FeetsPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToInch
        {
            get { return Nautical_Miles * InchsPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToKilometers
        {
            get { return Nautical_Miles * KilometersPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToMeter
        {
            get { return Nautical_Miles * MetersPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToMicrons
        {
            get { return Nautical_Miles * MicronsPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToMile
        {
            get { return Nautical_Miles * MilesPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToMillimeters
        {
            get { return Nautical_Miles * MillimetersPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToNanometer
        {
            get { return Nautical_Miles * NanometersPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToNautical_Miles
        {
            get { return Nautical_Miles * NauticalMilesPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }
        private double Nautical_MilesToYard
        {
            get { return Nautical_Miles * YardsPerNautical_Mile; }
            set { Nautical_Miles = value; }
        }

//converting to Yard to other
        private double CentimetersPerYard = 91.44, FeetsPerYard = 3, InchsPerYard = 36, KilometersPerYard = 0.0009144, MetersPerYard = 0.9144, MicronsPerYard = 914400, MilesPerYard = 5.681818181818182e-4, MillimetersPerYard = 914.4, NanometersPerYard = 914400000, NauticalMilesPerYard = 4.937365010799136e-4, YardsPerYard = 1;
        private double YardToCentimeters
        {
            get { return Yard * CentimetersPerYard; }
            set { Yard = value; }
        }
        private double YardToFeet
        {
            get { return Yard * FeetsPerYard; }
            set { Yard = value; }
        }
        private double YardToInch
        {
            get { return Yard * InchsPerYard; }
            set { Yard = value; }
        }
        private double YardToKilometers
        {
            get { return Yard * KilometersPerYard; }
            set { Yard = value; }
        }
        private double YardToMeter
        {
            get { return Yard * MetersPerYard; }
            set { Yard = value; }
        }
        private double YardToMicrons
        {
            get { return Yard * MicronsPerYard; }
            set { Yard = value; }
        }
        private double YardToMile
        {
            get { return Yard * MilesPerYard ; }
            set { Yard = value; }
        }
        private double YardToMillimeters
        {
            get { return Yard * MillimetersPerYard; }
            set { Yard = value; }
        }
        private double YardToNanometer
        {
            get { return Yard * NanometersPerYard; }
            set { Yard = value; }
        }
        private double YardToNautical_Miles
        {
            get { return Yard * NauticalMilesPerYard; }
            set { Yard = value; }
        }
        private double YardToYard
        {
            get { return Yard * YardsPerYard; }
            set { Yard = value; }
        }



//************************************************************************************
        private void LengthCentimeter()
        {

//converting centimeters to other
            try
            {

                if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
                {
                    txtFrom.Text = "";
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Centimeters")
                {
                    CentimetersToCentimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToCentimeters.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Feet")
                {
                    CentimetersToFeet = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToFeet.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Inch")
                {
                    CentimetersToInch = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToInch.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Kilometers")
                {
                    CentimetersToKilometers = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToKilometers.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Meter")
                {
                    CentimetersToMeter = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToMeter.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Microns")
                {
                    CentimetersToMicrons = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToMicrons.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Mile")
                {
                    CentimetersToMile = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToMile.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Millimeters")
                {
                    CentimetersToMillimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToMillimeters.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Nanometer")
                {
                    CentimetersToNanometer = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToNanometer.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Nautical Miles")
                {
                    CentimetersToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToNautical_Miles.ToString();
                }
                else if (cmbFrom.Text == "Centimeters" && cmbTo.Text == "Yard")
                {
                    CentimetersToYard = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = CentimetersToYard.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//converting Feet to other


        private void LengthFeet()
        {
            try
            {
                if (cmbFrom.Text == "Feet" && cmbTo.Text == "Centimeters")
                {
                    FeetToCentimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToCentimeters.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Feet")
                {
                    FeetToFeet = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToFeet.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Inch")
                {
                    FeetToInch = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToInch.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Kilometers")
                {
                    FeetToKilometers = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToKilometers.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Meter")
                {
                    FeetToMeter = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToMeter.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Microns")
                {
                    FeetToMicrons = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToMicrons.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Mile")
                {
                    FeetToMile = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToMile.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Millimeters")
                {
                    FeetToMillimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToMillimeters.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Nanometer")
                {
                    FeetToNanometer = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToNanometer.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Nautical Miles")
                {
                    FeetToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToNautical_Miles.ToString();
                }
                else if (cmbFrom.Text == "Feet" && cmbTo.Text == "Yard")
                {
                    FeetToYard = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = FeetToYard.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


 //converting Inch to other
         private void LengthInch()
        {
            try
            {

                if (cmbFrom.Text == "Inch" && cmbTo.Text == "Centimeters")
                {
                    InchToCentimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToCentimeters.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Feet")
                {
                    InchToFeet = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToFeet.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Inch")
                {
                    InchToInch = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToInch.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Kilometers")
                {
                    InchToKilometers = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToKilometers.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Meter")
                {
                    InchToMeter = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToMeter.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Microns")
                {
                    InchToMicrons = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToMicrons.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Mile")
                {
                    InchToMile = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToMile.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Millimeters")
                {
                    InchToMillimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToMillimeters.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Nanometer")
                {
                    InchToNanometer = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToNanometer.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Nautical Miles")
                {
                    InchToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToNautical_Miles.ToString();
                }
                else if (cmbFrom.Text == "Inch" && cmbTo.Text == "Yard")
                {
                    InchToYard = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = InchToYard.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

 //converting Kilometers to other
         private void LengthKilometers()
        {
            try
            {

                if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Centimeters")
                {
                    KilometersToCentimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToCentimeters.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Feet")
                {
                    KilometersToFeet = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToFeet.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Inch")
                {
                    KilometersToInch = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToInch.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Kilometers")
                {
                    KilometersToKilometers = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToKilometers.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Meter")
                {
                    KilometersToMeter = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToMeter.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Microns")
                {
                    KilometersToMicrons = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToMicrons.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Mile")
                {
                    KilometersToMile = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToMile.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Millimeters")
                {
                    KilometersToMillimeters = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToMillimeters.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Nanometer")
                {
                    KilometersToNanometer = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToNanometer.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Nautical Miles")
                {
                    KilometersToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToNautical_Miles.ToString();
                }
                else if (cmbFrom.Text == "Kilometers" && cmbTo.Text == "Yard")
                {
                    KilometersToYard = Convert.ToDouble(txtFrom.Text);
                    txtTo.Text = KilometersToYard.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

 //converting Meter to other
         private void LengthMeter()
        {
             try{

            if (cmbFrom.Text == "Meter" && cmbTo.Text == "Centimeters")
            {
                MeterToCentimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToCentimeters.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Feet")
            {
                MeterToFeet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToFeet.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Inch")
            {
                MeterToInch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToInch.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Kilometers")
            {
                MeterToKilometers = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToKilometers.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Meter")
            {
                MeterToMeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToMeter.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Microns")
            {
                MeterToMicrons = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToMicrons.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Mile")
            {
                MeterToMile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToMile.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Millimeters")
            {
                MeterToMillimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToMillimeters.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Nanometer")
            {
                MeterToNanometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToNanometer.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Nautical Miles")
            {
                MeterToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToNautical_Miles.ToString();
            }
            else if (cmbFrom.Text == "Meter" && cmbTo.Text == "Yard")
            {
                MeterToYard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MeterToYard.ToString();
            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

 //converting Microns to other
         private void LengthMicrons()
        {
             try{

            if (cmbFrom.Text == "Microns" && cmbTo.Text == "Centimeters")
            {
                MicronsToCentimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToCentimeters.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Feet")
            {
                MicronsToFeet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToFeet.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Inch")
            {
                MicronsToInch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToInch.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Kilometers")
            {
                MicronsToKilometers = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToKilometers.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Meter")
            {
                MicronsToMeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToMeter.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Microns")
            {
                MicronsToMicrons = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToMicrons.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Mile")
            {
                MicronsToMile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToMile.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Millimeters")
            {
                MicronsToMillimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToMillimeters.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Nanometer")
            {
                MicronsToNanometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToNanometer.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Nautical Miles")
            {
                MicronsToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToNautical_Miles.ToString();
            }
            else if (cmbFrom.Text == "Microns" && cmbTo.Text == "Yard")
            {
                MicronsToYard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicronsToYard.ToString();
            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

//converting Mile to other
         private void LengthMile()
        {
             try{

            if (cmbFrom.Text == "Mile" && cmbTo.Text == "Centimeters")
            {
                MileToCentimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToCentimeters.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Feet")
            {
                MileToFeet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToFeet.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Inch")
            {
                MileToInch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToInch.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Kilometers")
            {
                MileToKilometers = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToKilometers.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Meter")
            {
                MileToMeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToMeter.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Microns")
            {
                MileToMicrons = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToMicrons.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Mile")
            {
                MileToMile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToMile.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Millimeters")
            {
                MileToMillimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToMillimeters.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Nanometer")
            {
                MileToNanometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToNanometer.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Nautical Miles")
            {
                MileToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToNautical_Miles.ToString();
            }
            else if (cmbFrom.Text == "Mile" && cmbTo.Text == "Yard")
            {
                MileToYard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MileToYard.ToString();
            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

//converting Millimeters to other
         private void LengthMillimeters()
        {
             try{

            if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Centimeters")
            {
                MillimetersToCentimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToCentimeters.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Feet")
            {
                MillimetersToFeet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToFeet.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Inch")
            {
                MillimetersToInch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToInch.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Kilometers")
            {
                MillimetersToKilometers = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToKilometers.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Meter")
            {
                MillimetersToMeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToMeter.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Microns")
            {
                MillimetersToMicrons = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToMicrons.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Mile")
            {
                MillimetersToMile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToMile.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Millimeters")
            {
                MillimetersToMillimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToMillimeters.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Nanometer")
            {
                MillimetersToNanometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToNanometer.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Nautical Miles")
            {
                MillimetersToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToNautical_Miles.ToString();
            }
            else if (cmbFrom.Text == "Millimeters" && cmbTo.Text == "Yard")
            {
                MillimetersToYard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillimetersToYard.ToString();
            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }
 //converting Nanometer to other
         private void LengthNanometer()
        {
             try{

            if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Centimeters")
            {
                NanometerToCentimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToCentimeters.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Feet")
            {
                NanometerToFeet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToFeet.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Inch")
            {
                NanometerToInch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToInch.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Kilometers")
            {
                NanometerToKilometers = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToKilometers.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Meter")
            {
                NanometerToMeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToMeter.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Microns")
            {
                NanometerToMicrons = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToMicrons.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Mile")
            {
                NanometerToMile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToMile.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Millimeters")
            {
                NanometerToMillimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToMillimeters.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Nanometer")
            {
                NanometerToNanometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToNanometer.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Nautical Miles")
            {
                NanometerToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToNautical_Miles.ToString();
            }
            else if (cmbFrom.Text == "Nanometer" && cmbTo.Text == "Yard")
            {
                NanometerToYard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = NanometerToYard.ToString();
            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

//converting Nautical Miles to other
         private void LengthNauticalMiles()
        {
             try{

            if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Centimeters")
            {
                Nautical_MilesToCentimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToCentimeters.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Feet")
            {
                Nautical_MilesToFeet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToFeet.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Inch")
            {
                Nautical_MilesToInch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToInch.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Kilometers")
            {
                Nautical_MilesToKilometers = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToKilometers.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Meter")
            {
                Nautical_MilesToMeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToMeter.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Microns")
            {
                Nautical_MilesToMicrons = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToMicrons.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Mile")
            {
                Nautical_MilesToMile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToMile.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Millimeters")
            {
                Nautical_MilesToMillimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToMillimeters.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Nanometer")
            {
                Nautical_MilesToNanometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToNanometer.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Nautical Miles")
            {
                Nautical_MilesToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToNautical_Miles.ToString();
            }
            else if (cmbFrom.Text == "Nautical Miles" && cmbTo.Text == "Yard")
            {
                Nautical_MilesToYard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Nautical_MilesToYard.ToString();
            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

 //converting Yard to other
         private void LengthYard()
            {
             try{

            if (cmbFrom.Text == "Yard" && cmbTo.Text == "Centimeters")
            {
                YardToCentimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToCentimeters.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Feet")
            {
                YardToFeet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToFeet.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Inch")
            {
                YardToInch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToInch.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Kilometers")
            {
                YardToKilometers = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToKilometers.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Meter")
            {
                YardToMeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToMeter.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Microns")
            {
                YardToMicrons = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToMicrons.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Mile")
            {
                YardToMile = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToMile.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Millimeters")
            {
                YardToMillimeters = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToMillimeters.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Nanometer")
            {
                YardToNanometer = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToNanometer.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Nautical Miles")
            {
                YardToNautical_Miles = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToNautical_Miles.ToString();
            }
            else if (cmbFrom.Text == "Yard" && cmbTo.Text == "Yard")
            {
                YardToYard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = YardToYard.ToString();
            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

     
        
  
//********************************  Time Convertor******************************       

         private double Day, Hour, Microsecond, Millisecond, Minute, Second;

//converting Day to other
        private double DaysPerDay = 1, HoursPerDay = 24, MicrosecondsPerDay = 86400000000, MillisecondsPerDay = 86400000, MinutesPerDay = 1440, SecondsPerDay = 86400;
        private double DaysToDay
        {
           
            get { return Day * DaysPerDay; }
            set { Day = value; }
        }
        private double DaysToHour
        {
            get { return Day * HoursPerDay; }
            set { Day = value; }
        }
        private double DaysToMicrosecond
        {
            get { return Day *  MicrosecondsPerDay ; }
            set { Day = value; }
        }
        private double DaysToMillisecond
        {
            get { return Day * MillisecondsPerDay; }
            set { Day = value; }
        }
        private double DaysToMinute
        {
            get { return Day * MinutesPerDay; }
            set { Day = value; }
        }
        private double DaysToSecond
        {
            get { return Day *  SecondsPerDay; }
            set { Day = value; }
        }
        
 //converting Hour  to other
        private double DaysPerHour = 0.0416666666666667, HoursPerHour = 1, MicrosecondsPerHour = 3600000000, MillisecondsPerHour = 3600000, MinutesPerHour = 60, SecondsPerHour = 3600;
        private double HoursToDay
        {
            get { return Hour * DaysPerHour; }
            set { Hour = value; }
        }
        private double HoursToHour
        {
            get { return Hour * HoursPerHour; }
            set { Hour = value; }
        }
        private double HoursToMicrosecond
        {
            get { return Hour * MicrosecondsPerHour; }
            set { Hour = value; }
        }
        private double HoursToMillisecond
        {
            get { return Hour * MillisecondsPerHour; }
            set { Hour = value; }
        }
        private double HoursToMinute
        {
            get { return Hour * MinutesPerHour; }
            set { Hour = value; }
        }
        private double HoursToSecond
        {
            get { return Hour * SecondsPerHour; }
            set { Hour = value; }
        }

//converting Microseconds to other
        private double DaysPerMicrosecond = 1.157407407407407e-11, HoursPerMicrosecond = 2.777777777777778e-10, MicrosecondsPerMicrosecond = 1, MillisecondsPerMicrosecond = 0.001, MinutesPerMicrosecond = 1.666666666666667e-8, SecondsPerMicrosecond = 0.000001;
        private double MicrosecondsToDay
        {
            get { return Microsecond * DaysPerMicrosecond; }
            set { Microsecond = value; }
        }
        private double MicrosecondsToHour
        {
            get { return Microsecond * HoursPerMicrosecond; }
            set { Microsecond = value; }
        }
        private double MicrosecondsToMicrosecond
        {
            get { return Microsecond * MicrosecondsPerMicrosecond; }
            set { Microsecond = value; }
        }
        private double MicrosecondsToMillisecond
        {
            get { return Microsecond * MillisecondsPerMicrosecond; }
            set { Microsecond = value; }
        }
        private double MicrosecondsToMinute
        {
            get { return Microsecond * MinutesPerMicrosecond; }
            set { Microsecond = value; }
        }
        private double MicrosecondsToSecond
        {
            get { return Microsecond * SecondsPerMicrosecond; }
            set { Microsecond = value; }
        }

    //converting Minutes to other
        private double DaysPerMinute = 6.944444444444444e-4, HoursPerMinute = 0.0166666666666667, MicrosecondsPerMinute = 60000000, MillisecondsPerMinute = 60000, MinutesPerMinute = 1, SecondsPerMinute = 60;
        private double MinutesToDay
        {
            get { return Minute * DaysPerMinute; }
            set { Minute = value; }
        }
        private double MinutesToHour
        {
            get { return Minute * HoursPerMinute; }
            set { Minute = value; }
        }
        private double MinutesToMicrosecond
        {
            get { return Minute * MicrosecondsPerMinute; }
            set { Minute = value; }
        }
        private double MinutesToMillisecond
        {
            get { return Minute * MillisecondsPerMinute; }
            set { Minute = value; }
        }
        private double MinutesToMinute
        {
            get { return Minute * MinutesPerMinute; }
            set { Minute = value; }
        }
        private double MinutesToSecond
        {
            get { return Minute * SecondsPerMinute; }
            set { Minute = value; }
        }

//converting Millisecond to other
        private double DaysPerMillisecond = 1.157407407407407e-8, HoursPerMillisecond = 2.777777777777778e-7, MicrosecondsPerMillisecond = 1000, MillisecondsPerMillisecond = 1, MinutesPerMillisecond = 1.666666666666667e-5, SecondsPerMillisecond = 0.001;
        private double MillisecondsToDay
        {
            get { return Millisecond * DaysPerMillisecond; }
            set { Millisecond = value; }
        }
        private double MillisecondsToHour
        {
            get { return Millisecond * HoursPerMillisecond; }
            set { Microsecond = value; }
        }
        private double MillisecondsToMicrosecond
        {
            get { return Millisecond * MicrosecondsPerMillisecond; }
            set { Microsecond = value; }
        }
        private double MillisecondsToMillisecond
        {
            get { return Millisecond * MillisecondsPerMillisecond; }
            set { Microsecond = value; }
        }
        private double MillisecondsToMinute
        {
            get { return Millisecond * MinutesPerMillisecond; }
            set { Millisecond = value; }
        }
        private double MillisecondsToSecond
        {
            get { return Millisecond * SecondsPerMillisecond; }
            set { Millisecond = value; }
        }

//converting to Seconds to other
        private double DaysPerSecond = 1.157407407407407e-5, HoursPerSecond = 2.777777777777778e-4, MicrosecondsPerSecond = 1000000, MillisecondsPerSecond = 1000, MinutesPerSecond = 0.0166666666666667, SecondsPerSecond = 1;
        private double SecondsToDay
        {
            get { return Second * DaysPerSecond; }
            set { Second = value; }
        }
        private double SecondsToHour
        {
            get { return Second * HoursPerSecond; }
            set { Second = value; }
        }
        private double SecondsToMicrosecond
        {
            get { return Second * MicrosecondsPerSecond; }
            set { Second = value; }
        }
        private double SecondsToMillisecond
        {
            get { return Second * MillisecondsPerSecond; }
            set { Second = value; }
        }
        private double SecondsToMinute
        {
            get { return Second * MinutesPerSecond; }
            set { Second = value; }
        }
        private double SecondsToSecond
        {
            get { return Second * SecondsPerSecond; }
            set { Second = value; }
        }



//************************************************************************************
        //converting Days to other
        private void TimeDay()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Day" && cmbTo.Text == "Day")
            {
                DaysToDay = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = DaysToDay.ToString();
            }
            else if (cmbFrom.Text == "Day" && cmbTo.Text == "Hour")
            {
                DaysToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = DaysToHour.ToString();
            }
            else if (cmbFrom.Text == "Day" && cmbTo.Text == "Microsecond")
            {
                DaysToMicrosecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = DaysToMicrosecond.ToString();
            }
            else if (cmbFrom.Text == "Day" && cmbTo.Text == " Millisecond")
            {
                DaysToMillisecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = DaysToMillisecond.ToString();
            }
            else if (cmbFrom.Text == "Day" && cmbTo.Text == " Minute ")
            {
                DaysToMinute = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = DaysToMinute.ToString();
            }
            else if (cmbFrom.Text == "Day" && cmbTo.Text == "Second")
            {
                DaysToSecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = DaysToSecond.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
//converting hour to other
        private void TimeHour()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Hour" && cmbTo.Text == "Day")
            {
                HoursToDay = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HoursToDay.ToString();
            }
            else if (cmbFrom.Text == "Hour" && cmbTo.Text == "Hour")
            {
                HoursToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HoursToHour.ToString();
            }
            else if (cmbFrom.Text == "Hour" && cmbTo.Text == "Microsecond")
            {
                HoursToMicrosecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HoursToMicrosecond.ToString();
            }
            else if (cmbFrom.Text == "Hour" && cmbTo.Text == " Millisecond")
            {
                HoursToMillisecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HoursToMillisecond.ToString();
            }
            else if (cmbFrom.Text == "Hour" && cmbTo.Text == " Minute ")
            {
                DaysToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HoursToMinute.ToString();
            }
            else if (cmbFrom.Text == "Hour" && cmbTo.Text == "Second")
            {
                HoursToSecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = HoursToSecond.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//converting Microsecond to other
        private void TimeMicrosecond()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Microsecond" && cmbTo.Text == "Day")
            {
                MicrosecondsToDay = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicrosecondsToDay.ToString();
            }
            else if (cmbFrom.Text == "Microsecond" && cmbTo.Text == "Hour")
            {
                MicrosecondsToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicrosecondsToHour.ToString();
            }
            else if (cmbFrom.Text == "Microsecond" && cmbTo.Text == "Microsecond")
            {
                MicrosecondsToMicrosecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicrosecondsToMicrosecond.ToString();
            }
            else if (cmbFrom.Text == "Microsecond" && cmbTo.Text == " Millisecond")
            {
                MicrosecondsToMillisecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicrosecondsToMillisecond.ToString();
            }
            else if (cmbFrom.Text == "Microsecond" && cmbTo.Text == " Minute ")
            {
                MicrosecondsToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicrosecondsToMinute.ToString();
            }
            else if (cmbFrom.Text == "Microsecond" && cmbTo.Text == "Second")
            {
                MicrosecondsToSecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MicrosecondsToSecond.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

 //converting Milliseconds to other
        private void TimeMillisecond()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Millisecond" && cmbTo.Text == "Day")
            {
                MillisecondsToDay = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillisecondsToDay.ToString();
            }
            else if (cmbFrom.Text == "Millisecond" && cmbTo.Text == "Hour")
            {
                MillisecondsToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillisecondsToHour.ToString();
            }
            else if (cmbFrom.Text == "Millisecond" && cmbTo.Text == "Microsecond")
            {
                MillisecondsToMicrosecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillisecondsToMicrosecond.ToString();
            }
            else if (cmbFrom.Text == "Millisecond" && cmbTo.Text == " Millisecond")
            {
                MillisecondsToMillisecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillisecondsToMillisecond.ToString();
            }
            else if (cmbFrom.Text == "Millisecond" && cmbTo.Text == " Minute ")
            {
                MillisecondsToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillisecondsToMinute.ToString();
            }
            else if (cmbFrom.Text == "Millisecond" && cmbTo.Text == "Second")
            {
                MillisecondsToSecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MillisecondsToSecond.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

//converting Minute to other
        private void TimeMinute()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == " Minute" && cmbTo.Text == "Day")
            {
                MinutesToDay = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MinutesToDay.ToString();
            }
            else if (cmbFrom.Text == " Minute" && cmbTo.Text == "Hour")
            {
                MinutesToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MinutesToHour.ToString();
            }
            else if (cmbFrom.Text == " Minute" && cmbTo.Text == "Microsecond")
            {
                MinutesToMicrosecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MinutesToMicrosecond.ToString();
            }
            else if (cmbFrom.Text == " Minute" && cmbTo.Text == " Millisecond")
            {
                MinutesToMillisecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MinutesToMillisecond.ToString();
            }
            else if (cmbFrom.Text == " Minute" && cmbTo.Text == " Minute ")
            {
                MinutesToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MinutesToMinute.ToString();
            }
            else if (cmbFrom.Text == " Minute" && cmbTo.Text == "Second")
            {
                MinutesToSecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MinutesToSecond.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

//converting Seconds to other
 
        private void TimeSecond()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == " Second" && cmbTo.Text == "Day")
            {
                SecondsToDay = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = SecondsToDay.ToString();
            }
            else if (cmbFrom.Text == "Second" && cmbTo.Text == "Hour")
            {
                SecondsToHour = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = SecondsToHour.ToString();
            }
            else if (cmbFrom.Text == "Second" && cmbTo.Text == "Microsecond")
            {
                SecondsToMicrosecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = SecondsToMicrosecond.ToString();
            }
            else if (cmbFrom.Text == "Second" && cmbTo.Text == " Millisecond")
            {
                SecondsToMillisecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = SecondsToMillisecond.ToString();
            }
            else if (cmbFrom.Text == "Second" && cmbTo.Text == "Minute")
            {
                SecondsToMinute = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = SecondsToMinute.ToString();
            }
            else if (cmbFrom.Text == "Second" && cmbTo.Text == "Second")
            {
                SecondsToSecond = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = SecondsToSecond.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }




//********************************  volume Convertor****************************** 
        public double Cubic_centimeter, Cubic_feet, Cubic_inch, Cubic_meter, Cubic_yard;


//converting Cubic_centimeter to other
        private double Cubic_centimetersPerCubic_centimeter = 1, Cubic_centimetersPerCubic_feet = 3.531466672148859e-5, Cubic_centimetersPerCubic_inch = 0.0610237440947323, Cubic_centimetersPerCubic_meter = 0.000001, Cubic_centimetersPerCubic_yard = 1.307950619314392e-6;
        private double Cubic_centimetersToCubic_centimeter
        {
            get { return Cubic_centimeter * Cubic_centimetersPerCubic_centimeter; }
            set { Cubic_centimeter = value; }
        }
        private double Cubic_centimetersToCubic_feet
        {
            get { return Cubic_centimeter * Cubic_centimetersPerCubic_feet; }
            set { Cubic_centimeter = value; }
        }
        private double Cubic_centimetersToCubic_inch
        {
            get { return Cubic_centimeter * Cubic_centimetersPerCubic_inch; }
            set { Cubic_centimeter = value; }
        }
        private double Cubic_centimetersToCubic_meter
        {
            get { return Cubic_centimeter * Cubic_centimetersPerCubic_meter; }
            set { Cubic_centimeter = value; }
        }
        private double Cubic_centimetersToCubic_yard
        {
            get { return Cubic_centimeter * Cubic_centimetersPerCubic_yard; }
            set { Cubic_centimeter = value; }
        }


//converting Cubic_feet to other
        private double Cubic_feetsPerCubic_centimeter = 28316.846592, Cubic_feetsPerCubic_feet = 1, Cubic_feetsPerCubic_inch = 1728, Cubic_feetsPerCubic_meter = 0.028316846592, Cubic_feetsPerCubic_yard = 0.037037037037037;
        private double Cubic_feetsToCubic_centimeter
        {
            get { return Cubic_feet * Cubic_feetsPerCubic_centimeter; }
            set { Cubic_feet = value; }
        }
        private double Cubic_feetsToCubic_feet
        {
            get { return Cubic_feet * Cubic_feetsPerCubic_feet; }
            set { Cubic_feet = value; }
        }
        private double Cubic_feetsToCubic_inch
        {
            get { return Cubic_feet * Cubic_feetsPerCubic_inch; }
            set { Cubic_feet = value; }
        }
        private double Cubic_feetsToCubic_meter
        {
            get { return Cubic_feet * Cubic_feetsPerCubic_meter; }
            set { Cubic_feet = value; }
        }
        private double Cubic_feetsToCubic_yard
        {
            get { return Cubic_feet * Cubic_feetsPerCubic_yard; }
            set { Cubic_feet = value; }
        }



//converting Cubic_inch to other
        private double Cubic_inchsPerCubic_centimeter = 16.387064, Cubic_inchsPerCubic_feet = 5.787037037037037e-4, Cubic_inchsPerCubic_inch = 1, Cubic_inchsPerCubic_meter = 0.000016387064, Cubic_inchsPerCubic_yard = 2.143347050754458e-5;
        private double Cubic_inchsToCubic_centimeter
        {
            get { return Cubic_inch * Cubic_inchsPerCubic_centimeter; }
            set { Cubic_inch = value; }
        }
        private double Cubic_inchsToCubic_feet
        {
            get { return Cubic_inch * Cubic_inchsPerCubic_feet; }
            set { Cubic_inch = value; }
        }
        private double Cubic_inchsToCubic_inch
        {
            get { return Cubic_inch * Cubic_inchsPerCubic_inch; }
            set { Cubic_inch = value; }
        }
        private double Cubic_inchsToCubic_meter
        {
            get { return Cubic_inch * Cubic_inchsPerCubic_meter; }
            set { Cubic_inch = value; }
        }
        private double Cubic_inchsToCubic_yard
        {
            get { return Cubic_inch * Cubic_inchsPerCubic_yard; }
            set { Cubic_centimeter = value; }
        }

//converting Cubic_meter to other
        private double Cubic_metersPerCubic_centimeter = 1000000, Cubic_metersPerCubic_feet = 35.31466672148859, Cubic_metersPerCubic_inch = 61023.74409473228, Cubic_metersPerCubic_meter = 1, Cubic_metersPerCubic_yard = 1.307950619314392;
        private double Cubic_metersToCubic_centimeter
        {
            get { return Cubic_meter * Cubic_metersPerCubic_centimeter; }
            set { Cubic_meter = value; }
        }
        private double Cubic_metersToCubic_feet
        {
            get { return Cubic_meter * Cubic_metersPerCubic_feet; }
            set { Cubic_meter = value; }
        }
        private double Cubic_metersToCubic_inch
        {
            get { return Cubic_meter * Cubic_metersPerCubic_inch; }
            set { Cubic_meter = value; }
        }
        private double Cubic_metersToCubic_meter
        {
            get { return Cubic_meter * Cubic_metersPerCubic_meter; }
            set { Cubic_meter = value; }
        }
        private double Cubic_metersToCubic_yard
        {
            get { return Cubic_meter * Cubic_metersPerCubic_yard; }
            set { Cubic_meter = value; }
        }


//converting Cubic_yard to other
        private double Cubic_yardsPerCubic_centimeter = 764554.857984, Cubic_yardsPerCubic_feet = 27, Cubic_yardsPerCubic_inch = 46656, Cubic_yardsPerCubic_meter = 0.764554857984, Cubic_yardsPerCubic_yard = 1;
        private double Cubic_yardsToCubic_centimeter
        {
            get { return Cubic_yard * Cubic_yardsPerCubic_centimeter; }
            set { Cubic_yard = value; }
        }
        private double Cubic_yardsToCubic_feet
        {
            get { return Cubic_yard * Cubic_yardsPerCubic_feet; }
            set { Cubic_yard = value; }
        }
        private double Cubic_yardsToCubic_inch
        {
            get { return Cubic_yard * Cubic_yardsPerCubic_inch; }
            set { Cubic_yard = value; }
        }
        private double Cubic_yardsToCubic_meter
        {
            get { return Cubic_yard * Cubic_yardsPerCubic_meter; }
            set { Cubic_yard = value; }
        }
        private double Cubic_yardsToCubic_yard
        {
            get { return Cubic_yard * Cubic_yardsPerCubic_yard; }
            set { Cubic_yard = value; }
        }
       




 //************************************************************************************
//converting CubicCentimeter to other
        private void VolumeCubicCentimeter()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Cubic centimeter" && cmbTo.Text == "Cubic centimeter")
            {
                Cubic_centimetersToCubic_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_centimetersToCubic_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Cubic centimeter" && cmbTo.Text == "Cubic feet")
            {
                Cubic_centimetersToCubic_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_centimetersToCubic_feet.ToString();
            }
            else if (cmbFrom.Text == "Cubic centimeter" && cmbTo.Text == "Cubic inch")
            {
                Cubic_centimetersToCubic_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_centimetersToCubic_inch.ToString();
            }
            else if (cmbFrom.Text == "Cubic centimeter" && cmbTo.Text == "Cubic meter")
            {
                Cubic_centimetersToCubic_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_centimetersToCubic_meter.ToString();
            }
            else if (cmbFrom.Text == "Cubic centimeter" && cmbTo.Text == "Cubic yard")
            {
                Cubic_centimetersToCubic_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_centimetersToCubic_yard.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
//converting Cubic feet to other
        private void VolumeCubicFeet()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Cubic feet" && cmbTo.Text == "Cubic centimeter")
            {
                Cubic_feetsToCubic_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_feetsToCubic_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Cubic feet" && cmbTo.Text == "Cubic feet")
            {
                Cubic_feetsToCubic_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_feetsToCubic_feet.ToString();
            }
            else if (cmbFrom.Text == "Cubic feet" && cmbTo.Text == "Cubic inch")
            {
                Cubic_feetsToCubic_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_feetsToCubic_inch.ToString();
            }
            else if (cmbFrom.Text == "Cubic feet" && cmbTo.Text == "Cubic meter")
            {
                Cubic_feetsToCubic_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_feetsToCubic_meter.ToString();
            }
            else if (cmbFrom.Text == "Cubic feet" && cmbTo.Text == "Cubic yard")
            {
                Cubic_feetsToCubic_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_feetsToCubic_yard.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
//converting Cubic inch to other
        private void VolumeCubicInch()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Cubic inch" && cmbTo.Text == "Cubic centimeter")
            {
                Cubic_inchsToCubic_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_inchsToCubic_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Cubic inch" && cmbTo.Text == "Cubic feet")
            {
                Cubic_inchsToCubic_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_inchsToCubic_feet.ToString();
            }
            else if (cmbFrom.Text == "Cubic inch" && cmbTo.Text == "Cubic inch")
            {
                Cubic_inchsToCubic_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_inchsToCubic_inch.ToString();
            }
            else if (cmbFrom.Text == "Cubic inch" && cmbTo.Text == "Cubic meter")
            {
                Cubic_inchsToCubic_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_inchsToCubic_meter.ToString();
            }
            else if (cmbFrom.Text == "Cubic inch" && cmbTo.Text == "Cubic yard")
            {
                Cubic_inchsToCubic_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_inchsToCubic_yard.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

//converting Cubic meter to other
        private void VolumeCubicMeter()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Cubic meter" && cmbTo.Text == "Cubic centimeter")
            {
                Cubic_metersToCubic_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_metersToCubic_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Cubic meter" && cmbTo.Text == "Cubic feet")
            {
                Cubic_metersToCubic_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_metersToCubic_feet.ToString();
            }
            else if (cmbFrom.Text == "Cubic meter" && cmbTo.Text == "Cubic inch")
            {
                Cubic_metersToCubic_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_metersToCubic_inch.ToString();
            }
            else if (cmbFrom.Text == "Cubic meter" && cmbTo.Text == "Cubic meter")
            {
                Cubic_metersToCubic_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_metersToCubic_meter.ToString();
            }
            else if (cmbFrom.Text == "Cubic meter" && cmbTo.Text == "Cubic yard")
            {
                Cubic_metersToCubic_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_metersToCubic_yard.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

//converting Cubic yard to other
        private void VolumeCubicYard()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Cubic yard" && cmbTo.Text == "Cubic centimeter")
            {
                Cubic_yardsToCubic_centimeter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_yardsToCubic_centimeter.ToString();
            }
            else if (cmbFrom.Text == "Cubic yard" && cmbTo.Text == "Cubic feet")
            {
                Cubic_yardsToCubic_feet = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_yardsToCubic_feet.ToString();
            }
            else if (cmbFrom.Text == "Cubic yard" && cmbTo.Text == "Cubic inch")
            {
                Cubic_yardsToCubic_inch = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_yardsToCubic_inch.ToString();
            }
            else if (cmbFrom.Text == "Cubic yard" && cmbTo.Text == "Cubic meter")
            {
                Cubic_yardsToCubic_meter = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_yardsToCubic_meter.ToString();
            }
            else if (cmbFrom.Text == "Cubic yard" && cmbTo.Text == "Cubic yard")
            {
                Cubic_yardsToCubic_yard = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = Cubic_yardsToCubic_yard.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



//******************************** Weight Convertor****************************** 
        public double Carat, Centigram, Gram, Kilogram, Milligrame, Ounce, Pound, Tonne;


//converting Carat to other
        private double CaratsPerCarat = 1, CaratsPerCentigram = 20, CaratsPerGram = 0.2, CaratsPerKilogram = 0.0002, CaratsPerMilligrame = 200, CaratsPerOunce = 0.0070547923899161, CaratsPerPound = 4.409245243697552e-4, CaratsPerTonne = 0.0000002;
        private double CaratsToCarat
        {
            get { return Carat * CaratsPerCarat; }
            set { Carat = value; }
        }
        private double CaratsToCentigram
        {
            get { return Carat * CaratsPerCentigram; }
            set { Carat = value; }
        }
        private double CaratsToGram
        {
            get { return Carat * CaratsPerGram; }
            set { Carat = value; }
        }
        private double CaratsToKilogram
        {
            get { return Carat * CaratsPerKilogram; }
            set { Carat = value; }
        }
        private double CaratsToMilligrame
        {
            get { return Carat * CaratsPerMilligrame; }
            set { Carat = value; }
        }
        private double CaratsToOunce 
        {
            get { return Carat * CaratsPerOunce; }
            set { Carat = value; }
        }
        private double CaratsToPound
        {
            get { return Carat * CaratsPerPound; }
            set { Carat = value; }
        }
        private double CaratsToTonne
        {
            get { return Carat * CaratsPerTonne; }
            set { Carat = value; }
        }


//converting Centigram to other

        private double CentigramsPerCarat = 0.05, CentigramsPerCentigram = 1, CentigramsPerGram = 0.01, CentigramsPerKilogram = 0.00001, CentigramsPerMilligrame = 10, CentigramsPerOunce = 3.527396194958041e-4, CentigramsPerPound = 2.204622621848776e-5, CentigramsPerTonne = 0.00000001;
        private double CentigramsToCarat
        {
            get { return Centigram * CentigramsPerCarat; }
            set { Centigram = value; }
        }
        private double CentigramsToCentigram
        {
            get { return Centigram * CentigramsPerCentigram; }
            set { Centigram = value; }
        }
        private double CentigramsToGram
        {
            get { return Centigram * CentigramsPerGram; }
            set { Centigram = value; }
        }
        private double CentigramsToKilogram
        {
            get { return Centigram * CentigramsPerKilogram; }
            set { Centigram = value; }
        }
        private double CentigramsToMilligrame
        {
            get { return Centigram * CentigramsPerMilligrame; }
            set { Centigram = value; }
        }
        private double CentigramsToOunce
        {
            get { return Centigram * CentigramsPerOunce; }
            set { Centigram = value; }
        }
        private double CentigramsToPound
        {
            get { return Centigram * CentigramsPerPound; }
            set { Centigram = value; }
        }
        private double CentigramsToTonne
        {
            get { return Centigram * CentigramsPerTonne; }
            set { Centigram = value; }
        }



//converting Gram to other

        private double GramsPerCarat = 5, GramsPerCentigram = 100, GramsPerGram = 1, GramsPerKilogram = 0.001, GramsPerMilligrame = 1000, GramsPerOunce = 0.0352739619495804, GramsPerPound = 0.0022046226218488, GramsPerTonne = 0.000001;
        private double GramsToCarat
        {
            get { return Gram * GramsPerCarat; }
            set { Gram = value; }
        }
        private double GramsToCentigram
        {
            get { return Gram * GramsPerCentigram; }
            set { Gram = value; }
        }
        private double GramsToGram
        {
            get { return Gram * GramsPerGram; }
            set { Gram = value; }
        }
        private double GramsToKilogram
        {
            get { return Gram * GramsPerKilogram; }
            set { Gram = value; }
        }
        private double GramsToMilligrame
        {
            get { return Gram * GramsPerMilligrame; }
            set { Gram = value; }
        }
        private double GramsToOunce
        {
            get { return Gram * GramsPerOunce; }
            set { Gram = value; }
        }
        private double GramsToPound
        {
            get { return Gram * GramsPerPound; }
            set { Gram = value; }
        }
        private double GramsToTonne
        {
            get { return Gram * GramsPerTonne; }
            set { Gram = value; }
        }

//converting Kilogram to other

        private double KilogramsPerCarat = 5000, KilogramsPerCentigram = 100000, KilogramsPerGram = 1000, KilogramsPerKilogram = 1, KilogramsPerMilligrame = 1000000, KilogramsPerOunce = 35.27396194958041, KilogramsPerPound = 2.204622621848776, KilogramsPerTonne = 0.001;
        private double KilogramsToCarat
        {
            get { return Kilogram * KilogramsPerCarat; }
            set { Kilogram = value; }
        }
        private double KilogramsToCentigram
        {
            get { return Kilogram * KilogramsPerCentigram; }
            set { Kilogram = value; }
        }
        private double KilogramsToGram
        {
            get { return Kilogram * KilogramsPerGram; }
            set { Kilogram = value; }
        }
        private double KilogramsToKilogram
        {
            get { return Kilogram * KilogramsPerKilogram; }
            set { Kilogram = value; }
        }
        private double KilogramsToMilligrame
        {
            get { return Kilogram * KilogramsPerMilligrame; }
            set { Kilogram = value; }
        }
        private double KilogramsToOunce
        {
            get { return Kilogram * KilogramsPerOunce; }
            set { Kilogram = value; }
        }
        private double KilogramsToPound
        {
            get { return Kilogram * KilogramsPerPound; }
            set { Kilogram = value; }
        }
        private double KilogramsToTonne
        {
            get { return Kilogram * KilogramsPerTonne; }
            set { Kilogram = value; }
        }


//converting Milligrame to other

        private double MilligramesPerCarat = 0.005, MilligramesPerCentigram = 0.1, MilligramesPerGram = 0.001, MilligramesPerKilogram = 0.000001, MilligramesPerMilligrame = 1, MilligramesPerOunce = 3.527396194958041e-5, MilligramesPerPound = 2.204622621848776e-6, MilligramesPerTonne = 0.000000001;
        private double MilligramesToCarat
        {
            get { return Milligrame * MilligramesPerCarat; }
            set { Milligrame = value; }
        }
        private double MilligramesToCentigram
        {
            get { return Milligrame * MilligramesPerCentigram; }
            set { Milligrame = value; }
        }
        private double MilligramesToGram
        {
            get { return Milligrame * MilligramesPerGram; }
            set { Milligrame = value; }
        }
        private double MilligramesToKilogram
        {
            get { return Milligrame * MilligramesPerKilogram; }
            set { Milligrame = value; }
        }
        private double MilligramesToMilligrame
        {
            get { return Milligrame * MilligramesPerMilligrame; }
            set { Milligrame = value; }
        }
        private double MilligramesToOunce
        {
            get { return Milligrame * MilligramesPerOunce; }
            set { Milligrame = value; }
        }
        private double MilligramesToPound
        {
            get { return Milligrame * MilligramesPerPound; }
            set { Milligrame = value; }
        }
        private double MilligramesToTonne
        {
            get { return Milligrame * MilligramesPerTonne; }
            set { Milligrame = value; }
        }

//converting Ounce to other

        private double OuncesPerCarat = 141.747615625, OuncesPerCentigram = 2834.9523125, OuncesPerGram = 28.349523125, OuncesPerKilogram = 0.028349523125, OuncesPerMilligrame = 28349.523125, OuncesPerOunce = 1, OuncesPerPound = 0.0625, OuncesPerTonne = 0.000028349523125;
        private double OuncesToCarat
        {
            get { return Ounce * OuncesPerCarat; }
            set { Ounce = value; }
        }
        private double OuncesToCentigram
        {
            get { return Ounce * OuncesPerCentigram; }
            set { Ounce = value; }
        }
        private double OuncesToGram
        {
            get { return Ounce * OuncesPerGram; }
            set { Ounce = value; }
        }
        private double OuncesToKilogram
        {
            get { return Ounce * OuncesPerKilogram; }
            set { Ounce = value; }
        }
        private double OuncesToMilligrame
        {
            get { return Ounce * OuncesPerMilligrame; }
            set { Ounce = value; }
        }
        private double OuncesToOunce
        {
            get { return Ounce * OuncesPerOunce; }
            set { Ounce = value; }
        }
        private double OuncesToPound
        {
            get { return Ounce * OuncesPerPound; }
            set { Ounce = value; }
        }
        private double OuncesToTonne
        {
            get { return Ounce * OuncesPerTonne; }
            set { Ounce = value; }
        }

//converting Pound to other

        private double PoundsPerCarat = 2267.96185, PoundsPerCentigram = 45359.237, PoundsPerGram = 453.59237, PoundsPerKilogram = 0.45359237, PoundsPerMilligrame = 453592.37, PoundsPerOunce = 16, PoundsPerPound = 1, PoundsPerTonne = 0.00045359237;
        private double PoundsToCarat
        {
            get { return Pound * PoundsPerCarat; }
            set { Pound = value; }
        }
        private double PoundsToCentigram
        {
            get { return Pound * PoundsPerCentigram; }
            set { Pound = value; }
        }
        private double PoundsToGram
        {
            get { return Pound * PoundsPerGram; }
            set { Pound = value; }
        }
        private double PoundsToKilogram
        {
            get { return Pound * PoundsPerKilogram; }
            set { Pound = value; }
        }
        private double PoundsToMilligrame
        {
            get { return Pound * PoundsPerMilligrame; }
            set { Pound = value; }
        }
        private double PoundsToOunce
        {
            get { return Pound * PoundsPerOunce; }
            set { Pound = value; }
        }
        private double PoundsToPound
        {
            get { return Pound * PoundsPerPound; }
            set { Pound = value; }
        }
        private double PoundsToTonne
        {
            get { return Pound * PoundsPerTonne; }
            set { Pound = value; }
        }

//converting Tonne to other

        private double TonnesPerCarat = 5000000, TonnesPerCentigram = 100000000, TonnesPerGram = 1000000, TonnesPerKilogram = 1000, TonnesPerMilligrame = 1000000000, TonnesPerOunce = 35273.96194958041, TonnesPerPound = 2204.622621848776, TonnesPerTonne = 1;
        private double TonnesToCarat
        {
            get { return Tonne * TonnesPerCarat; }
            set { Tonne = value; }
        }
        private double TonnesToCentigram
        {
            get { return Tonne * TonnesPerCentigram; }
            set { Tonne = value; }
        }
        private double TonnesToGram
        {
            get { return Tonne * TonnesPerGram; }
            set { Tonne = value; }
        }
        private double TonnesToKilogram
        {
            get { return Tonne * TonnesPerKilogram; }
            set { Tonne = value; }
        }
        private double TonnesToMilligrame
        {
            get { return Tonne * TonnesPerMilligrame; }
            set { Tonne = value; }
        }
        private double TonnesToOunce
        {
            get { return Tonne * TonnesPerOunce; }
            set { Tonne = value; }
        }
        private double TonnesToPound
        {
            get { return Tonne * TonnesPerPound; }
            set { Tonne = value; }
        }
        private double TonnesToTonne
        {
            get { return Tonne * TonnesPerTonne; }
            set { Tonne = value; }
        }



 //************************************************************************************
//converting Carat to other
        private void WeightCarat()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Carat")
            {
                CaratsToCarat = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToCarat.ToString();
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Centigram")
            {
                CaratsToCentigram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToCentigram.ToString();
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Gram")
            {
                CaratsToGram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToGram.ToString();
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Kilogram")
            {
                CaratsToKilogram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToKilogram.ToString();
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Milligrame")
            {
                CaratsToMilligrame = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToMilligrame.ToString();
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Ounce")
            {
                CaratsToOunce = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToOunce.ToString();
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Pound")
            {
                CaratsToPound = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToPound.ToString();
            }
            else if (cmbFrom.Text == "Carat" && cmbTo.Text == "Tonne")
            {
                CaratsToTonne = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CaratsToTonne.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
//converting Centigram to other
        private void WeightCentigram()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Carat")
            {
                CentigramsToCarat = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToCarat.ToString();
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Centigram")
            {
                CentigramsToCentigram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToCentigram.ToString();
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Gram")
            {
                CentigramsToGram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToGram.ToString();
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Kilogram")
            {
                CentigramsToKilogram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToKilogram.ToString();
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Milligrame")
            {
                CentigramsToMilligrame = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToMilligrame.ToString();
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Ounce")
            {
                CentigramsToOunce = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToOunce.ToString();
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Pound")
            {
                CentigramsToPound = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToPound.ToString();
            }
            else if (cmbFrom.Text == "Centigram" && cmbTo.Text == "Tonne")
            {
                CentigramsToTonne = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = CentigramsToTonne.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
//converting Gram to other
        private void WeightGram()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Carat")
            {
                GramsToCarat = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToCarat.ToString();
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Centigram")
            {
                GramsToCentigram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToCentigram.ToString();
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Gram")
            {
                GramsToGram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToGram.ToString();
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Kilogram")
            {
                GramsToKilogram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToKilogram.ToString();
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Milligrame")
            {
                GramsToMilligrame = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToMilligrame.ToString();
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Ounce")
            {
                GramsToOunce = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToOunce.ToString();
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Pound")
            {
                GramsToPound = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToPound.ToString();
            }
            else if (cmbFrom.Text == "Gram" && cmbTo.Text == "Tonne")
            {
                GramsToTonne = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = GramsToTonne.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

//converting Kilogram to other
        private void WeightKilogram()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Carat")
            {
                KilogramsToCarat = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToCarat.ToString();
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Centigram")
            {
                KilogramsToCentigram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToCentigram.ToString();
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Gram")
            {
                KilogramsToGram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToGram.ToString();
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Kilogram")
            {
                KilogramsToKilogram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToKilogram.ToString();
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Milligrame")
            {
                KilogramsToMilligrame = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToMilligrame.ToString();
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Ounce")
            {
                KilogramsToOunce = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToOunce.ToString();
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Pound")
            {
                KilogramsToPound = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToPound.ToString();
            }
            else if (cmbFrom.Text == "Kilogram" && cmbTo.Text == "Tonne")
            {
                KilogramsToTonne = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = KilogramsToTonne.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

//converting Milligrame to other
        private void WeightMilligrame()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Carat")
            {
                MilligramesToCarat = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToCarat.ToString();
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Centigram")
            {
                MilligramesToCentigram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToCentigram.ToString();
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Gram")
            {
                MilligramesToGram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToGram.ToString();
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Kilogram")
            {
                MilligramesToKilogram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToKilogram.ToString();
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Milligrame")
            {
                MilligramesToMilligrame = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToMilligrame.ToString();
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Ounce")
            {
                MilligramesToOunce = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToOunce.ToString();
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Pound")
            {
                MilligramesToPound = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToPound.ToString();
            }
            else if (cmbFrom.Text == "Milligrame" && cmbTo.Text == "Tonne")
            {
                MilligramesToTonne = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = MilligramesToTonne.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
//converting Ounce to other
        private void WeightOunce()
        {
            try{

            if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
            {
                txtFrom.Text = "";
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Carat")
            {
                OuncesToCarat = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToCarat.ToString();
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Centigram")
            {
                OuncesToCentigram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToCentigram.ToString();
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Gram")
            {
                OuncesToGram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToGram.ToString();
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Kilogram")
            {
                OuncesToKilogram = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToKilogram.ToString();
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Milligrame")
            {
                OuncesToMilligrame = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToMilligrame.ToString();
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Ounce")
            {
                OuncesToOunce = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToOunce.ToString();
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Pound")
            {
                OuncesToPound = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToPound.ToString();
            }
            else if (cmbFrom.Text == "Ounce" && cmbTo.Text == "Tonne")
            {
                OuncesToTonne = Convert.ToDouble(txtFrom.Text);
                txtTo.Text = OuncesToTonne.ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
//converting Pound to other
        private void WeightPound()
         {
            try{

             if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
             {
                 txtFrom.Text = "";
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Carat")
             {
                 PoundsToCarat = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToCarat.ToString();
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Centigram")
             {
                 PoundsToCentigram = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToCentigram.ToString();
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Gram")
             {
                 PoundsToGram = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToGram.ToString();
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Kilogram")
             {
                 PoundsToKilogram = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToKilogram.ToString();
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Milligrame")
             {
                 PoundsToMilligrame = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToMilligrame.ToString();
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Ounce")
             {
                 PoundsToOunce = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToOunce.ToString();
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Pound")
             {
                 PoundsToPound = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToPound.ToString();
             }
             else if (cmbFrom.Text == "Pound" && cmbTo.Text == "Tonne")
             {
                 PoundsToTonne = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = PoundsToTonne.ToString();
             }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
//converting Tonne to other
        private void WeightTonne()
         {
            try{

             if (string.IsNullOrEmpty(txtFrom.Text) || txtFrom.Text == "-")
             {
                 txtFrom.Text = "";
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Carat")
             {
                 TonnesToCarat = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToCarat.ToString();
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Centigram")
             {
                 TonnesToCentigram = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToCentigram.ToString();
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Gram")
             {
                 TonnesToGram = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToGram.ToString();
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Kilogram")
             {
                 TonnesToKilogram = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToKilogram.ToString();
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Milligrame")
             {
                 TonnesToMilligrame = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToMilligrame.ToString();
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Ounce")
             {
                 TonnesToOunce = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToOunce.ToString();
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Pound")
             {
                 TonnesToPound = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToPound.ToString();
             }
             else if (cmbFrom.Text == "Tonne" && cmbTo.Text == "Tonne")
             {
                 TonnesToTonne = Convert.ToDouble(txtFrom.Text);
                 txtTo.Text = TonnesToTonne.ToString();
             }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }

  


    }
}