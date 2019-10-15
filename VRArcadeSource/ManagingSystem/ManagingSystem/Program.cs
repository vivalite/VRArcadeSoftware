using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ManagingSystem
{
    static class Program
    {

        static Mutex mutex = new Mutex(true, "{2E1A3075-5121-4B73-89AC-94C9FA0FC103}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                SystemEvents.PowerModeChanged += OnPowerChange;

                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    // enable multi-core JIT
                    ProfileOptimization.SetProfileRoot(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\VRArcade\ManagingSystem");
                    ProfileOptimization.StartProfile("Startup.Profile");

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    LoadTheme();

#if DEBUG
                    try
                    {
                        Application.Run(new MainWindow());
                        //Application.Run(new HardwareCode());
                    }
                    catch { }

#else
                    try{
                        if (Utility.IsValidLicenseAvailable())
                        {
                            Application.Run(new MainWindow());
                        }
                        else
                        {
                            Application.Run(new HardwareCode());
                        }
                    }catch {}
#endif

                }
                else
                {
                    MessageBox.Show("Only one instance is allowed!");
                }
            }
            finally
            {
                NetworkFunction.ShutDown();
            }
        }

        private static void OnPowerChange(object sender, PowerModeChangedEventArgs e)
        {
            NetworkFunction.ShutDown();
            Application.Exit();

        }

        private static void LoadTheme()
        {
            // load theme

            //var themefiles = Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "Telerik.WinControls.Themes.TelerikMetroTouch.dll");
            var themefiles = Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "Telerik.WinControls.Themes.VisualStudio2012Light.dll");

            foreach (var theme in themefiles)
            {
                var themeAssembly = Assembly.LoadFile(theme);
                var themeType = themeAssembly.GetTypes().Where(t => typeof(RadThemeComponentBase).IsAssignableFrom(t)).FirstOrDefault();
                if (themeType != null)
                {
                    RadThemeComponentBase themeObject = (RadThemeComponentBase)Activator.CreateInstance(themeType);
                    if (themeObject != null)
                    {
                        themeObject.Load();
                    }
                }
            }
            var themeList = ThemeRepository.AvailableThemeNames.ToList();

            //ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light";
        }


    }
}
