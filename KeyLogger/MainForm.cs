using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace KeyLogger
{
    public partial class MainForm : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_LBUTTONDOWN = 0x0201;
        private static LowLevelKeyboardProc _procKey = HookCallbackKey;
        private static LowLevelMouseProc _procMouse = HookCallbackMouse;
        private static IntPtr _hookIDKey = IntPtr.Zero;
        private static IntPtr _hookIDMouse = IntPtr.Zero;
        private static int keyClickCounter = 0;
        private static int mouseClickCounter = 0;
        private static int totalClickCounter = 0;
        private static MainForm form1;
        private static string easyQsnFileName = "questionsEasy.txt";
        private static string intmdeQsnFileName = "questionsIntermediate.txt";
        private static string dfcltQsnFileName = "questionsDifficult.txt";
        private static string statFileName = "statistics.txt";
        private static Questions[] questionObs = new Questions[12];
        private static int currentQuestionNo;
        private static DateTime startTime;
        private static DateTime endTime;


        private string agreeOrNotMsg = "The information below will be logged.\n" +
                                        "1. Number of keys pressed on the keyboard (not the key itself).\n" +
                                        "2. Number of mouse clicks.\n" +
                                        "3. Total of time used. \n\n" +
                                        "Do you agree?";

        private static string finishMsg = "Thank you for participating the survey.";


        public MainForm()
        {
            //initialize all the visual components
            //code is inside of the MainForm.Designer.cs file
            InitializeComponent();

            //initialize questions
            InitializeQuestions();

            //order questions according to group
            OrderQuestions();
            

            //Check user agrement
            //If agree then show questions and track clicks.
            //If not agree then 
            //      If Protege is open close Protege
            //      Safely close this program.

            DialogResult result = MessageBox.Show(agreeOrNotMsg, "User Agreement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _hookIDKey = SetHook(_procKey);
                _hookIDMouse = SetHook(_procMouse);
                form1 = this; // (Form1)Application.OpenForms[0];
                btnStart.Enabled = false;
                btnStop.Enabled = true;

                //manually set currentQuestionNo = -1.
                // as static variable initializes to 0.
                currentQuestionNo = -1;
                MessageBox.Show(currentQuestionNo.ToString());
                //showCurrentQuestion
                btnNext_Click(null, null);
            }
            else if (result == DialogResult.No)
            {
                // Application.Exit();

                Process[] process = Process.GetProcesses();
                foreach (Process p in process)
                {
                    if (p.ProcessName.StartsWith("javaw"))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception e)
                        {

                        }
                    }

                }

                Environment.Exit(0);
            }

        }

        //Show Questions
        private static void ShowQuestions()
        {
            if (currentQuestionNo < 12)
            {
                form1.lblQuestionNo.Text = "Question: "+ (currentQuestionNo + 1).ToString();
                form1.lblQuestion.Text = questionObs[currentQuestionNo].Question;
                if(currentQuestionNo == 11)
                {
                    form1.btnNext.Text = "Finish";
                }
            }
            else
            {
                form1.btnNext.Enabled = false;
                MessageBox.Show(finishMsg);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (currentQuestionNo > -1 && currentQuestionNo < 12)
            {
                endTime = DateTime.Now;
                WriteStatistics();
            }
            currentQuestionNo++;
            InitializeCounter();
            ShowQuestions();
        }

        private TimeSpan getSpentTime()
        {
            TimeSpan t = endTime - startTime;
            return t;
        }

        private string getToolUsed(int qNo)
        {
            string tool = "";
            if(questionObs[qNo].ModelIn == 0)
            {
                tool = "ROWLTab Plugin.";
            }
            else
            {
                tool = "Bare Protege.";
            }
            return tool;
        }

        //statistics will start to write as follows
        // 1,2,3,.....,12
        //rather than 
        // 0,1,2,.....,11
        private void WriteStatistics()
        {

            int qNo = currentQuestionNo + 1;

            if (qNo > 0 && qNo < 13)
            {
                using (StreamWriter w = File.AppendText(statFileName))
                {
                    w.WriteLine("Question {0}: " + questionObs[qNo-1].Question, qNo);
                    w.WriteLine("Tool Used: "+ getToolUsed(qNo - 1));
                    w.WriteLine("Number of mouse clicks: " + mouseClickCounter.ToString());
                    w.WriteLine("Number of keys pressed:  " + keyClickCounter.ToString());
                    TimeSpan t = getSpentTime();
                    w.WriteLine("Total of time used: {0} hour, {1} minutes, {2} seconds, {3} miliseconds." , t.Hours,t.Minutes,t.Seconds,t.Milliseconds);
                    w.WriteLine("");
                }
            }
        }

        private void InitializeCounter()
        {
            keyClickCounter = 0;
            mouseClickCounter = 0;
            totalClickCounter = 0;
            startTime = DateTime.Now;
        }

        //0 for ROWL
        //1 for bare Protege
        private static int getTool(int counter)
        {
            if (counter % 2 == 0)
                return 0;
            else
                return 1;
        }

        //Initialize and set questions
        private static void InitializeQuestions()
        {
            currentQuestionNo = 0;
            int qCounter = 0;
            int tool = 0;
            //readTxt file for questions
            StreamReader streamReader = new StreamReader(easyQsnFileName);

            while(!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if(!line.StartsWith("#") && line.Length > 1)
                {
                    tool = getTool(qCounter);
                    questionObs[qCounter] = new Questions(0, line, tool);
                    qCounter++;
                }
            }

            streamReader.Close();

            streamReader = new StreamReader(intmdeQsnFileName);

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (!line.StartsWith("#") && line.Length > 1)
                {
                    tool = getTool(qCounter);
                    questionObs[qCounter] = new Questions(1, line, tool);
                    qCounter++;
                }
            }

            streamReader.Close();

            streamReader = new StreamReader(dfcltQsnFileName);

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (!line.StartsWith("#") && line.Length > 1)
                {
                    tool = getTool(qCounter);
                    questionObs[qCounter] = new Questions(2, line, tool);
                    qCounter++;
                }
            }

            streamReader.Close();
        }

        private static void OrderQuestions()
        {

        }
        //Button to start tracking manually
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(_hookIDKey != null)
            UnhookWindowsHookEx(_hookIDKey);
            if(_hookIDMouse != null)
            UnhookWindowsHookEx(_hookIDMouse);

            //Set tracking handler turn On
            _hookIDKey = SetHook(_procKey);
            _hookIDMouse = SetHook(_procMouse);

            //enable and disable corresponding button
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            // form1 = (Form1)Application.OpenForms[0];
        }

        //Button to stop tracking manually
        private void btnStop_Click(object sender, EventArgs e)
        {
            //remove tracking handler
            UnhookWindowsHookEx(_hookIDKey);
            UnhookWindowsHookEx(_hookIDMouse);

            //enable and disable corresponding button
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        //Set Keyboard Hook
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        ////Set Mouse Hook
        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);


        private static IntPtr HookCallbackKey(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //Console.WriteLine((Keys)vkCode);
               // StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                //sw.WriteLine((Keys)vkCode);
                //sw.Close();
                keyClickCounter++;
                form1.lblStatus.Text = "Writing: " + keyClickCounter.ToString() + "th string";
            }


            totalClickCounter = keyClickCounter + mouseClickCounter;

            form1.txtBxKeyClick.Text = keyClickCounter.ToString();
            form1.txtBxMouseClick.Text = mouseClickCounter.ToString();
            form1.txtBxTotalClickCounter.Text = totalClickCounter.ToString();

            return CallNextHookEx(_hookIDKey, nCode, wParam, lParam);
        }

        private static IntPtr HookCallbackMouse(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //Console.WriteLine((Keys)vkCode);
               // StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                //sw.WriteLine((Keys)vkCode);
               // sw.Close();
                mouseClickCounter++;
            }


            totalClickCounter = keyClickCounter + mouseClickCounter;

            form1.txtBxKeyClick.Text = keyClickCounter.ToString();
            form1.txtBxMouseClick.Text = mouseClickCounter.ToString();
            form1.txtBxTotalClickCounter.Text = totalClickCounter.ToString();

            return CallNextHookEx(_hookIDMouse, nCode, wParam, lParam);
        }

        /*
          if (nCode >= 0 && wParam==(IntPtr)WM_LBUTTONDOWN == (MouseMessages) )
            {
                mouseClickCounter++;
                MessageBox.Show("hello world");
                form1.txtBxMouseClick.Text = mouseClickCounter.ToString();
            }
            */

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {

            WM_LBUTTONDOWN = 0x0201,

            WM_LBUTTONUP = 0x0202,

            WM_MOUSEMOVE = 0x0200,

            WM_MOUSEWHEEL = 0x020A,

            WM_RBUTTONDOWN = 0x0204,

            WM_RBUTTONUP = 0x0205

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // The two dll imports below will handle the window hiding.

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 1;

        //manually reset all counters
        private void btnReset_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", false);
            //sw.Close();
            keyClickCounter = 0;
            mouseClickCounter = 0;
            totalClickCounter = 0;
            txtBxKeyClick.Text = keyClickCounter.ToString();
            txtBxMouseClick.Text = mouseClickCounter.ToString();
            txtBxTotalClickCounter.Text = totalClickCounter.ToString();
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();


    }
}
