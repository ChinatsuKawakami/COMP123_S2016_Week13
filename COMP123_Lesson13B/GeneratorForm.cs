using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_Lesson13B
{
    public partial class GeneratorForm : Form
    {
        //Private Instace Object
        private Random _random = new Random();

        private TextBox _firstAbility;
        private TextBox _secondAbility;

        public GeneratorForm()
        {
            InitializeComponent();
        }

      
        private Int32 Roll()
        {
            

            //create new empty List
            List<Int32> numbers = new List<Int32>();
           
            int result = 0;

            //roll a dice
            // we will create 3 dices
            for(int count = 0; count < 4;count++)
            {
                
                int generatedNumber = this._random.Next(0,6) + 1;
                numbers.Add(generatedNumber);
               // result += generatedNumber;
              //  Debug.WriteLine(generatedNumber);

            }
            //drop the lowest die
            numbers.Remove(numbers.Min());

            //add the numbers to the result
            /*
            foreach(var number in numbers)
            {
                result += number;
            }*/

            //that is instead of foreach
            //lambda expression equvalent
            result = numbers.Sum(number => number);
            return result;
        }
        private void GenerateAbilities()
        {
            StrengthTextBox.Text = this.Roll().ToString();
            DextrityTextBox.Text = this.Roll().ToString();
            ConstitutionTextBox.Text = this.Roll().ToString();
            InteligenceTextBox.Text = this.Roll().ToString();
            WisdomTextBox.Text = this.Roll().ToString();
            CharismaTextBox.Text = this.Roll().ToString(); 
        }
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            GenerateAbilities();
        }
        private void GenerateForm_Load(object sender, EventArgs e)
        {
           
            this._random = new Random();//initialize random object
            GenerateAbilities();
            FirstAbilityComboBox.SelectedIndex = 0;
            SecondAbilityComboBox.SelectedIndex = 0;

        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            string temporaryAbility;
            temporaryAbility = this._firstAbility.Text;
            this._firstAbility.Text = this._secondAbility.Text;
            this._secondAbility.Text = temporaryAbility;

        }
        private TextBox ChooseAbility(int selectedAbility)
        {
            TextBox textbox = new TextBox();
            switch(selectedAbility)
            {
                   
                case(int)Ability.Strength:
                    textbox = StrengthTextBox;
                    break;
               case(int)Ability.Dextrity:
                    textbox = DextrityTextBox;
                    break;
               case (int)Ability.Constitution:
                    textbox = ConstitutionTextBox;
                    break;
               case (int)Ability.Inteligence:
                    textbox = InteligenceTextBox;
                    break;
               case (int)Ability.Wisdom:
                    textbox = WisdomTextBox;
                    break;
               case (int)Ability.Charisma:
                    textbox = CharismaTextBox;
                    break;
            }
            return textbox;
        }

        private void FirstAbilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //make a reference to the first ability Selected
            this._firstAbility = ChooseAbility(FirstAbilityComboBox.SelectedIndex);
            
            //Debug.WriteLine((int)Ability.Dextrity);
           // Debug.WriteLine(FirstAbilityComboBox.SelectedIndex);
        }

        private void SecondAbilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //make a reference to the first ability Selected
            this._secondAbility = ChooseAbility(SecondAbilityComboBox.SelectedIndex);
           // Debug.WriteLine(SecondAbilityComboBox.SelectedIndex);
        }

    
    }
}
