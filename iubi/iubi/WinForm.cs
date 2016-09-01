using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;
using SuperWebSocket;

namespace iubi
{
    class WinForm: Form,DPFP.Capture.EventHandler
    {
        

        public int stateEnrroller = 0;     // controla el estado del proceso de incripción.
        public DPFP.Processing.Enrollment Enroller;  // incripcion de huella.
        public DPFP.Capture.Capture Capturer;    // controla la captura de la huella.
        public string typeProcces = ""; // tipo de proceso que ejecutara el lector (register/validation/checkin) 
        public string bitmapDactilar = null;
        public string dedo = "";
        public bool resultRegister;

        public string ServerType = "";
        public WebSocketServer appServer = new WebSocketServer();

        public string identificacion;



        public void Connnect() {
            Init();
            Start();

           
        }
        
        protected virtual void Init()
        {
            try
            {
                Enroller = new DPFP.Processing.Enrollment();            // Create an enrollment.
                Capturer = new DPFP.Capture.Capture(Priority.Low);              // Create a capture operation.

                UpdateStatus();
                if (null != Capturer)
                    Capturer.EventHandler = this;                   // Subscribe for capturing events.
            }
            catch
            {

            }
        }

        private void UpdateStatus()
        {
            this.stateEnrroller = (int)Enroller.FeaturesNeeded;
        }

        public void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();

                }
                catch
                {

                }
            }
        }

        public void Pause()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {

                }
            }
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MessageBox.Show("ola");
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
          
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                

                string json = @"data =
                        {
                            'type': '" + "connect" + @"'
                        }
                    ";

                foreach (WebSocketSession session in appServer.GetAllSessions())
                {
                    session.Send(json);
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                string json = @"data =
                        {
                            'type': '" + "disconnect" + @"'
                        }
                    ";

                foreach (WebSocketSession session in appServer.GetAllSessions())
                {
                    session.Send(json);
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
           
        }
    }
}
