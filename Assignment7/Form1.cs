namespace Assignment7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] correctAnswers = new string[] { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A" };
            
            //string[] answers = new string[] { "A" , "B" , "C" , "D" , "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", "A", "B", "C", "D", };
            /*
            StreamWriter outputFile;
            outputFile = File.CreateText("StudentAnswers.txt");
            for (int index1 =0; index1 < answers.Length; index1++)
            {
                outputFile.WriteLine(answers[index1]);
            }
            outputFile.Close();
            */

            string[] studentAnswers = new string[20];
            int index = 0;

            StreamReader inputFile;
            inputFile = File.OpenText("Answers.txt");
            while (index < studentAnswers.Length && !inputFile.EndOfStream)
            {
                studentAnswers[index] = inputFile.ReadLine();
                index++;
            }
            inputFile.Close();

            int correct, incorrect,index2;

            index2 = 0;
            correct = 0;
            incorrect = 0;

            string wrongAnswers;
            wrongAnswers = "";

            foreach (string studentA in studentAnswers)
            {
                if (studentA == correctAnswers[index2])
                {
                    correct++;
                    index2++;
                }
                else
                {
                    incorrect++;
                    wrongAnswers += ((index2+1).ToString()+", ");
                    index2++;
                }
            }

            label1.Text = "Number of your correct answers: "+correct;
            label1.Visible = true;
            label2.Text = "Number of your incorrect answers: "+incorrect;
            label2.Visible = true;
            if (incorrect == 0)
            {
                label3.Text = "Excellent! You passed the test! Everything is correct!";
                label3.Visible = true;
            }
            else
            {
                label3.Text = "Incorrect answers are: " + wrongAnswers[..^2];
                label3.Visible = true;
            }
        }
    }
}