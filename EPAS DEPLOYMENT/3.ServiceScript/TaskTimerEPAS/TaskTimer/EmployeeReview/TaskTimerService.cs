using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WindowsServiceWithTopshelf
{
    ///  <summary>
    ///  Defines object of the Timer
    ///  </summary>


    /// <summary>
    /// Constructor
    /// </summary>
    public class MyService
    {
        private Timer timer;
        public MyService()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
        }

        /// <summary>
        /// Write current date and time in log.txt
        /// </summary>
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var fileName = "Log.txt";

            // Import Namespace for 'Path': using Sytem.IO
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Write current time to a file
            using (var writer = File.AppendText(fullPath))
            {
                writer.WriteLine(DateTime.Now);
            }
        }
        public void Start()
        {
            Console.WriteLine("I love Dogs!");
            timer.Enabled = true;
            timer.Start();
        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.
            Console.WriteLine("I love Dogs STOPPING!");
            if (timer != null)
            {
                timer.Enabled = false;
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

    }
}
