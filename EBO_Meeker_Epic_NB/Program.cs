using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBO_Meeker_Epic_NB
{
    class Program
    {
        [STAThread]     // make sure this is in your program - very necessary!

        static void Main(string[] args)
        {
            String UserName = Environment.GetEnvironmentVariable("USERNAME").ToUpper();

            AMC_Functions.GeneralFunctions oGenFun = new AMC_Functions.GeneralFunctions();

            bool TestMode = false;

            DateTime StartTime = DateTime.Now;

            DateTime EndTime;

            if (UserName == "MACRO" || UserName == "ADMINISTRATOR")
            {
                try
                {
                    OSF_Pro_Ambulance_NB oOSF = new OSF_Pro_Ambulance_NB(TestMode);

                    // after completion, store the current time, to pass through for the write log function
                    EndTime = DateTime.Now;

                    // write the log file, as long as it gets through
                    oGenFun.WriteLogFile(true, StartTime, EndTime, false, "jerrodr");
                }
                catch (Exception Ex)
                {
                    // after completion, store the current time, to pass through for the write log function
                    EndTime = DateTime.Now;

                    oGenFun.WriteLogFile(false, StartTime, EndTime, true, "jerrodr", Ex);
                }

            }
            else
            {
                if (TestMode)
                {
                    OSF_Pro_Ambulance_NB oOSF = new OSF_Pro_Ambulance_NB(TestMode);
                }
                else
                {
                    try
                    {
                        OSF_Pro_Ambulance_NB oOSF = new OSF_Pro_Ambulance_NB(TestMode);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error encountered:\n" + ex + "\nPress any key to continue...");
                        Console.ReadLine();
                    }
                }
            }

            Environment.Exit(0);
        }
    }
}
