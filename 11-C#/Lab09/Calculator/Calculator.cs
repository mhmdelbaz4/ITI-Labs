namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }


        public decimal? Num1 { get; set; }
        public decimal? Num2 { get; set; }
        public decimal? Result { get; set; }

        public string? operation { get; set; }

        private void number_click(object sender, EventArgs e)
        {
            if (Result.HasValue)
            {
                Num1 = Result;
                Result = null;
                Num2 = null;
                operation = null;
                txtDiplay.Text = string.Empty;
            }
            if (txtDiplay.Text.Length == 15)
                return;
            Button? btnClicked = sender as Button;
            txtDiplay.Text += btnClicked?.Text;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string input = txtDiplay.Text;
            if (string.IsNullOrWhiteSpace(input))
                return;

            if (Num1.HasValue && Num2.HasValue && Result.HasValue)
            {
                Result = null;
                Num1 = null;
                Num2 = null;
                operation = null;
                txtDiplay.Text = string.Empty;
                txtDiplay.PlaceholderText = "Enter Num1";
                return;
            }

            txtDiplay.Text = txtDiplay.Text.Substring(0, input.Length - 1);
        }

        private void opt_click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiplay.Text))
                return;

            Button? btnOperation = sender as Button;

            if (operation != null && Result == null)
                return;

            if (Result.HasValue)
            {
                Num1 = Result;
                Num2 = null;
                Result = null;
            }
            else
            {
                Num1 = Convert.ToDecimal(txtDiplay.Text);
            }

            operation = btnOperation?.Text;
            txtDiplay.Text = string.Empty;
            txtDiplay.PlaceholderText = "Enter Num2";
        }

        private void dot_Click(object sender, EventArgs e)
        {
            string number = txtDiplay.Text;
            if (number.Contains('.'))
                return;

            if (string.IsNullOrWhiteSpace(number))
                txtDiplay.Text = "0.";
            else
                txtDiplay.Text += '.';
        }

        private void equal_click(object sender, EventArgs e)
        {
            string input = txtDiplay.Text;
            if (string.IsNullOrWhiteSpace(input))
                return;

            if (Result.HasValue)
                return;

            if (!Num1.HasValue)
                return;

            Num2 = Convert.ToDecimal(input);

            switch (operation)
            {
                case "+":
                    Result = Num1 + Num2;
                    break;
                case "-":
                    Result = Num1 - Num2;
                    break;
                case "*":
                    Result = Num1 * Num2;
                    break;
                case "/":
                    if (Num2 == 0)
                    {
                        txtDiplay.Text = string.Empty;
                        txtDiplay.PlaceholderText = "Enter Num2";
                        return;
                    }
                    else
                    {
                        Result = Num1 / Num2;
                    }
                    break;
            }

            txtDiplay.Text = $"{Num1} {operation} {Num2} ={Result}";
        }

   }
}
